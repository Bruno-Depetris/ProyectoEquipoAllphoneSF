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
    internal class LogicaMoneda {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;


        private static LogicaMoneda _LogicaMoneda;

        public LogicaMoneda() {

        }

        public static LogicaMoneda Instancia {
            get {
                if (_LogicaMoneda == null) {
                    _LogicaMoneda = new LogicaMoneda();

                }
                return _LogicaMoneda;
            }
        }

        public bool CargarMoneda(Monedas Mon) {
            bool respuesta = false;


            using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
                conexion.Open();


                string query = "INSERT INTO Monedas(MonedaName) VALUES (@MonedaName)";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                cmd.Parameters.Add(new SQLiteParameter("@MonedaName", Mon.MonedaName));


                if (cmd.ExecuteNonQuery() < 1) {
                    Console.WriteLine("Error al guardar una zona");
                    return respuesta;
                }

                return respuesta = true;
            }
        }
    }
}
