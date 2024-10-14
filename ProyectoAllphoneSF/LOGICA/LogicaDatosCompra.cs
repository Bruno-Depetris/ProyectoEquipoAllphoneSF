using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SQLite;
using ProyectoAllphoneSF.MODELO;
using System.Reflection;


namespace ProyectoAllphoneSF.LOGICA {
    internal class LogicaDatosCompra
    {


        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;


        private static LogicaDatosCompra _LogicaDatosCompra;

        public LogicaDatosCompra()
        {

        }

        public static LogicaDatosCompra Instancia
        {
            get
            {
                if (_LogicaDatosCompra == null)
                {
                    _LogicaDatosCompra = new LogicaDatosCompra();

                }
                return _LogicaDatosCompra;
            }
        }

        public bool cargarDatosCompra(DatosCompra compra)
        {
            bool respuesta = false;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();


                string query = "INSERT INTO DatosCompra (ClienteID,ProductoID,FormaPagoID,Fecha,MonedaID,Cantidad,TotalVenta) VALUES (@ClienteID,@ProductoID,@FormaPagoID,@Fecha,@MonedaID,@Cantidad,@TotalVenta)";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                cmd.Parameters.Add(new SQLiteParameter("@ClienteID", compra.ClienteID));
                cmd.Parameters.Add(new SQLiteParameter("@ProductoID", compra.ProductoID));
                cmd.Parameters.Add(new SQLiteParameter("@FormaPagoID", compra.FormaPagoID));
                cmd.Parameters.Add(new SQLiteParameter("@Fecha", compra.Fecha));
                cmd.Parameters.Add(new SQLiteParameter("@MonedaID", compra.MonedaID));
                cmd.Parameters.Add(new SQLiteParameter("@Cantidad", compra.Cantidad));
                cmd.Parameters.Add(new SQLiteParameter("@TotalVenta", compra.TotalVenta));


                if (cmd.ExecuteNonQuery() < 1)
                {
                    Console.WriteLine("Error Logica CARGAR DATOS COMPRA");
                    return respuesta;
                }

                Console.WriteLine("Datos compra Guardados con EXITO");

            }
            return respuesta = true;
        }
        public List<Cliente_Con_Venta> ListarDatosCompra()
        {
            List<Cliente_Con_Venta> DatosCompra = new List<Cliente_Con_Venta>();
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = @"
            SELECT Cliente.Nombre, Cliente.Apellido, Cliente.Telefono, Cliente.Email, Zonas.Localidad, Productos.Nombre AS ProductoNombre, Productos.PrecioVenta, FormaPago.MetodoPago, FormaPago.Descuento
FROM Cliente
JOIN Zonas ON Cliente.ZonaID = Zonas.ZonaID
JOIN DatosCompra ON Cliente.ClienteID = DatosCompra.ClienteID
JOIN FormaPago ON DatosCompra.FormaPagoID = FormaPago.FormaPagoID
JOIN Productos ON DatosCompra.ProductoID = Productos.ProductoID;";
                

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DatosCompra.Add(new Cliente_Con_Venta()
                        {
                            Nombre = reader["NombreCliente"].ToString(),
                            Apellido = reader["ApellidoCliente"].ToString(),
                            
                        });
                    }
                    return DatosCompra;
                }
            }
        }

    }
    /*
     * p.Nombre AS NombreProducto, 
                t.NombreTipo, 
                d.Fecha, 
                f.MetodoPago,
                f.Descuento,
                m.Moneda,
                p.PrecioVenta,
                d.Cantidad,
                d.TotalVenta

    INNER JOIN Productos p ON d.ProductoID = p.ProductoID
            INNER JOIN TiposProductos t ON p.TipoID = t.TipoID
            INNER JOIN FormaPago f ON d.FormaPagoID = f.FormaPagoID
            INNER JOIN Monedas m ON d.MonedaID = m.MonedaID"

    NombreProducto = reader["NombreProducto"].ToString(),
                            NombreTipo = reader["NombreTipo"].ToString(),
                            PrecioVenta = decimal.Parse(reader["PrecioVenta"].ToString()),
                            Metodopago = reader["MetodoPago"].ToString(),
                            Descuento = decimal.Parse(reader["Descuento"].ToString()),
                            Fecha = DateTime.Parse(reader["Fecha"].ToString()),
                            Cantidad = int.Parse(reader["Cantidad"].ToString()),
                            TotalVenta = decimal.Parse(reader["TotalVenta"].ToString()),
    */
}
