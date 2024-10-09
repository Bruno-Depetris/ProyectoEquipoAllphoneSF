using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SQLite;
using ProyectoAllphoneSF.MODELO;


namespace ProyectoAllphoneSF.LOGICA {
    internal class LogicaDatosCompra {


        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;


        private static LogicaDatosCompra _LogicaDatosCompra;

        public LogicaDatosCompra() {

        }

        public static LogicaDatosCompra Instancia {
            get {
                if (_LogicaDatosCompra == null) {
                    _LogicaDatosCompra = new LogicaDatosCompra();

                }
                return _LogicaDatosCompra;
            }
        }


        /*public List<DatosCompra> ListarCompra(DatosCompra dat, Cliente cli, Productos prod, FormaPago form, Monedas mon) {
            List<DatosCompra> DatosCompra = new List<DatosCompra>();

            using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
                conexion.Open();

                string query = "SELECT Nombre,Apellido FROM Cliente" +
                               "SELECT Fecha FROM DatosCompra" +
                               "SELECT Moneda FROM Monedas" +
                               "SELECT Nombre, PrecioVneta FROM Productos";


                SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                using (SQLiteDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        DatosCompra.Add(new DatosCompra() {
                             = reader.GetInt32(0),



                        });


                    }
                }






            }
        }*/



    }
}
