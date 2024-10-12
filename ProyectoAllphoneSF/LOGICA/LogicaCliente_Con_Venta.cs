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
            List<Cliente_Con_Venta> DatosCompra = new List<Cliente_Con_Venta> ();
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open ();
                string query = @"
    SELECT 
        c.Nombre AS NombreCliente, 
        c.Apellido, 
        z.Localidad, 
        p.Nombre AS NombreProducto, 
        t.NombreTipo, 
        d.Fecha, 
        f.MetodoPago, 
        m.Moneda 
    FROM DatosCompra d
    INNER JOIN Cliente c ON d.ClienteID = c.ClienteID
    INNER JOIN Zonas z ON z.ZonaID = z.ZonaID
    INNER JOIN Productos p ON p.ProductoID = p.ProductoID
    INNER JOIN TiposProductos t ON t.TipoID = t.TipoID
    INNER JOIN FormaPago f ON f.FormaPagoID = f.FormaPagoID
    INNER JOIN Monedas m ON m.MonedaID = m.MonedaID";

                SQLiteCommand cmd = new SQLiteCommand (query,conexion);
                using(SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read ())
                    {
                        DatosCompra.Add(new Cliente_Con_Venta()
                        {
                            ClienteID = int.Parse(reader["ClienteID"].ToString()),
                            Nombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            Localidad = reader["Localidad"].ToString(),
                            NombreProducto = reader["NombreProducto"].ToString(),
                            NombreTipo = reader["NombreTipo"].ToString(),
                            PrecioVenta = int.Parse(reader["PrecioVenta"].ToString()),
                            Metodopago = reader["MetodoPago"].ToString(),
                            Descuento = int.Parse(reader["Descuento"].ToString()),
                            Fecha = DateTime.Now,
                            Cantidad = int.Parse(reader["Cantidad"].ToString()),
                            TotalVenta = int.Parse(reader["TotalVenta"].ToString()),
                        });
                    }
                    return DatosCompra;
                }
            }
        }
    }
}
