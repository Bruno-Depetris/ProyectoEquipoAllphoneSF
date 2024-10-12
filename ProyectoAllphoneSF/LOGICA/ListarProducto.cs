using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Configuration;
using System.Data.SqlClient;
using ProyectoAllphoneSF.MODELO;
using System.Reflection;


namespace ProyectoAllphoneSF.LOGICA {
    internal class ListarProducto {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;


        private static ListarProducto _ListarProducto;

        public ListarProducto() {

        }

        public static ListarProducto Instancia {
            get {
                if (_ListarProducto == null) {
                    _ListarProducto = new ListarProducto();

                }
                return _ListarProducto;
            }
        }
        public  List<ProductoConTipo> ListaProductos() {
            List<ProductoConTipo> DatosProductos = new List<ProductoConTipo>();

            using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
                conexion.Open();

                string query = @"
            SELECT p.ProductoID, p.Nombre, p.TipoID, t.NombreTipo, p.PrecioCosto, p.PrecioVenta, p.Stock
            FROM Productos p
            INNER JOIN TiposProductos t ON p.TipoID = t.TipoID";





                SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                using (SQLiteDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        DatosProductos.Add(new ProductoConTipo() {
                            ProductoID = int.Parse(reader["ProductoID"].ToString()),
                            Nombre = reader["Nombre"].ToString(),
                            TipoID = int.Parse(reader["TipoID"].ToString()),
                            NombreTipo = reader["NombreTipo"].ToString(),  
                            PrecioCosto = decimal.Parse(reader["PrecioCosto"].ToString()),
                            PrecioVenta = decimal.Parse(reader["PrecioVenta"].ToString()),
                            Stock = int.Parse(reader["Stock"].ToString())
                        });
                    }
                    return DatosProductos;
                }
            }
        }
    }


}
