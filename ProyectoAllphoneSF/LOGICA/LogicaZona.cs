using ProyectoAllphoneSF.MODELO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;

namespace ProyectoAllphoneSF.LOGICA {
    internal class LogicaZona {

        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private static LogicaZona _LogicaZona;

        public LogicaZona() { }

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
                using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
                    conexion.Open();

                    string query = "INSERT INTO Zonas (Localidad) VALUES (@Localidad)";
                    SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                    cmd.Parameters.Add(new SQLiteParameter("@Localidad", zon.Localidad));
 
                    cmd.ExecuteNonQuery();
                }
                return true;  // Si la operación fue exitosa, devolver true
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());  // Mostrar el error si ocurre
            }
            return false;  // Si hay un error, devolver false
        }


        public bool EditarZona(Zonas zon) {
            try {
                using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
                    conexion.Open();

                    string query = "UPDATE Zonas SET Localidad = @Localidad WHERE ZonaID = @ZonaID";
                    SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                    cmd.Parameters.Add(new SQLiteParameter("@Localidad", zon.Localidad));
                    cmd.Parameters.Add(new SQLiteParameter("@ZonaID", zon.ZonaID));

                    if (cmd.ExecuteNonQuery() > 0) {
                        return true;  // La edición fue exitosa
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public bool BorrarZonas(Zonas zon) {
            try {
                using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
                    conexion.Open();

                    string query = "DELETE FROM Zonas WHERE ZonaID = @ZonaID";
                    SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                    cmd.Parameters.Add(new SQLiteParameter("@ZonaID", zon.ZonaID));

                    if (cmd.ExecuteNonQuery() > 0) {
                        return true;  // Borrado exitoso
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public List<Zonas> ListarZonas() {
            List<Zonas> MostrarZonas = new List<Zonas>();

            try {
                using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
                    conexion.Open();

                    string query = "SELECT ZonaID, Localidad FROM Zonas";
                    SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                    using (SQLiteDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            MostrarZonas.Add(new Zonas() {
                                ZonaID = int.Parse(reader["ZonaID"].ToString()),
                                Localidad = reader["Localidad"].ToString()
                            });
                        }
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }

            return MostrarZonas;
        }
    }
}
