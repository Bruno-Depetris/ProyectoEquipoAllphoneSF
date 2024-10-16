using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SQLite;
using ProyectoAllphoneSF.MODELO;
using System.Windows.Forms;


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


        /*public List<DatosCompra> ListarCompra() {
            List<DatosCompra> listaDatosCompra = new List<DatosCompra>();

            using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
                conexion.Open();

                string query = @"
            SELECT 
                Cliente.ClienteID, 
                Cliente.Nombre, 
                Cliente.Apellido, 
                Cliente.Telefono, 
                Cliente.Email, 
                Zonas.Localidad, 
                Productos.ProductoID, 
                Productos.Nombre AS ProductoNombre, 
                Productos.PrecioVenta, 
                FormaPago.FormaPagoID, 
                FormaPago.MetodoPago, 
                FormaPago.TasaInteres,
                DatosCompra.Cantidad, 
                DatosCompra.TotalVenta, 
                DatosCompra.Fecha
            FROM
                Cliente
            JOIN
                Zonas ON Cliente.ZonaID = Zonas.ZonaID
            JOIN
                DatosCompra ON Cliente.ClienteID = DatosCompra.ClienteID
            JOIN
                FormaPago ON DatosCompra.FormaPagoID = FormaPago.FormaPagoID
            JOIN
                Productos ON DatosCompra.ProductoID = Productos.ProductoID;
        ";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                using (SQLiteDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        DatosCompra compra = new DatosCompra() {
                            ClienteID = int.Parse(reader["ClienteID"].ToString()), // Ahora esto funcionará
                            ProductoID = int.Parse(reader["ProductoID"].ToString()), // Ahora esto funcionará
                            FormaPagoID = int.Parse(reader["FormaPagoID"].ToString()), // Ahora esto funcionará
                            Cantidad = int.Parse(reader["Cantidad"].ToString()),
                            TotalVenta = decimal.Parse(reader["TotalVenta"].ToString()),
                            Cuotas = int.Parse(reader["TotalVenta"].ToString()),
                            Fecha = DateTime.Parse(reader["Fecha"].ToString())
                        };

                        listaDatosCompra.Add(compra);
                    }
                }
            }

            return listaDatosCompra; // Retornar la lista de compras
        }*/


    }
}
