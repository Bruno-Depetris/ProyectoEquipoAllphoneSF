using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SQLite;

using System.Windows.Forms;
using System.Drawing.Text;

namespace ProyectoAllphoneSF {
    public partial class DashBoard : Form {
        public DashBoard() {
            InitializeComponent();

        }
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        public bool PruebaConexion() {
            bool respuesta = false;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
                try {
                    conexion.Open();
                    respuesta = true;
                } catch (Exception ex) {
                    
                    Console.WriteLine("Error al conectar con la base de datos: " + ex.Message);
                    respuesta = false;  
                } 
            }

            return respuesta;
        }
    
    private void Form1_Load(object sender, EventArgs e)
        {
            if (PruebaConexion()) {
                label_EstadoBaseDatos.Text = "Conectada";
                label_EstadoBaseDatos.ForeColor = System.Drawing.Color.Green;
            } else {
                label_EstadoBaseDatos.Text = "Desconectada";
                label_EstadoBaseDatos.ForeColor = System.Drawing.Color.Red;
            }


        }
    }
}
