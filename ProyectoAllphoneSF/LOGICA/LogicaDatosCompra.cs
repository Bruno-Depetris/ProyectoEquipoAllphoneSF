using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SQLite;
using ProyectoAllphoneSF.MODELO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace ProyectoAllphoneSF.LOGICA {
    internal class LogicaDatosCompra {


        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;


        private static LogicaDatosCompra _LogicaDatosCompra;

        public LogicaDatosCompra() {

        }

        public static LogicaDatosCompra Instancia {
            get {
                if (_LogicaDatosCompra == null) {
                    _LogicaDatosCompra = new LogicaDatosCompra();

                }
                return _LogicaDatosCompra;
            }
        }

        public bool CargarCompra(DatosCompra comp) {
            bool respuesta = false;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
                conexion.Open();


                string query = "INSERT INTO DatosCompra (ClienteID,ProductoID,FormaPagoID,Fecha,MonedaID,Cantidad,TotalVenta,Cuotas) VALUES(@ClienteID,@ProductoID,@FormaPagoID,@Fecha,@MonedaID,@Cantidad,@TotalVenta,@Cuotas)";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                cmd.Parameters.Add(new SQLiteParameter("@ClienteID", comp.ClienteID));
                cmd.Parameters.Add(new SQLiteParameter("@ProductoID", comp.ProductoID));
                cmd.Parameters.Add(new SQLiteParameter("@FormaPagoID", comp.FormaPagoID));
                cmd.Parameters.Add(new SQLiteParameter("@Fecha", comp.Fecha));
                cmd.Parameters.Add(new SQLiteParameter("@MonedaID", comp.MonedaID));
                cmd.Parameters.Add(new SQLiteParameter("@Cantidad", comp.Cantidad));
                cmd.Parameters.Add(new SQLiteParameter("@TotalVenta", comp.TotalVenta));
                cmd.Parameters.Add(new SQLiteParameter("@Cuotas", comp.Cuotas));




                if (cmd.ExecuteNonQuery() < 1) {
                    Console.WriteLine("Error Logica CARGAR COMPRA");
                    return respuesta;
                }

                Console.WriteLine("COMPRA Guardado con EXITO");

            }


            return respuesta = true;
        }
        public List<DatosCompra> ListarCompras() {
            List<DatosCompra> compras = new List<DatosCompra>();

            using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
                conexion.Open();

                // Consulta para obtener los datos de compra y unirse con las otras tablas según sea necesario
                string query = @"
        SELECT dc.CompraID, dc.ClienteID, dc.ProductoID, dc.FormaPagoID, dc.Fecha, 
               dc.MonedaID, dc.Cantidad, dc.TotalVenta, dc.Cuotas,
               c.Nombre AS NombreCliente, p.Nombre AS NombreProducto, f.Nombre AS FormaPago
        FROM DatosCompra dc
        INNER JOIN Clientes c ON dc.ClienteID = c.ClienteID
        INNER JOIN Productos p ON dc.ProductoID = p.ProductoID
        INNER JOIN FormasPago f ON dc.FormaPagoID = f.FormaPagoID";

                try {
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion)) {
                        using (SQLiteDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                compras.Add(new DatosCompra() {
                                    ClienteID = Convert.ToInt32(reader["ClienteID"]),
                                    ProductoID = Convert.ToInt32(reader["ProductoID"]),
                                    FormaPagoID = Convert.ToInt32(reader["FormaPagoID"]),
                                    Fecha = Convert.ToDateTime(reader["Fecha"]),
                                    MonedaID = Convert.ToInt32(reader["MonedaID"]),
                                    Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                    TotalVenta = Convert.ToDecimal(reader["TotalVenta"]),
                                    Cuotas = Convert.ToInt32(reader["Cuotas"]),
                                });
                            }
                        }
                    }
                } catch (Exception ex) {
                    // Manejo de excepciones para depuración
                    Console.WriteLine($"Error al listar compras: {ex.Message}");
                }
            }

            return compras;
        }
        public bool EliminarCompra(DatosCompra comp) {
            bool respuesta = false;


            using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
                conexion.Open();    


                string query = "DELETE FROM DatosCompra WHERE DatosCompraID = @DatosCompraID";

                SQLiteCommand cmd = new SQLiteCommand(query,conexion);

                cmd.Parameters.Add(new SQLiteParameter("@DatosCompraID", comp.DatosCompraID));

                if (cmd.ExecuteNonQuery() < 1) {
                    Console.WriteLine("Error al borrar DatosCompra");
                    return respuesta;
                }

                Console.WriteLine("Moneda Eliminada Con exito");
            }

            return respuesta=true;
        }


        /*public bool EditarDatosCompra(DatosCompra comp) {
            bool respuesta = false;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
                conexion.Open();

                // La consulta SQL corregida
                string query = @"
            UPDATE DatosCompra 
            SET ProductoID = @ProductoID, 
                FormaPagoID = @FormaPagoID, 
                MonedaID = @MonedaID, 
                Cantidad = @Cantidad, 
                TotalVenta = @TotalVenta, 
                Cuotas = @Cuotas, 
            WHERE DatosCompraID = @DatosCompraID;
        ";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                // Asignar valores a los parámetros desde el objeto 'comp'
                cmd.Parameters.AddWithValue("@ProductoID", comp.ProductoID);
                cmd.Parameters.AddWithValue("@FormaPagoID", comp.FormaPagoID);
                cmd.Parameters.AddWithValue("@MonedaID", comp.MonedaID);
                cmd.Parameters.AddWithValue("@Cantidad", comp.Cantidad);
                cmd.Parameters.AddWithValue("@TotalVenta", comp.TotalVenta);
                cmd.Parameters.AddWithValue("@Cuotas", comp.Cuotas);
                cmd.Parameters.AddWithValue("@DatosCompraID", comp.DatosCompraID);  // Asegúrate de pasar el ID de la compra

                // Ejecutar la consulta
                if (cmd.ExecuteNonQuery() < 1) {
                    Console.WriteLine("Error al editar los datos de la compra");
                    return respuesta;
                }

                Console.WriteLine("Datos de la compra editados con éxito");
            }

            return respuesta = true;
        }*/

      

    }
}
