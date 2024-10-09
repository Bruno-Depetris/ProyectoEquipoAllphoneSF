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
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;


namespace ProyectoAllphoneSF {
    public partial class DashBoard : Form {
        
        public DashBoard()
        {
            InitializeComponent();
            CrearGraficoDona();
        }

        // Métodos para permitir arrastrar la ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture(); // Importa función de la API para liberar la captura del mouse
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam); // Importa función para enviar mensajes al sistema

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario de inicio
            Form formInicio = new DashBoard(); // Reemplaza 'Inicio' con el nombre de tu formulario de inicio

            // Llama al método para abrir el formulario hijo
            AbrirFormHija(formInicio);
            panel2.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Lógica para button4
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form MovimientoCaja = new MovimientoCaja(); // Crea una instancia del formulario Productos
            panel1.BringToFront();
            panel_Contenedor.SendToBack();

            // Asegúrate de que la instancia de formProductos no sea null
            if (MovimientoCaja == null)
            {
                MessageBox.Show("No se pudo crear el formulario Productos.");
                return; // Sale del método
            }
            panel2.Visible = false;

            AbrirFormHija(MovimientoCaja); // Llama al método para abrir el formulario hijo
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form formGestionar_Stock = new Stock(); // Crea una instancia del formulario Productos
            panel1.BringToFront();
            panel_Contenedor.SendToBack();

            // Asegúrate de que la instancia de formProductos no sea null
            if (formGestionar_Stock == null)
            {
                MessageBox.Show("No se pudo crear el formulario Productos.");
                return; // Sale del método
            }

            AbrirFormHija(formGestionar_Stock); // Llama al método para abrir el formulario hijo
            panel2.Visible = false;
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            // Lógica para panel9
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void CrearGraficoDona()
        {

            // Crear una nueva serie de datos
            Series series = new Series("Datos");

            // Definir el tipo de gráfico (Dona)
            series.ChartType = SeriesChartType.Doughnut;

            // Agregar datos de ejemplo (enteros)
            series.Points.AddXY("", 30);
            series.Points.AddXY("", 20);
            series.Points.AddXY("", 25);
            series.Points.AddXY("", 15);
            series.Points.AddXY("", 10);

            // Agregar la serie al gráfico
            chart1.Series.Clear();  // Limpiar las series previas si existen
            chart1.Series.Add(series);

            // Opcional: Personalizar el gráfico
            chart1.Titles.Add("Gráfico de Dona");
            chart1.Legends.Add(new Legend("Leyenda"));
            chart1.Legends["Leyenda"].Docking = Docking.Bottom;  // Colocar la leyenda en la parte inferior
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            // Lógica para chart1
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AbrirFormHija(Form formhija)
        {
            try
            {
                panel1.Visible = true;

                // Verifica si el formulario hijo es nulo
                if (formhija == null)
                {
                    MessageBox.Show("Error: El formulario hijo no se pudo crear (es null).");
                    return; // Sale del método si es nulo
                }

                // Verifica si el panel donde se abrirá el formulario es nulo
                if (this.panel_Contenedor == null)
                {
                    MessageBox.Show("Error: El panel no está inicializado.");
                    return; // Sale del método si el panel es nulo
                }

                // Elimina y cierra el formulario anterior si existe
                if (this.panel_Contenedor.Controls.Count > 0)
                {
                    Form formularioAnterior = this.panel_Contenedor.Controls[0] as Form;

                    if (formularioAnterior != null)
                    {
                        formularioAnterior.Close(); // Cierra el formulario hijo anterior
                    }
                    this.panel_Contenedor.Controls.Clear(); // Limpia el panel
                }

                // Configuración del formulario hijo
                formhija.TopLevel = false; // Indica que el formulario no es de nivel superior
                formhija.FormBorderStyle = FormBorderStyle.None; // Elimina el borde del formulario
                formhija.Dock = DockStyle.Fill; // Ajusta el tamaño del formulario hijo al tamaño del panel
                this.panel_Contenedor.Controls.Add(formhija); // Agrega el formulario hijo al panel
                this.panel_Contenedor.Tag = formhija; // Guarda el formulario hijo en el Tag del panel
                formhija.Show(); // Muestra el formulario hijo
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Se produjo un error de referencia nula: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error inesperado: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form formCargar_Clientes = new Cargar_Clientes(); // Crea una instancia del formulario Productos
            panel1.BringToFront();
            panel_Contenedor.SendToBack();

            // Asegúrate de que la instancia de formProductos no sea null
            if (formCargar_Clientes == null)
            {
                MessageBox.Show("No se pudo crear el formulario Productos.");
                return; // Sale del método
            }

            AbrirFormHija(formCargar_Clientes); // Llama al método para abrir el formulario hijo
            panel2.Visible = false;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture(); // Libera la captura del mouse
            SendMessage(this.Handle, 0x112, 0xf012, 0); // Envía un mensaje para mover la ventana
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
            panel_Contenedor.SendToBack();

            if (new Estadisticas() == null)
            {
                MessageBox.Show("No se pudo crear el formulario Productos.");
                return;
            }
            AbrirFormHija(new Estadisticas());
            panel2.Visible = true;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
