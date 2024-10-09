using ProyectoAllphoneSF.MODELO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAllphoneSF.LOGICA {
    internal class LogicaZona {

        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;


        private static LogicaZona _LogicaZona;

        public LogicaZona() {

        }

        public static LogicaZona Instancia {
            get {
                if (_LogicaZona == null) {
                    _LogicaZona = new LogicaZona();

                }
                return _LogicaZona;
            }
        }

        public bool CargarZona(Zonas zon) {
            try {
                using (SqlConnection conexion = new SqlConnection(cadena)) {
                    conexion.Open();

                    string query = "INSERT INTO Zonas (Localidad) VALUES (@Localidad)";

                    SqlCommand cmd = new SqlCommand(query, conexion);

                    cmd.Parameters.Add(new SQLiteParameter("@Localidad", zon.Localidad));

                    cmd.ExecuteNonQuery();

                    return true;


                }
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());   

                return false;
            } 
        }


        public bool EditarZona(Zonas zon) {
            try {
                using (SqlConnection conexion = new SqlConnection(cadena)) {
                    conexion.Open();

                    string query = "UPDATE Monedas SET Localidad = @Localidad WHERE ZonaID = @ZonaID";

                    SqlCommand cmd = new SqlCommand(query, conexion);

                    cmd.Parameters.Add(new SQLiteParameter("@Localidad", zon.Localidad));

                    cmd.ExecuteNonQuery();

                    return true;


                }
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());

                return false;
            }

        }


        public bool BorrarZonas(Zonas zon) {

            try {
                using (SqlConnection conexion = new SqlConnection(cadena)) {
                    conexion.Open();

                    string query = "DELETE FROM Zona WHERE ZonaID = @ZonaID";

                    SqlCommand cmd = new SqlCommand(query, conexion);

                    cmd.Parameters.Add(new SQLiteParameter("@ZonaID", zon.ZonaID));

                    cmd.ExecuteNonQuery();

                    return true;


                }
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());

                return false;
            }
        }


        List<Zonas> ListarZonas(Zonas zon) {
            List<Zonas> MostrarZonas = new List<Zonas>();


            using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {

                conexion.Open();

                string query = "SELECT ZonaID,Localidad FROM Zonas";


                SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                using (SQLiteDataReader reader = cmd.ExecuteReader()) {

                    while (reader.Read()) {

                        MostrarZonas.Add(new Zonas() {

                            ZonaID = int.Parse(reader["MonedaID"].ToString()),
                            Localidad = reader["MonedaName"].ToString(),
                        });

                    }

                    return MostrarZonas;

                }
            }

        }

    }
}
