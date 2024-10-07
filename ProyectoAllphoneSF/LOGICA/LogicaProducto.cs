using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SQLite;
using System.Data.SqlClient;
using ProyectoAllphoneSF.MODELO;


namespace ProyectoAllphoneSF.LOGICA {
    internal class LogicaProducto {

        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;


        private static LogicaProducto _logicaProducto;

        public LogicaProducto()
        {

        }

        public static LogicaProducto Instancia
        {
            get
            {
                if (_logicaProducto == null)
                {
                    _logicaProducto = new LogicaProducto();

                }
                return _logicaProducto;
            }
        }

        public bool cargarProducto (Productos produc)
        {
            bool respuesta = false;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();


                string query = "INSERT INTO Productos (Nombre,TipoID,PrecioCosto,PrecioVenta,Stock) VALUES (@Nombre,@TipoID,@PrecioCosto,@PrecioVenta,@Stock)";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                cmd.Parameters.Add(new SQLiteParameter("@Nombre", produc.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@TipoID", produc.TipoID));
                cmd.Parameters.Add(new SQLiteParameter("@PrecioCosto", produc.PrecioCosto));
                cmd.Parameters.Add(new SQLiteParameter("@PrecioVenta", produc.PrecioVenta));
                cmd.Parameters.Add(new SQLiteParameter("@Stock", produc.Stock));


                if (cmd.ExecuteNonQuery() < 1)
                {
                    Console.WriteLine("Error Logica CARGAR PRODUCTO");
                    return respuesta;
                }

                Console.WriteLine("Producto Guardado con EXITO");

            }
            return respuesta = true;
        }

        public bool EliminarProducto(Productos produc)
        {
            bool respuesta = false;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();


                string query = "DELETE FROM Productos WHERE ProductoID = @ProductoID";



                SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                cmd.Parameters.Add(new SQLiteParameter("@ProductoID", produc.ProductoID));

                if (cmd.ExecuteNonQuery() < 1)
                {
                    Console.WriteLine("Error al borrar Producto");
                    return respuesta;
                }

                Console.WriteLine("Producto Eliminado Con exito");
            }
            return respuesta = true;
        }

        public bool EditarProducto(Productos produc)
        {
            bool respuesta = false;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();


                string query = "UPDATE Productos SET Nombre = @Nombre, TipoID = @TipoID, PrecioCosto = @PrecioCosto, PrecioVenta = @PrecioVenta, Stock = @Stock WHERE ProductoID = @ProductoID";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                cmd.Parameters.Add(new SQLiteParameter("@ProductoID", produc.ProductoID));
                cmd.Parameters.Add(new SQLiteParameter("@Nombre", produc.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@TipoID", produc.TipoID));
                cmd.Parameters.Add(new SQLiteParameter("@PrecioCosto", produc.PrecioCosto));
                cmd.Parameters.Add(new SQLiteParameter("@PrecioVenta", produc.PrecioVenta));
                cmd.Parameters.Add(new SQLiteParameter("@Stock", produc.Stock));


                if (cmd.ExecuteNonQuery() < 1)
                {
                    Console.WriteLine("Error Logica EDITAR PRODUCTO");
                    return respuesta;
                }

                Console.WriteLine("Producto Editado con EXITO");

            }
            return respuesta = true;
        }

        public List<Productos> ListarCliente(Productos produc)
        {

            List<Productos> DatosProductos = new List<Productos>();

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();

                string query = "SELECT ProductoID,Nombre,TipoID,PrecioCosto,PrecioVenta,Stock";


                SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {

                        DatosProductos.Add(new Productos()
                        {

                            ProductoID = int.Parse(reader["ProductoID"].ToString()),
                            Nombre = reader["Nombre"].ToString(),
                            TipoID = int.Parse(reader["TipoID"].ToString()),
                            PrecioCosto = decimal.Parse(reader["PrecioCosto"].ToString()),
                            PrecioVenta = decimal.Parse(reader["PrecioVenta"].ToString()),
                            Stock = int.Parse(reader["Stock"].ToString())
                        });

                    }

                    return DatosProductos;

                }
            }
    
}
