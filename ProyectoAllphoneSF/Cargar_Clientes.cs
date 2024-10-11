﻿using ProyectoAllphoneSF.LOGICA;
using ProyectoAllphoneSF.MODELO;
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


            comboBox_Producto.Items.Insert(0, "Seleccione un producto");
            comboBox_Producto.SelectedIndex = 0;

            comboBox_MedioPago.Items.Insert(0, "Selccionar Medio Pago");
            comboBox_MedioPago.SelectedIndex = 0;

            comboBox_Zona.Items.Insert(0, "Selecciona una Zona");
            comboBox_Zona.SelectedIndex = 0;

            comboBox_Moneda.Items.Insert(0, "Selecciona una Moneda");
            comboBox_Moneda.SelectedIndex = 0;
            GestionarComboBox();
        }


   


        private bool Validaciones() {
            bool respuesta = false;

            if (string.IsNullOrEmpty(textBox_Nombre.Text) || textBox_Nombre.Text.All(char.IsDigit)) {
                MessageBox.Show("Errora al ingresar Nombre","ADVERTENCIA",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Nombre.Clear();
                textBox_Nombre.Focus();
                return respuesta;
            }
            if (string.IsNullOrEmpty(textBox_Apellido.Text) || textBox_Apellido.Text.All(char.IsDigit)) {
                MessageBox.Show("Errora al ingresar Apellido", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Apellido.Clear();
                textBox_Apellido.Focus();
                return respuesta;
            }
            if (comboBox_Zona.SelectedIndex == 0) {
                MessageBox.Show("Errora al ingresar Zona", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return respuesta;
            }
            if (string.IsNullOrEmpty(textBox_Telefono.Text) || textBox_Telefono.Text.All(char.IsLetter)) {
                MessageBox.Show("Error al ingresar Telefono", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Telefono.Clear();
                textBox_Telefono.Focus();
                return respuesta;
            }
            if (string.IsNullOrEmpty(textBox_Email.Text) || textBox_Email.Text.IndexOf('@') == -1) {
                MessageBox.Show("Error al ingresar Email", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Email.Clear();
                textBox_Email.Focus();
                return respuesta;
            }
            if (comboBox_Producto.SelectedIndex == 0) {
                MessageBox.Show("Por favor seleccione un producto", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox_Producto.SelectedIndex = 0;
                comboBox_Producto.Focus();
                return respuesta;
            }
            if (comboBox_MedioPago.SelectedIndex == 0) {
                MessageBox.Show("Por favor seleccione un producto", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox_MedioPago.SelectedIndex = 0;
                comboBox_MedioPago.Focus();
                return respuesta;
            }





            return respuesta = true;
        }

        private void RestaurarInputs() {
            textBox_Nombre.Text = string.Empty;
            textBox_Apellido.Text = string.Empty;
            comboBox_Zona.SelectedIndex = 0;
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
                        MessageBox.Show("Datos Cargados con exito","FELICITACIONES😎",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
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

        private void panel1_Paint(object sender, PaintEventArgs e) {
            
        }

        private void GestionarComboBox() {

            comboBox_Zona.Items.Clear();
            comboBox_Producto.Items.Clear();
            comboBox_MedioPago.Items.Clear();
            comboBox_Moneda.Items.Clear();  

            foreach (Zonas zonas in LogicaZona.Instancia.ListarZonas()) {
                comboBox_Zona.Items.Add(zonas.Localidad);
            }
            //foreach (Productos prod in LogicaProducto.Instancia.ListarProducto()) { DA ERROR OJO TODAVIA NO TOCAR
                //comboBox_Producto.Items.Add(prod.Nombre);
            //}
            foreach (FormaPago pag in LogicaFormaPago.Instancia.ListarFormaPago()) {
                comboBox_MedioPago.Items.Add(pag.Metodopago);
            }
            foreach (Monedas mon in LogicaMoneda.Instancia.ListarMoneda()) {
                comboBox_Moneda.Items.Add(mon.MonedaName);
            }
        }
    }
}
