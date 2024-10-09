using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SQLite;
using ProyectoAllphoneSF.MODELO;

namespace ProyectoAllphoneSF.LOGICA {
    internal class LogicaTipoProducto {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;


        private static LogicaTipoProducto _logicaTipoProducto;

        public LogicaTipoProducto()
        {

        }

        public static LogicaTipoProducto Instancia
        {
            get
            {
                if (_logicaTipoProducto == null)
                {
                    _logicaTipoProducto = new LogicaTipoProducto();

                }
                return _logicaTipoProducto;
            }
        }

        public bool CargarTipoProducto(TiposProductos TipoProduc)
        {
            bool respuesta = false;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "INSERT INTO TipoProductos (NombreTipo) VALUES (@NombreTipo)";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@NombreTipo", TipoProduc.NombreTipo));
                if (cmd.ExecuteNonQuery() < 1)
                {
                    Console.WriteLine("Error Logica CARGAR TIPO PRODUCTO");
                    return respuesta;
                }

                Console.WriteLine("Tipo Producto Guardado con EXITO");
            }
            return respuesta = true;
        }

        public bool EliminarTipoProducto(TiposProductos TipoProduc) {
            bool respuesta = false;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
                conexion.Open();
                string query = "DELETE FROM TipoProductos WHERE TipoID = @TipoID";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                cmd.Parameters.Add(new SQLiteParameter("@TipoID", TipoProduc.TipoID));

                if (cmd.ExecuteNonQuery() < 1) {
                    Console.WriteLine("Error Logica ELIMINAR TIPO PRODUCTO");
                    return respuesta;
                }

                Console.WriteLine("Tipo Producto Eliminado con EXITO");
            }
            return respuesta = true;
        }

        public bool EditarTipoProducto(TiposProductos TipoProduc)
        {
            bool respuesta = false;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "UPDATE TipoProductos SET NombreTipo = @NombreTipo";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                cmd.Parameters.Add(new SQLiteParameter("@TipoID", TipoProduc.TipoID));

                if (cmd.ExecuteNonQuery() < 1)
                {
                    Console.WriteLine("Error Logica ELIMINAR TIPO PRODUCTO");
                    return respuesta;
                }

                Console.WriteLine("Tipo Producto Eliminado con EXITO");
            }
            return respuesta = true;
        }
    }
}
