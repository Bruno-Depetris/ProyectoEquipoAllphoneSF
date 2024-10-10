using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace ProyectoAllphoneSF {
    public partial class FormContenedor : Form {
        public FormContenedor() {
            InitializeComponent();
            AbrirFormNuevo(new DashBoard());
            panel_SeguirSeleccion.Visible = false;
        }
        private static readonly string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private bool ComprobarConexion() {
            bool respuesta = false;
            try {
                SQLiteConnection conexion = new SQLiteConnection(cadena);
                conexion.Open();

                respuesta = true;

                conexion.Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                respuesta=false;
            }

            
            return respuesta;

        }
        private void FormContenedor_Load(object sender, EventArgs e) {
            if (ComprobarConexion()) {
                label_EstadoBaseDatos.Text = "Conectada";
                label_EstadoBaseDatos.ForeColor = Color.Green;
            } else {
                label_EstadoBaseDatos.Text = "Desconectada";
                label_EstadoBaseDatos.ForeColor = Color.Red;
            }
        }


        private Form FromActivo = null;
        private void AbrirFormNuevo(Form FormHijo) {
            if (FromActivo != null) {
                FromActivo.Close();
            }
            FromActivo = FormHijo;
            FormHijo.TopLevel = false;
            FormHijo.FormBorderStyle = FormBorderStyle.None;
            FormHijo.Dock = DockStyle.Fill;

            panel_ContenedorMain.Controls.Add(FormHijo);
            panel_ContenedorMain.Tag = FormHijo;

            FormHijo.Show();
        }

        private void SeguirSeleccion(Button botonSeleccionado) {
            panel_SeguirSeleccion.Visible = true;
            panel_SeguirSeleccion.Height = botonSeleccionado.Height;
            panel_SeguirSeleccion.Top = botonSeleccionado.Top;
            panel_SeguirSeleccion.Left = botonSeleccionado.Left;

        }

        private void pictureBox_LogoNegocio_Click(object sender, EventArgs e) {
            AbrirFormNuevo(new DashBoard());
            panel_SeguirSeleccion.Visible = false;
        }
        private void Button_CargarCliente_Click(object sender, EventArgs e) {
            SeguirSeleccion(Button_CargarCliente);
            AbrirFormNuevo(new Cargar_Clientes());

        }

        private void ButtonGestionarStock_Click(object sender, EventArgs e) {
            AbrirFormNuevo(new Stock());
            SeguirSeleccion(ButtonGestionarStock);
        }

        private void Button_MovimientosCaja_Click(object sender, EventArgs e) {
            SeguirSeleccion(Button_MovimientosCaja);
            AbrirFormNuevo(new MovimientoCaja());
        }

        private void Button_Estadistica_Click(object sender, EventArgs e) {
            SeguirSeleccion(Button_Estadistica);
            AbrirFormNuevo(new Estadisticas());
        }


    }
}
