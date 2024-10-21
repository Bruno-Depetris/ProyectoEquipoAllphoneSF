using ProyectoAllphoneSF.LOGICA;
using ProyectoAllphoneSF.MODELO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
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


            
            AgregarColumnasBotones(dataGridView_Monedas);
            ConfigurarColumnas(dataGridView_Monedas);

            
            AgregarColumnasBotones(dataGridView_MediosPago);
            ConfigurarColumnas(dataGridView_MediosPago);

            
            AgregarColumnasBotones(dataGridView_Seccion);
            ConfigurarColumnas(dataGridView_Seccion);

            AgregarColumnasBotones(dataGridView_Zona);
            ConfigurarColumnas(dataGridView_Zona);



        }

        private void AgregarColumnasBotones(DataGridView DatosGrid) {
            // Agregar la columna de Editar
            if (!DatosGrid.Columns.Contains("Delete")) {
                DataGridViewButtonColumn ButtonDelete = new DataGridViewButtonColumn();
                ButtonDelete.FlatStyle = FlatStyle.Flat;
                ButtonDelete.Name = "Delete";
                ButtonDelete.HeaderText = "Borrar";
                ButtonDelete.Text = "Borrar";
                ButtonDelete.UseColumnTextForButtonValue = true;

                ButtonDelete.DisplayIndex = 0;
                Console.WriteLine(ButtonDelete.DisplayIndex);
                ButtonDelete.DefaultCellStyle.Padding = new Padding(0);
                ButtonDelete.DefaultCellStyle.Font = new Font("Nirmala UI", 11);
                ButtonDelete.DefaultCellStyle.ForeColor = Color.White;
                ButtonDelete.DefaultCellStyle.BackColor = Color.Red;


                DatosGrid.Cursor = Cursors.Hand;


                DatosGrid.Columns.Add(ButtonDelete);
            }
        
        }
        private void ConfigurarColumnas(DataGridView DatosGrid) {
            
            DatosGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn col in DatosGrid.Columns) {
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            DatosGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }


        private void BorrarFila(int rowIndex,DataGridView TablaDatos) {
            var seleccionarRow = TablaDatos.Rows[rowIndex];

            var IDselected = seleccionarRow.Cells[1].Value;

            DialogResult result = MessageBox.Show("Seguro que desea borrar toda la fila?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes) {
                bool respuesta = false;

                if (TablaDatos == dataGridView_Monedas) {
                    Monedas mon = new Monedas() {
                        MonedaID = IDselected.GetHashCode(),
                    };

                    respuesta = LogicaMoneda.Instancia.EliminarMoneda(mon);
                }
                if (TablaDatos == dataGridView_MediosPago) {
                    FormaPago mon = new FormaPago() {
                        FormaPagoID = IDselected.GetHashCode(),
                    };

                    respuesta = LogicaFormaPago.Instancia.EliminarFormaPago(mon);
                }
                if (TablaDatos == dataGridView_Seccion) {
                    TiposProductos mon = new TiposProductos() {
                        TipoID = IDselected.GetHashCode(),
                    };

                    respuesta = LogicaTipoProducto.Instancia.EliminarTipoProducto(mon);
                }
                if (TablaDatos == dataGridView_Zona) {
                    Zonas mon = new Zonas() {
                        ZonaID = IDselected.GetHashCode(),
                    };

                    respuesta = LogicaZona.Instancia.BorrarZonas(mon);
                }


                if (respuesta) {
                    MessageBox.Show("Fila eliminada");

                    CargarDatasGreed();

                } else {
                    MessageBox.Show("Error al borrar");
                }
            } else if (result == DialogResult.No) {
                return;
            }
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


                CargarDatasGreed();

                textBox_Monedas.Focus();
                textBox_Monedas.Clear();
                


            } catch (Exception ex){
                MessageBox.Show($"Hubo algun error al cargar o mostrar{ex}", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            

        }
        private void dataGridView_Monedas_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) {
                string columnName = dataGridView_Monedas.Columns[e.ColumnIndex].Name;

                if (columnName == "Delete") {
                    BorrarFila(e.RowIndex, dataGridView_Monedas);
                }
            }
        }



        decimal tasaInteres;
        private void iconButton_MediosPago_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(textBox_MediosPago.Text) || textBox_MediosPago.Text.All(char.IsDigit)) {
                MessageBox.Show("Error al ingresar los medios de pago", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_MediosPago.Focus();
                textBox_MediosPago.Clear();
                return;

            }
            if (decimal.TryParse(textBox_TasaInteres.Text.Replace(",","."),
                System.Globalization.NumberStyles.Any,
                 System.Globalization.CultureInfo.InvariantCulture,
                 out tasaInteres)) {

            }
            try {
                FormaPago NuevaFormaPago = new FormaPago();

                NuevaFormaPago.Metodopago = textBox_MediosPago.Text;
                NuevaFormaPago.TasaInteres = tasaInteres;

                LogicaFormaPago.Instancia.CargarFormaPago(NuevaFormaPago);

                MessageBox.Show("Forma de pago Cargada con exito", "FELICIDAD😎");
                textBox_MediosPago.Focus();
                textBox_MediosPago.Clear();
                CargarDatasGreed();




            } catch (Exception ex) {
                MessageBox.Show($"Hubo algun error al cargar o mostrar{ex}", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void dataGridView_MediosPago_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) {
                string columnName = dataGridView_MediosPago.Columns[e.ColumnIndex].Name;

                if (columnName == "Delete") {
                    BorrarFila(e.RowIndex, dataGridView_MediosPago);
                }
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
        private void dataGridView_Seccion_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) {
                string columnName = dataGridView_Seccion.Columns[e.ColumnIndex].Name;

                if (columnName == "Delete") {
                    BorrarFila(e.RowIndex, dataGridView_Seccion);
                }
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

        private void dataGridView_Zona_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) {
                string columnName = dataGridView_Zona.Columns[e.ColumnIndex].Name;

                if (columnName == "Delete") {
                    BorrarFila(e.RowIndex, dataGridView_Zona);
                }
            }
        }

        private void Configuraciones_Load(object sender, EventArgs e) {
            CargarDatasGreed();
        }


    }
}
