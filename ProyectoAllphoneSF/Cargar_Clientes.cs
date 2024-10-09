using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoAllphoneSF {
    public partial class Cargar_Clientes : Form {
       

        public Cargar_Clientes()
        {
            InitializeComponent();
            RedondearBoton(btn_Registro, 7);
            RedondearBoton(btn_ConcretarVenta, 7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Accede al formulario principal y lo minimiza
            Form formularioPrincipal = Application.OpenForms[0]; // Asume que el formulario principal es el primero abierto
            formularioPrincipal.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Cargar_Clientes_Load(object sender, EventArgs e)
        {

        }

        //metodo para redondear botones
        public void RedondearBoton(Button boton, int radio)
        {
            // Asegurar que el radio no sea mayor que la mitad del tamaño del botón
            if (radio > boton.Height / 2 || radio > boton.Width / 2)
            {
                radio = Math.Min(boton.Height, boton.Width) / 2;
            }

            GraphicsPath path = new GraphicsPath();

            // Crear las esquinas redondeadas
            path.AddArc(new Rectangle(0, 0, radio, radio), 180, 90); // Esquina superior izquierda
            path.AddArc(new Rectangle(boton.Width - radio - 1, 0, radio, radio), 270, 90); // Esquina superior derecha
            path.AddArc(new Rectangle(boton.Width - radio - 1, boton.Height - radio - 1, radio, radio), 0, 90); // Esquina inferior derecha
            path.AddArc(new Rectangle(0, boton.Height - radio - 1, radio, radio), 90, 90); // Esquina inferior izquierda
            path.CloseFigure();

            // Asignar la región redondeada al botón
            boton.Region = new Region(path);
        }


        // Importar funciones de la API de Windows para mover la ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void Cargar_Clientes_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            // Enviar el mensaje para mover la ventana al formulario principal (ParentForm)
            SendMessage(this.ParentForm.Handle, 0x112, 0xf012, 0); // 0x112 = WM_SYSCOMMAND, 0xf012 = SC_MOVE + HTCAPTION
        }

        private void btn_ConcretarVenta_Click(object sender, EventArgs e)
        {

        }

        private void btn_Registro_Click(object sender, EventArgs e)
        {
            if (ValidarTextBox(textBox1) == true) { string nombe = textBox1.Text; }

            if (ValidarTextBox(textBox2) == true) { string apellido = textBox2.Text; }

            if (ValidarTextBox(textBox3) == true) { string direccion = textBox3.Text; }

            if (ValidarTextBox(textBox4) == true) { string tekefono = textBox4.Text; }

            if (ValidarTextBox(textBox6) == true) { string email = textBox6.Text; }
        }

        private bool ValidarTextBox(TextBox textBox)
        {
            int minLength = 1;
            int maxLength = 50;
            string invalidCharsPattern = @"[^a-zA-Z0-9 ]";

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show("El campo no puede estar vacío o contener solo espacios en blanco.");
                return false;
            }

            if (textBox.Text.Length < minLength || textBox.Text.Length > maxLength)
            {
                MessageBox.Show($"El campo debe tener entre {minLength} y {maxLength} caracteres.");
                return false;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, invalidCharsPattern))
            {
                MessageBox.Show("El campo contiene caracteres no permitidos.");
                return false;
            }

            return true;
        }
    }
}
