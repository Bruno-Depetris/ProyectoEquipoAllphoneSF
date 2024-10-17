using ProyectoAllphoneSF.MODELO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAllphoneSF.LOGICA
{
    internal class LogicaCaja
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;


        private static LogicaCaja _LogicaCaja;

        public LogicaCaja()
        {

        }

        public static LogicaCaja Instancia
        {
            get
            {
                if (_LogicaCaja == null)
                {
                    _LogicaCaja = new LogicaCaja();

                }
                return _LogicaCaja;
            }
        }

        public bool CargarAperturaCaja(Caja caja)
        {
            bool respuesta = false;
            using(SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();

                string query = "INSERT INTO Caja (MontoInicial,FechaApertura) VALUES (@MontoInicial,@FechaApertura)";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                cmd.Parameters.Add(new SQLiteParameter("@MontoInicial", caja.MontoInicial));
                
                cmd.Parameters.Add(new SQLiteParameter("@FechaApertura", caja.FechaApertura));
                

                if (cmd.ExecuteNonQuery() < 1)
                {
                    Console.WriteLine("Error Logica CARGAR CAJA");
                    return respuesta;
                }

                Console.WriteLine("Caja cargada correctamente");
                conexion.Close();
            }
            return respuesta = true;    
        }
        public bool CargarCierreCaja(Caja caja)
        {
            bool respuesta = false;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();

                string query = "UPDATE Caja SET MontoFinal = @MontoFinal,FechaCierre = @FechaCierre WHERE CajaID = @CajaID";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                cmd.Parameters.Add(new SQLiteParameter("@CajaID", caja.CajaID));
                cmd.Parameters.Add(new SQLiteParameter("@MontoFinal", caja.MontoFinal));
                cmd.Parameters.Add(new SQLiteParameter("@FechaCierre", caja.FechaCierre));

                if (cmd.ExecuteNonQuery() < 1)
                {
                    Console.WriteLine("Error Logica CARGAR CAJA");
                    return respuesta;
                }

                Console.WriteLine("Caja cargada correctamente");
                conexion.Close ();
            }
            return respuesta = true;
        }
    }
}
