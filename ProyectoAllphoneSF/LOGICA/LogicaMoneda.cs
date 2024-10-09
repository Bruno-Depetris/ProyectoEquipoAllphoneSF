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
                    Console.WriteLine("Error al guardar una moneda");
                    return respuesta;
                }

                return respuesta = true;
            }
        }
        public bool EliminarMoneda(Monedas Mon)
        {
            bool respuesta = false;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();


                string query = "DELETE FROM Monedas WHERE MonedaID = @MonedaID";



                SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                cmd.Parameters.Add(new SQLiteParameter("@MonedaID", Mon.MonedaID));

                if (cmd.ExecuteNonQuery() < 1)
                {
                    Console.WriteLine("Error al borrar Moneda");
                    return respuesta;
                }

                Console.WriteLine("Moneda Eliminada Con exito");
            }
            return respuesta = true;
        }
        public bool EditarMoneda(Monedas Mon)
        {
            bool respuesta = false;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();

                string query = $"UPDATE Monedas SET MonedaName = @MonedaName WHERE MonedaID = @MonedaID";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                cmd.Parameters.Add(new SQLiteParameter("@MonedaID", Mon.MonedaID));
                cmd.Parameters.Add(new SQLiteParameter("@MonedaName", Mon.MonedaName));

                if (cmd.ExecuteNonQuery() < 1)
                {
                    Console.WriteLine("Error Logica EDITAR MONEDA");
                    return respuesta;
                }

                Console.WriteLine("Moneda Editada con EXITO");

            }
            return respuesta=true;
        }
        public List<Monedas> ListarMoneda(Productos produc)
        {

            List<Monedas> DatosMonedas = new List<Monedas>();

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();

                string query = "SELECT MonedaID,MonedaName";


                SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {

                        DatosMonedas.Add(new Monedas()
                        {

                            MonedaID = int.Parse(reader["MonedaID"].ToString()),
                            MonedaName = reader["MonedaName"].ToString(),
                        });

                    }

                    return DatosMonedas;

                }
            }
        }

    }
}
