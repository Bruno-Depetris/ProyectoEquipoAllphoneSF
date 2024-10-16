using ProyectoAllphoneSF.MODELO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAllphoneSF.LOGICA
{
    internal class LogicaFormaPago
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        private static LogicaFormaPago _LogicaFormaPago;

        public LogicaFormaPago()
        {

        }

        public static LogicaFormaPago Instancia
        {
            get
            {
                if (_LogicaFormaPago == null)
                {
                    _LogicaFormaPago = new LogicaFormaPago();

                }
                return _LogicaFormaPago;
            }
        }

        public bool CargarFormaPago(FormaPago forma)
        {
            bool respuesta = false;


            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();


                string query = "INSERT INTO FormaPago (MetodoPago,Descuento) VALUES (@MetodoPago,@Descuento)";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                cmd.Parameters.Add(new SQLiteParameter("@MetodoPago",forma.Metodopago));
                cmd.Parameters.Add(new SQLiteParameter("@Descuento", forma.TasaInteres));

                if (cmd.ExecuteNonQuery() < 1)
                {
                    Console.WriteLine("Error al guardar una forma de pago");
                    return respuesta;
                }
                Console.WriteLine("Forma de pago guardada con exito");
            }

            return respuesta = true;
        }
        public bool EliminarFormaPago(FormaPago forma)
        {
            bool respuesta = false;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();


                string query = "DELETE FROM FormaPago WHERE FormaPagoID = @FormaPagoID";



                SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                cmd.Parameters.Add(new SQLiteParameter("@FormaPagoID", forma.FormaPagoID));
                

                if (cmd.ExecuteNonQuery() < 1)
                {
                    Console.WriteLine("Error al borrar FormaPago");
                    return respuesta;
                }

                Console.WriteLine("Forma de Pago Eliminada Con exito");
            }
            return respuesta = true;
        }
     
        public List<FormaPago> ListarFormaPago()
        {

            List<FormaPago> DatosFormaPago = new List<FormaPago>();

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();

                string query = "SELECT FormaPagoID,MetodoPago,Descuento FROM FormaPago";


                SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {

                        DatosFormaPago.Add(new FormaPago()
                        {

                            FormaPagoID = int.Parse(reader["FormaPagoID"].ToString()),
                            Metodopago = reader["MetodoPago"].ToString(),
                            TasaInteres = decimal.Parse(reader["Descuento"].ToString()),
                        });

                    }

                    return DatosFormaPago;

                }
            }
        }

    }
}

