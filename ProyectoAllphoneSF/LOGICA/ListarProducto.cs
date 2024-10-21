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
using System.Linq.Expressions;


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

        public List<ProductoConTipo> ListaProductosConOrden(string ordenPor = "Nombre", string busqueda = "") {
            List<ProductoConTipo> DatosProductos = new List<ProductoConTipo>();

            using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
                conexion.Open();

                string query = @"
        SELECT p.ProductoID, p.Nombre, p.TipoID, t.NombreTipo, p.PrecioCosto, p.PrecioVenta, p.Stock
        FROM Productos p
        INNER JOIN TiposProductos t ON p.TipoID = t.TipoID
        WHERE p.Nombre LIKE @busqueda";

                switch (ordenPor.ToLower()) {
                    case "precio costo":
                        query += " ORDER BY p.PrecioCosto";
                        break;
                    case "precio venta":
                        query += " ORDER BY p.PrecioVenta";
                        break;
                    case "seccion":
                        query += " ORDER BY t.NombreTipo";
                        break;
                    case "stock":
                        query += " ORDER BY p.Stock";
                        break;
                    default:
                        query += " ORDER BY p.Nombre";
                        break;
                }

                try {
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion)) {

                        cmd.Parameters.AddWithValue("@busqueda", "%" + busqueda + "%");

                        using (SQLiteDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                DatosProductos.Add(new ProductoConTipo() {
                                    ProductoID = Convert.ToInt32(reader["ProductoID"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    TipoID = Convert.ToInt32(reader["TipoID"]),
                                    NombreTipo = reader["NombreTipo"].ToString(),
                                    PrecioCosto = Convert.ToDecimal(reader["PrecioCosto"]),
                                    PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"]),
                                    Stock = Convert.ToInt32(reader["Stock"])
                                });
                            }
                        }
                    }
                } catch (Exception ex) {
                    Console.WriteLine($"Error al ejecutar la consulta: {ex.Message}");
                }
            }

            return DatosProductos;
        }








    }


}
