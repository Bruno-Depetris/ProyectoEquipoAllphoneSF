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

namespace ProyectoAllphoneSF {
    public partial class Stock : Form {
        public Stock() {

            InitializeComponent();
            

        }

        private void Stock_Load(object sender, EventArgs e) {

            MostrarDatos();

        }



        private void MostrarDatos() {

            dataGridView1.DataSource = null;

            var datos = ListarProducto.Instancia.ListaProductos();

            dataGridView1.DataSource = datos;

            AgregarColumnasBotones();
            ConfigurarColumnas();

        }
        private void btn_CargarNuevoProducto_Click(object sender, EventArgs e) {
            Form formNuevoProducto = new BtnNuevoProducto();
            formNuevoProducto.ShowDialog();
        }

        private void button_BuscarPorProducto_Click(object sender, EventArgs e) {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void ConfigurarColumnas() {
            // Configurar el orden de las columnas de botones para que estén al final
            dataGridView1.Columns["Edit"].DisplayIndex = 8;
            dataGridView1.Columns["Delete"].DisplayIndex = 8;
            //dataGridView1.Columns["Print"].DisplayIndex = 9;

            // Ajustar el tamaño de las columnas para que ocupen todo el ancho disponible
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Habilitar la opción de ordenar para todas las columnas
            foreach (DataGridViewColumn col in dataGridView1.Columns) {
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            // Ajustar la altura de las filas automáticamente
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;







        }
        private void AgregarColumnasBotones() {
            // Agregar la columna de Editar
            if (!dataGridView1.Columns.Contains("Edit")) {
                DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
                btnEdit.FlatStyle = FlatStyle.Flat;  // Estilo plano
                btnEdit.Name = "Edit";
                btnEdit.HeaderText = "Editar";
                btnEdit.Text = "Editar";
                btnEdit.UseColumnTextForButtonValue = true;

                // Quitar bordes del botón
                btnEdit.DefaultCellStyle.Padding = new Padding(0);  // Sin relleno extra
                btnEdit.DefaultCellStyle.Font = new Font("Nirmala UI", 11);  // Cambiar la fuente
                btnEdit.DefaultCellStyle.ForeColor = Color.White;  // Color del texto
                btnEdit.DefaultCellStyle.BackColor = Color.Green;  // Color de fondo

                // Cambiar el cursor a mano
                dataGridView1.Cursor = Cursors.Hand;

                // Agregar la columna al DataGridView
                dataGridView1.Columns.Add(btnEdit);
            }

            // Agregar la columna de Borrar
            if (!dataGridView1.Columns.Contains("Delete")) {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                btnDelete.FlatStyle = FlatStyle.Flat;  // Estilo plano
                btnDelete.Name = "Delete";
                btnDelete.HeaderText = "Borrar";
                btnDelete.Text = "Borrar";
                btnDelete.UseColumnTextForButtonValue = true;

                // Quitar bordes del botón
                btnDelete.DefaultCellStyle.Padding = new Padding(0);  // Sin relleno extra
                btnDelete.DefaultCellStyle.Font = new Font("Nirmala UI", 11);  // Cambiar la fuente
                btnDelete.DefaultCellStyle.ForeColor = Color.White;  // Color del texto
                btnDelete.DefaultCellStyle.BackColor = Color.DarkRed;  // Color de fondo

                // Cambiar el cursor a mano
                dataGridView1.Cursor = Cursors.Hand;

                // Agregar la columna al DataGridView
                dataGridView1.Columns.Add(btnDelete);

            }

           /* if (!dataGridView1.Columns.Contains("Print")) {
                DataGridViewButtonColumn btnImprimir = new DataGridViewButtonColumn();
                btnImprimir.FlatStyle = FlatStyle.Flat;
                btnImprimir.Name = "Print";
                btnImprimir.HeaderText = "Imprimir";
                btnImprimir.Text = "Imprimir";
                btnImprimir.UseColumnTextForButtonValue = true;

                // Quitar bordes del botón
                btnImprimir.DefaultCellStyle.Padding = new Padding(0);  // Sin relleno extra
                btnImprimir.DefaultCellStyle.Font = new Font("Nirmala UI", 11);  // Cambiar la fuente
                btnImprimir.DefaultCellStyle.ForeColor = Color.Black;  // Color del texto
                btnImprimir.DefaultCellStyle.BackColor = Color.AliceBlue;  // Color de fondo

                // Cambiar el cursor a mano
                dataGridView1.Cursor = Cursors.Hand;

                // Agregar la columna al DataGridView
                dataGridView1.Columns.Add(btnImprimir);

            }*/


        }
        private void EditarFila(int rowIndex) {

            var seleccionarRow = dataGridView1.Rows[rowIndex];

            var ProductoID = seleccionarRow.Cells[2].Value;
            var Nombre = seleccionarRow.Cells[3].Value;
            var TipoID = seleccionarRow.Cells[4].Value;
            var nombreTipo = seleccionarRow.Cells[5].Value;
            var PrecioCosto = seleccionarRow.Cells[6].Value;
            var PrecioVenta = seleccionarRow.Cells[7].Value;
            var Stock = seleccionarRow.Cells[8].Value;

            
            Productos prod = new Productos() {
                ProductoID = Convert.ToInt32(ProductoID), // Convertir a int si es un número
                Nombre = Nombre.ToString(),
                TipoID = Convert.ToInt32(TipoID),
                PrecioCosto = Convert.ToDecimal(PrecioCosto), // Convertir a decimal
                PrecioVenta = Convert.ToDecimal(PrecioVenta),
                Stock = Convert.ToInt32(Stock) // Convertir a int
                
            };

            bool estado = LogicaProducto.Instancia.EditarProducto(prod);

            if (estado) {
                List<Productos> EnviarLista = new List<Productos>();
                
                
            }

        }

        private void BorrarFila(int rowIndex) {
            var seleccionarRow = dataGridView1.Rows[rowIndex];

            var IDselected = seleccionarRow.Cells[2].Value; 
                                                            

            DialogResult result = MessageBox.Show("Seguro que desea borrar toda la fila?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes) {

                Productos prod = new Productos() {
                    ProductoID = IDselected.GetHashCode(),
                    
                };
                bool respuesta = LogicaProducto.Instancia.EliminarProducto(prod);

                if (respuesta) {
                    MessageBox.Show("Fila eliminada");

                    MostrarDatos();

                } else {
                    MessageBox.Show("Error al borrar");
                }
            } else if (result == DialogResult.No) {
                return;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) {

                string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

                switch (columnName) {
                   case "Edit":
                        EditarFila(e.RowIndex);

                        break;
                    case "Delete":
                        BorrarFila(e.RowIndex);

                        break;

                }
            }
        }
    }
}
