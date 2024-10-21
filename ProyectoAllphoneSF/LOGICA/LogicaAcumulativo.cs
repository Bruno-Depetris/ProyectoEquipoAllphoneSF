using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Configuration;
using System.Data.SqlClient;
using ProyectoAllphoneSF.MODELO;
using System.Reflection;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace ProyectoAllphoneSF.LOGICA {
    internal class LogicaAcumulativo {


        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;


        private static LogicaAcumulativo _LogicaAcumulativo;

        public LogicaAcumulativo() {

        }

        public static LogicaAcumulativo Instancia {
            get {
                if (_LogicaAcumulativo == null) {
                    _LogicaAcumulativo = new LogicaAcumulativo();

                }
                return _LogicaAcumulativo;

            }
        }

        public List<Acumulativos> ListarAcumulados() {

            List<Acumulativos> DatosAcumulados = new List<Acumulativos>();

            using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
                conexion.Open();

                string query = "SELECT AcumulativosID,TipoDelAcumulado,DatosAcumulado FROM Acumulativos";


                SQLiteCommand cmd = new SQLiteCommand(query, conexion);

                using (SQLiteDataReader reader = cmd.ExecuteReader()) {

                    while (reader.Read()) {

                        DatosAcumulados.Add(new Acumulativos() {

                            AcumulativosID = int.Parse(reader["AcumulativosID "].ToString()),
                            AcumulativosName = reader["TipoDelAcumulado "].ToString(),
                            AcumulativosAmount = decimal.Parse(reader["DatosAcumulado "].ToString()),

                        });

                    }

                    return DatosAcumulados;

                }
            }

        }



        public bool Acumular(Acumulativos acu) {
            DateTime obtenerFecha = DateTime.Now;
            string ViejoAcumulado = string.Empty;
            decimal NuevoMonto = 0;
            bool TipoDato = false;
            
            foreach (var item in ListarClienteCompra.Instancia.ListarComprasPorFecha(obtenerFecha)) {
                if (item.Moneda == acu.AcumulativosName) {
                    NuevoMonto = acu.AcumulativosAmount + item.TotalVenta;
                    ViejoAcumulado = acu.AcumulativosName;
                    TipoDato = true;
                }
            }

            if (!TipoDato) {
                using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
                    conexion.Open();
                    string query = "INSERT INTO Acumulativos (TipoDelAcumulado,DatosAcumulado) VALUES (@TipoDelAcumulado,@DatosAcumulado)";
                    SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                    cmd.Parameters.Add(new SQLiteParameter("@TipoDelAcumulado", acu.AcumulativosName));
                    cmd.Parameters.Add(new SQLiteParameter("@DatosAcumulado", acu.AcumulativosAmount));


                    if (cmd.ExecuteNonQuery() < 1) {
                        Console.WriteLine("Error al acumular un nuevo dato");
                        return false;
                    }
                    Console.WriteLine("Nuevo dato Acumulado Con exito");
                }

            } else if (TipoDato) {
                using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
                    conexion.Open();
                    string query = "UPDATE Acumulativos SET TipoDelAcumulado = @ViejoAcumulado, DatosAcumulado = @DatosAcumulado WHERE TipoDelAcumulado = @ViejoAcumulado ";
                    SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                    cmd.Parameters.Add(new SQLiteParameter("@ViejoAcumulado", ViejoAcumulado));
                    cmd.Parameters.Add(new SQLiteParameter("@DatosAcumulado", NuevoMonto));
                    if (cmd.ExecuteNonQuery() < 1) {
                        Console.WriteLine("Error al acumular un dato ya existente");
                        return false;
                    }
                    Console.WriteLine("Acumulado Existente actualizado Con exito");

                }
            }
            return true;
        }





























    }
}
