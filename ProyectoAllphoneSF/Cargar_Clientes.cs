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
            RedondearBoton(Button_Registro, 20);
            RedondearBoton(Button_ConcretarVenta, 20);

            comboBox_Producto.Items.Insert(0, "Seleccione un producto");
            comboBox_Producto.SelectedIndex = 0;

            comboBox_MedioPago.Items.Insert(0, "Selccionar Medio Pago");
            comboBox_MedioPago.SelectedIndex = 0;

        }


        #region Redondear Botones

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
        #endregion


        private bool Validaciones() {
            bool respuesta = false;

            if (string.IsNullOrEmpty(textBox_Nombre.Text) || textBox_Nombre.Text.All(char.IsDigit)) {
                MessageBox.Show("Errora al ingresar Nombre");
                textBox_Nombre.Clear();
                textBox_Nombre.Focus();
                return respuesta;
            }
            if (string.IsNullOrEmpty(textBox_Apellido.Text) || textBox_Apellido.Text.All(char.IsDigit)) {
                MessageBox.Show("Errora al ingresar Apellido");
                textBox_Apellido.Clear();
                textBox_Apellido.Focus();
                return respuesta;
            }
            if (string.IsNullOrEmpty(textBox_Direccion.Text) || textBox_Direccion.Text.All(char.IsDigit)) {
                MessageBox.Show("Errora al ingresar Direccion");
                textBox_Direccion.Clear();
                textBox_Direccion.Focus();
                return respuesta;
            }
            if (string.IsNullOrEmpty(textBox_Telefono.Text) || textBox_Telefono.Text.All(char.IsLetter)) {
                MessageBox.Show("Error al ingresar Telefono");
                textBox_Telefono.Clear();
                textBox_Telefono.Focus();
                return respuesta;
            }
            if (string.IsNullOrEmpty(textBox_Email.Text) || textBox_Email.Text.IndexOf('@') == -1) {
                MessageBox.Show("Error al ingresar Email");
                textBox_Email.Clear();
                textBox_Email.Focus();
                return respuesta;
            }
            if (comboBox_Producto.SelectedIndex == 0) {
                MessageBox.Show("Por favor seleccione un producto");
                comboBox_Producto.SelectedIndex = 0;
                comboBox_Producto.Focus();
                return respuesta;
            }
            if (comboBox_MedioPago.SelectedIndex == 0) {
                MessageBox.Show("Por favor seleccione un producto");
                comboBox_MedioPago.SelectedIndex = 0;
                comboBox_MedioPago.Focus();
                return respuesta;
            }





            return respuesta = true;
        }

        private void RestaurarInputs() {
            textBox_Nombre.Text = string.Empty;
            textBox_Apellido.Text = string.Empty;
            textBox_Direccion.Text = string.Empty;
            textBox_Email.Text = string.Empty;
            textBox_Telefono.Text = string.Empty;
            comboBox_MedioPago.SelectedIndex = 0;
            comboBox_Producto.SelectedIndex = 0;
        }
        private void Button_ConcretarVenta_Click(object sender, EventArgs e) {
            if (Validaciones()) {
                DialogResult resultado = MessageBox.Show("Desea cargar esta compra?","ADVERTENCIA",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes) {
                    try {
                        MessageBox.Show("Datos Cargados con exito");
                        RestaurarInputs();
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message); 
                    }

                }
                if (resultado == DialogResult.No) {
                    return;
                }
            }
        }
    }
}
