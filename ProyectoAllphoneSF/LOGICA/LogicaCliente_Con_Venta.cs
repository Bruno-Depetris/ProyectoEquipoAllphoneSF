using ProyectoAllphoneSF.MODELO;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

namespace ProyectoAllphoneSF.LOGICA
{
    internal class LogicaCliente_Con_Venta
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;


        private static LogicaCliente_Con_Venta _logicaClienteconventa;

        public LogicaCliente_Con_Venta() {

        }

        public static LogicaCliente_Con_Venta Instancia {
            get {
                if (_logicaClienteconventa == null) {
                    _logicaClienteconventa = new LogicaCliente_Con_Venta();

                }
                return _logicaClienteconventa;
            }
        }
        public List<Cliente_Con_Venta> ListarDatosCompra()
        {
            List<Cliente_Con_Venta> DatosCompra = new List<Cliente_Con_Venta>();
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = @"
            SELECT
                c.Nombre AS NombreCliente, 
                c.Apellido AS ApellidoCliente,
                p.Nombre AS NombreProducto, 
                t.NombreTipo, 
                d.Fecha, 
                f.MetodoPago,
                f.Descuento,
                m.Moneda,
                p.PrecioVenta,
                d.Cantidad,
                d.TotalVenta
            FROM DatosCompra d
            INNER JOIN Cliente c ON d.ClienteID = c.ClienteID           
            INNER JOIN Productos p ON d.ProductoID = p.ProductoID
            INNER JOIN TiposProductos t ON p.TipoID = t.TipoID
            INNER JOIN FormaPago f ON d.FormaPagoID = f.FormaPagoID
            INNER JOIN Monedas m ON d.MonedaID = m.MonedaID";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DatosCompra.Add(new Cliente_Con_Venta()
                        {
                            Nombre = reader["NombreCliente"].ToString(),
                            Apellido = reader["ApellidoCliente"].ToString(),
                            NombreProducto = reader["NombreProducto"].ToString(),
                            NombreTipo = reader["NombreTipo"].ToString(),
                            PrecioVenta = decimal.Parse(reader["PrecioVenta"].ToString()),
                            Metodopago = reader["MetodoPago"].ToString(),
                            Descuento = decimal.Parse(reader["Descuento"].ToString()),
                            Fecha = DateTime.Parse(reader["Fecha"].ToString()),
                            Cantidad = int.Parse(reader["Cantidad"].ToString()),
                            TotalVenta = decimal.Parse(reader["TotalVenta"].ToString()),
                        });
                    }
                    return DatosCompra;
                }
            }
        }
    }
}
