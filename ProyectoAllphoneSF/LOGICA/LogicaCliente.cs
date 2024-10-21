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
    public class LogicaCliente {

        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;


        private static LogicaCliente _logicaCliente;

        public LogicaCliente() {

        }

        public static LogicaCliente Instancia {
            get {
                if (_logicaCliente == null) {
                    _logicaCliente = new LogicaCliente();

                }
                return _logicaCliente;
            }
        }


       public bool CargarCliente(Cliente cli) {
            bool respuesta = false;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
                conexion.Open();


                string query = "INSERT INTO Cliente (Nombre,Apellido,Telefono,Email,Direccion,ZonaID) VALUES (@Nombre,@Apellido,@Telefono,@Email,@Direccion,@ZonaID)";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                cmd.Parameters.Add(new SQLiteParameter("@Nombre", cli.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@Apellido", cli.Apellido));
                cmd.Parameters.Add(new SQLiteParameter("@Telefono", cli.Telefono));
                cmd.Parameters.Add(new SQLiteParameter("@Telefono", cli.Telefono));
                cmd.Parameters.Add(new SQLiteParameter("@Email", cli.Email));
                cmd.Parameters.Add(new SQLiteParameter("@Direccion", cli.Direccion));
                cmd.Parameters.Add(new SQLiteParameter("@ZonaID", cli.ZonaID));


                if (cmd.ExecuteNonQuery() < 1) {
                    Console.WriteLine("Error Logica CARGAR CLIENTE");
                    return respuesta;
                }

                Console.WriteLine("Clinte Guardado con EXITO");

            } 

         
            return respuesta = true;
        }


       /*public bool EliminarCliente (Cliente cli) {
            bool respuesta = false;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
                conexion.Open();


                string query = "DELETE FROM Cliente WHERE ClienteID = @ClienteID";



                SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                cmd.Parameters.Add(new SQLiteParameter("@ClienteID", cli.ClienteID));

                if (cmd.ExecuteNonQuery() < 1) {
                    Console.WriteLine("Error al borrar Cliente");
                    return respuesta;
                }

                Console.WriteLine("Cliente Eliminado Con exito");
            }




            return respuesta = true;


        }*/

        /*public bool EditarCliente(Cliente cli) {

            bool respuesta = false; 

            using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
                conexion.Open();

                string query = "UPDATE Cliente SET Nombre = @Nombre, Apellido = @Apellido, Telefono = @Email, ZonaID = @ZonaID WHERE ClienteID = @ClienteID";


                SQLiteCommand cmd = new SQLiteCommand (query, conexion);

                cmd.Parameters.Add(new SQLiteParameter("@ClienteID", cli.ClienteID));
                cmd.Parameters.Add(new SQLiteParameter("@Nombre", cli.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@Apellido", cli.Apellido));
                cmd.Parameters.Add(new SQLiteParameter("@Telefono", cli.Telefono));
                cmd.Parameters.Add(new SQLiteParameter("@Email", cli.Email));
                cmd.Parameters.Add(new SQLiteParameter("@ZonaID", cli.ZonaID));


                if(cmd.ExecuteNonQuery() < 1) {
                    Console.WriteLine("Error al editar cliente");
                    return respuesta;
                }

                Console.WriteLine("Cliente EDITADO");
            }


            return respuesta = true;

        }*/


        public List<Cliente> ListarCliente() {

            List<Cliente> DatosCliente = new List<Cliente>();

            using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
                conexion.Open();

                string query = "SELECT ClienteID,Nombre,Apellido,Telefono,Email,ZonaID FROM Cliente";


                SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                using (SQLiteDataReader reader = cmd.ExecuteReader()) {

                    while (reader.Read()) {

                        DatosCliente.Add(new Cliente() {

                            ClienteID = int.Parse(reader["ClienteID"].ToString()),
                            Nombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Email = reader["Telefono"].ToString(),
                            ZonaID = int.Parse(reader["ZonaID"].ToString())
                        });

                    }

                    return DatosCliente;

                }
            }

        }
    }

}
