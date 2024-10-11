using ProyectoAllphoneSF.LOGICA;
using ProyectoAllphoneSF.MODELO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ProyectoAllphoneSF
{
    public partial class Configuraciones : Form {
        public Configuraciones() {
            InitializeComponent();
            CargarDatasGreed();
        }
        private void CargarDatasGreed() {
            dataGridView_Monedas.DataSource = null;
            dataGridView_MediosPago.DataSource = null;
            dataGridView_Seccion.DataSource = null;
            dataGridView_Zona.DataSource = null;
            
            var datosMoneda = LogicaMoneda.Instancia.ListarMoneda();
            var datosMP = LogicaFormaPago.Instancia.ListarFormaPago();
            var datosSecciones = LogicaTipoProducto.Instancia.ListarTipos();
            var datosZona = LogicaZona.Instancia.ListarZonas();

            dataGridView_Monedas.DataSource = datosMoneda;
            dataGridView_MediosPago.DataSource = datosMP;
            dataGridView_Seccion.DataSource = datosSecciones;
            dataGridView_Zona.DataSource = datosZona;

        }
        private void iconButton_Monedas_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(textBox_Monedas.Text) || textBox_Monedas.Text.All(char.IsDigit)) {
                MessageBox.Show("Error al ingresar las monedas", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Monedas.Focus();
                textBox_Monedas.Clear();
                return;

            }
            try {
                Monedas NuevaMoneda = new Monedas();

                NuevaMoneda.MonedaName = textBox_Monedas.Text;

                LogicaMoneda.Instancia.CargarMoneda(NuevaMoneda);

                MessageBox.Show("Moneda Cargada con exito", "FELICIDAD😎");
                textBox_Monedas.Focus();
                textBox_Monedas.Clear();
                CargarDatasGreed();


            } catch (Exception ex){
                MessageBox.Show($"Hubo algun error al cargar o mostrar{ex}", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        private void iconButton_MediosPago_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(textBox_MediosPago.Text) || textBox_MediosPago.Text.All(char.IsDigit)) {
                MessageBox.Show("Error al ingresar los medios de pago", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_MediosPago.Focus();
                textBox_MediosPago.Clear();
                return;

            }
            try {
                FormaPago NuevaFormaPago = new FormaPago();

                NuevaFormaPago.Metodopago = textBox_MediosPago.Text;
                NuevaFormaPago.Descuento = 12;

                LogicaFormaPago.Instancia.CargarFormaPago(NuevaFormaPago);

                MessageBox.Show("Forma de pago Cargada con exito", "FELICIDAD😎");
                textBox_MediosPago.Focus();
                textBox_MediosPago.Clear();
                CargarDatasGreed();




            } catch (Exception ex) {
                MessageBox.Show($"Hubo algun error al cargar o mostrar{ex}", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void iconButton_Secciones_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(textBox_Seccion.Text) || textBox_Seccion.Text.All(char.IsDigit)) {
                MessageBox.Show("Error al ingresar los tipos", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Seccion.Focus();
                textBox_Seccion.Clear();
                return;

            }
            try{

                TiposProductos nuevoTipo = new TiposProductos();

                nuevoTipo.NombreTipo = textBox_Seccion.Text;

                LogicaTipoProducto.Instancia.CargarTipoProducto(nuevoTipo);

                MessageBox.Show("Seccion Cargada con exito", "FELICIDAD😎");
                textBox_Seccion.Focus();
                textBox_Seccion.Clear();
                CargarDatasGreed();

            } catch(Exception ex) {
                MessageBox.Show($"Hubo algun error al cargar o mostrar{ex}", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void iconButton_Zonas_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(textBox_Zona.Text) || textBox_Zona.Text.All(char.IsDigit)) {
                MessageBox.Show("Error al ingresar las zonas", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Zona.Focus();
                textBox_Zona.Clear();
                return;

            }
            try {

                Zonas nuevaZona = new Zonas();

                nuevaZona.Localidad = textBox_Zona.Text;

                LogicaZona.Instancia.CargarZona(nuevaZona);

                MessageBox.Show("Zona Cargada con exito", "FELICIDAD😎");

                textBox_Zona.Focus();
                textBox_Zona.Clear();
                CargarDatasGreed();

            } catch (Exception ex) {
                MessageBox.Show($"Hubo algun error al cargar o mostrar{ex}", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
