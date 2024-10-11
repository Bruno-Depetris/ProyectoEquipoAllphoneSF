using ProyectoAllphoneSF.LOGICA;
using ProyectoAllphoneSF.MODELO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

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
        private void BtnNuevoProducto_Load(object sender, EventArgs e) {

        }

        private void button_Salir_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void button_CargarNuevoProducto_Click(object sender, EventArgs e) {
            if (Validaciones()) {
                DialogResult resultado = MessageBox.Show("Desea cargar este producto?","ADVERTENCIA",MessageBoxButtons.YesNo,MessageBoxIcon.Stop);

                if (resultado == DialogResult.Yes) {
                    try {

                        Productos NuevoProducto = new Productos();
                        NuevoProducto.Nombre = textBox_Nombre.Text;
                        NuevoProducto.TipoID = comboBox_Tipo.SelectedIndex;
                        NuevoProducto.PrecioCosto = PrecioCosto;
                        NuevoProducto.PrecioVenta = PrecioVenta;


                        bool Estado = LogicaProducto.Instancia.cargarProducto(NuevoProducto);

                        if (Estado) {
                            MessageBox.Show("Producto cargado", "EXITOS", MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }



                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                } else {
                    this.Close();
                }
            }
        }
    }
}
