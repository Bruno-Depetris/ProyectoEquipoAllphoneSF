using ProyectoAllphoneSF.MODELO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAllphoneSF.LOGICA {
    internal class ListarClienteCompra {


        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;


        private static ListarClienteCompra _ListarClienteCompra;

        public ListarClienteCompra() {

        }

        public static ListarClienteCompra Instancia {
            get {
                if (_ListarClienteCompra == null) {
                    _ListarClienteCompra = new ListarClienteCompra();

                }
                return _ListarClienteCompra;
            }
        }

        public List<ListarCompra> ListarCompras() {
            List<ListarCompra> listaCompras = new List<ListarCompra>();

            using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
                conexion.Open();

                string query = @"
            SELECT 
    DatosCompra.Fecha, 
    Cliente.Nombre AS NombreCliente, 
    Cliente.Apellido AS ApellidoCliente, 
    Cliente.Email, 
    Zonas.Localidad AS Direccion, 
    Productos.Nombre AS Producto, 
    Productos.PrecioVenta, 
    FormaPago.TasaInteres, 
    FormaPago.MetodoPago AS FormaPago, 
    Monedas.Moneda AS Moneda,  
    DatosCompra.Cantidad, 
    DatosCompra.TotalVenta
FROM
    DatosCompra
LEFT JOIN
    Cliente ON DatosCompra.ClienteID = Cliente.ClienteID
LEFT JOIN
    Zonas ON Cliente.ZonaID = Zonas.ZonaID
LEFT JOIN
    FormaPago ON DatosCompra.FormaPagoID = FormaPago.FormaPagoID
LEFT JOIN
    Productos ON DatosCompra.ProductoID = Productos.ProductoID
LEFT JOIN
    Monedas ON DatosCompra.MonedaID = Monedas.MonedaID
        ";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conexion)) {
                    using (SQLiteDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            ListarCompra compra = new ListarCompra() {
                                Fecha = DateTime.Parse(reader["Fecha"].ToString()),
                                NombreCliente = reader["NombreCliente"].ToString(),
                                ApellidoCliente = reader["ApellidoCliente"].ToString(),
                                Direccion = reader["Direccion"].ToString(),
                                Email = reader["Email"].ToString(),
                                Producto = reader["Producto"].ToString(),
                                PrecioVenta = decimal.Parse(reader["PrecioVenta"].ToString()),
                                FormaPago = reader["FormaPago"].ToString(),
                                Moneda = reader["Moneda"].ToString(),
                                Cantidad = int.Parse(reader["Cantidad"].ToString()),
                                TotalVenta = decimal.Parse(reader["TotalVenta"].ToString())
                            };

                            listaCompras.Add(compra);
                        }
                    }
                }
            }

            return listaCompras;
        }



















    }
}
