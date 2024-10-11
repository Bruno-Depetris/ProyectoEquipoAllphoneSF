using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Net;
using System.Net.Mail;
using System.Windows.Media;



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
                label_EstadoBaseDatos.ForeColor = System.Drawing.Color.Green;
            } else {
                label_EstadoBaseDatos.Text = "Desconectada";
                label_EstadoBaseDatos.ForeColor = System.Drawing.Color.Red;
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
        private Button ultimoBotonSeleccionado;
        private void SeguirSeleccion(Button botonSeleccionado) {

            if (ultimoBotonSeleccionado != null && ultimoBotonSeleccionado != botonSeleccionado) {
                ultimoBotonSeleccionado.BackColor = System.Drawing.Color.FromArgb(25,25,25); // Color original del botón
                ultimoBotonSeleccionado.ForeColor = System.Drawing.Color.White; // Color original del texto
            }

            panel_SeguirSeleccion.Visible = true;
            panel_SeguirSeleccion.Height = botonSeleccionado.Height;
            panel_SeguirSeleccion.Top = botonSeleccionado.Top;
            panel_SeguirSeleccion.Left = botonSeleccionado.Left;

            

            botonSeleccionado.BackColor = System.Drawing.Color.FromArgb(41,41,41); //Nuevo color dle boton 
            botonSeleccionado.ForeColor = System.Drawing.Color.FromArgb(218, 191, 236); // Nuevo color del texto

            ultimoBotonSeleccionado = botonSeleccionado;

        }

        private void pictureBox_LogoNegocio_Click(object sender, EventArgs e) {
            AbrirFormNuevo(new DashBoard());
            panel_SeguirSeleccion.Visible = false;
            ultimoBotonSeleccionado.BackColor = System.Drawing.Color.FromArgb(25, 25, 25); // Color original del botón
            ultimoBotonSeleccionado.ForeColor = System.Drawing.Color.White; // Color original del texto
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
    

        }

        private void HoraFecha_Tick(object sender, EventArgs e) {
            label_Hora.Text = DateTime.Now.ToLongTimeString();
            label_Fecha.Text = DateTime.Now.ToShortDateString();
        }

        private void button_CrearBackup_Click(object sender, EventArgs e) {
            SeguirSeleccion(button_CrearBackup);
            AbrirFormNuevo(new MovimientoCaja());
        }

        private void button_Configuracion_Click(object sender, EventArgs e) {
            SeguirSeleccion(button_Configuracion);
            AbrirFormNuevo(new Configuraciones());
        }
    }
}
