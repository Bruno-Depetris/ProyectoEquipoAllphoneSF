using ProyectoAllphoneSF.LOGICA;
using ProyectoAllphoneSF.MODELO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoAllphoneSF
{
    public partial class BtnNuevoProducto : Form
    {
        public BtnNuevoProducto()
        {
            InitializeComponent();
            comboBox_Tipo.Items.Insert(0, "Seleccine una seccion");
            comboBox_Tipo.SelectedIndex = 0;
            GestionarComboBox();
            
        }

        int IDSeleccionado = 0;
        decimal PrecioCosto;
        decimal PrecioVenta;
        private bool Validaciones() {
            bool respuesta = false;

            if (string.IsNullOrEmpty(textBox_Nombre.Text) || textBox_Nombre.Text.All(char.IsDigit)) {
                MessageBox.Show("Error al ingresar nombre del producto","ADVERTENCIA",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                textBox_Nombre.Focus();
                textBox_Nombre.Clear();
                return respuesta;
            }
            if (comboBox_Tipo.SelectedIndex == 0) {
                MessageBox.Show("Error al ingresar una seccion", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return respuesta;
            }
            if (decimal.TryParse(textBox_PrecioCosto.Text.Replace(",", "."),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out PrecioCosto)) {

            } else {
                textBox_PrecioCosto.Clear();
                textBox_PrecioCosto.Focus();

                MessageBox.Show("Error al ingresar Precio Costo", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return respuesta;
            }
            if (decimal.TryParse(textBox_PrecioVenta.Text.Replace(",", "."),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out PrecioVenta)) {

            } else {
                textBox_PrecioVenta.Clear();
                textBox_PrecioVenta.Focus();

                MessageBox.Show("Error al ingresar Precio venta", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return respuesta;
            }

            if (textBox_Cantidad.Text.All(char.IsLetter) || int.Parse(textBox_Cantidad.Text) < 1) {
                textBox_Cantidad.Clear();
                textBox_Cantidad.Focus();

                MessageBox.Show("Error al ingresar la cantidad", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return respuesta;
            }

            return respuesta = true;
        }
        private void Restaurar() {
            textBox_Nombre.Clear();
            textBox_Nombre.Clear();
            textBox_PrecioCosto.Clear();
            textBox_PrecioVenta.Clear();
            textBox_Cantidad.Clear();

        }
        private void button_Salir_Click(object sender, EventArgs e) {
            this.Close();
        } 
        private void GestionarComboBox() {

            comboBox_Tipo.Items.Clear();
            comboBox_Tipo.Items.Insert(0, "Seleccine una seccion");
            comboBox_Tipo.SelectedIndex = 0;
            

            foreach (TiposProductos tipo in LogicaTipoProducto.Instancia.ListarTipos()) {
                comboBox_Tipo.Items.Add(tipo.NombreTipo);
               
            }
            

        }
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
        private void button_CargarNuevoProducto_Click(object sender, EventArgs e)
        {
            RedondearBoton(button_CargarNuevoProducto, 8);
            if (Validaciones()) {
                DialogResult resultado = MessageBox.Show("Desea cargar este producto?","ADVERTENCIA",MessageBoxButtons.YesNo,MessageBoxIcon.Stop);

                if (resultado == DialogResult.Yes) {
                    try {
                        Productos NuevoProducto = new Productos();

                        NuevoProducto.Nombre = textBox_Nombre.Text;
                        NuevoProducto.TipoID = IDSeleccionado;
                        NuevoProducto.PrecioCosto = PrecioCosto;
                        NuevoProducto.PrecioVenta = PrecioVenta;
                        NuevoProducto.Stock = int.Parse(textBox_Cantidad.Text);

                        bool Estado = LogicaProducto.Instancia.cargarProducto(NuevoProducto);

                        if (Estado) {
                            MessageBox.Show("Producto cargado", "EXITOS 🥵", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Restaurar();
                        } else {
                            MessageBox.Show("Error al cargar Productos", "EXITOS 🥺😭😭", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        


                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                } else {
                    resultado = DialogResult.Cancel;
                }
            }
        }       
        private void comboBox_Tipo_SelectedIndexChanged(object sender, EventArgs e) {

            foreach (TiposProductos tipo in LogicaTipoProducto.Instancia.ListarTipos()) {
                if (comboBox_Tipo.Text.Contains(tipo.NombreTipo)) {
                    IDSeleccionado = tipo.TipoID;
                    Console.WriteLine("ID SELCCIONADO:" + IDSeleccionado);
                }
            }
        }


    }
}
