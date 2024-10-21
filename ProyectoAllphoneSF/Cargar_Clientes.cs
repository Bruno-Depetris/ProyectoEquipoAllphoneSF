using ProyectoAllphoneSF.LOGICA;
using ProyectoAllphoneSF.MODELO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
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
            #region configuracion combo box

            comboBox_CantCuotas.Items.Insert(0, "Selecciona cant Cuotas");
            comboBox_CantCuotas.Items.Insert(1, "0");
            comboBox_CantCuotas.Items.Insert(2, "1");
            comboBox_CantCuotas.Items.Insert(3, "2");
            comboBox_CantCuotas.Items.Insert(4, "3");
            comboBox_CantCuotas.Items.Insert(5, "4");
            comboBox_CantCuotas.Items.Insert(6, "5");
            comboBox_CantCuotas.Items.Insert(7, "6");
            comboBox_CantCuotas.Items.Insert(8, "7");
            comboBox_CantCuotas.Items.Insert(9, "8");
            comboBox_CantCuotas.Items.Insert(10, "9");
            comboBox_CantCuotas.Items.Insert(11, "10");
            comboBox_CantCuotas.Items.Insert(12, "11");
            comboBox_CantCuotas.Items.Insert(13, "12");
            comboBox_CantCuotas.SelectedIndex = 0;




            comboBox_Cantidad.Items.Insert(0, "Selecciona Cantidad");
            comboBox_Cantidad.Items.Insert(1, "0");
            comboBox_Cantidad.Items.Insert(2, "1");
            comboBox_Cantidad.Items.Insert(3, "2");
            comboBox_Cantidad.Items.Insert(4, "3");
            comboBox_Cantidad.Items.Insert(5, "4");
            comboBox_Cantidad.Items.Insert(6, "5");
            comboBox_Cantidad.Items.Insert(7, "6");
            comboBox_Cantidad.Items.Insert(8, "7");
            comboBox_Cantidad.Items.Insert(9, "8");
            comboBox_Cantidad.Items.Insert(10, "9");
            comboBox_Cantidad.Items.Insert(11, "10");
            comboBox_Cantidad.Items.Insert(12, "11");
            comboBox_Cantidad.Items.Insert(13, "12");
            comboBox_Cantidad.SelectedIndex = 0;

            #endregion
            GestionarComboBox();
            MostrarDatos();
        }

        #region Creacion de variables
        DateTime fechaSeleccionada = DateTime.Now;
        decimal CotizacionMoneda;
        int idZonaSeleccionada;
        int idProductoSeleccionado;
        int idMonedaSeleccionada;
        int idMedioPagoSeleccionado;
        decimal tasaInteres;
        decimal precioProducto;
        int cantidad;
        int restoStock = 0;
        int cuotas = 0;
        #endregion
        private bool Validaciones() {
            bool respuesta = false;

            if (int.TryParse(comboBox_Cantidad.Text, out cantidad)) {

            } else {

                MessageBox.Show("Por favor, ingrese una cantidad válida.");
            }
            if (string.IsNullOrEmpty(textBox_Nombre.Text) || textBox_Nombre.Text.All(char.IsDigit)) {
                MessageBox.Show("Errora al ingresar Nombre", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (decimal.TryParse(textBox_Cotizacion.Text.Replace(",", "."),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out CotizacionMoneda)){

            } else {
                MessageBox.Show("Por favor coloque una cotizacion", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Cotizacion.Clear();
                textBox_Cotizacion.Focus();
                return respuesta;
            }
            if (string.IsNullOrEmpty(textBox_Direccion.Text)){
                MessageBox.Show("Error al ingresar Direccion", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Direccion.Clear();
                textBox_Direccion.Focus();
                return respuesta ;
            }

            return respuesta = true;
        }

        private void MostrarDatos() {
            dataGridView1.DataSource = null;

            //var dato = ListarClienteCompra.Instancia.ListarCompras();

            
            
            List<ListarCompra> comprasFiltradas = ListarClienteCompra.Instancia.ListarComprasPorFecha (fechaSeleccionada);

            dataGridView1.DataSource = comprasFiltradas;

            AgregarColumnasBotones();
            ConfigurarColumnas();

        }
        private bool GestionarNuevaCompra() {
            bool respuesta = false;
       
            try {
                
                DatosCompra nuevaCompra = new DatosCompra();
                Productos productos = new Productos();

                foreach (ProductoConTipo item in ListarProducto.Instancia.ListaProductos()) {

                    if (item.ProductoID == idProductoSeleccionado) {
                        restoStock = item.Stock - cantidad;

                        productos.ProductoID = item.ProductoID;
                        productos.Nombre = item.Nombre;
                        productos.TipoID = item.TipoID;
                        productos.PrecioCosto = item.PrecioCosto;
                        productos.PrecioVenta = item.PrecioVenta;
                        productos.Stock = restoStock;

                        Console.WriteLine($"{productos.ProductoID},{productos.Nombre},{productos.TipoID},{productos.PrecioCosto},{productos.PrecioVenta},{productos.Stock}");

                        bool re = LogicaProducto.Instancia.EditarProducto(productos);

                        if (re) {
                            Console.WriteLine("PRODUCTO ACTUALIZADO CON ÉXITO");
                        }
                    }
                }


                int clienteID = 0;

                var datos = LogicaCliente.Instancia.ListarCliente();

                foreach (Cliente item in datos) {
                    if (nuevaCompra.ClienteID != item.ClienteID) {
                        clienteID = item.ClienteID;
                    }
                }

                nuevaCompra.ClienteID = clienteID;
                nuevaCompra.ProductoID = idProductoSeleccionado;
                nuevaCompra.FormaPagoID = idMedioPagoSeleccionado;
                nuevaCompra.Fecha = DateTime.Now;
                nuevaCompra.MonedaID = idMonedaSeleccionada;
                nuevaCompra.Cantidad = cantidad;
                nuevaCompra.TotalVenta = ((precioProducto * cantidad) * CotizacionMoneda) * (1 + tasaInteres / 100);
                nuevaCompra.Cuotas = cuotas;
                
                

                 LogicaDatosCompra.Instancia.CargarCompra(nuevaCompra);
                
                return respuesta = true;
                
               

            } catch {
                return respuesta;
            }


        }
        private void RestaurarInputs() {
            textBox_Nombre.Text = string.Empty;
            textBox_Apellido.Text = string.Empty;
            comboBox_Zona.SelectedIndex = 0;
            textBox_Email.Text = string.Empty;
            textBox_Telefono.Text = string.Empty;
            comboBox_MedioPago.SelectedIndex = 0;
            comboBox_Producto.SelectedIndex = 0;
            textBox_Cotizacion.SelectedText = string.Empty;
            comboBox_CantCuotas.SelectedIndex = 0;
        }
        private void Button_ConcretarVenta_Click(object sender, EventArgs e) {
            if (Validaciones()) {
                DialogResult resultado = MessageBox.Show("Desea cargar esta compra?","ADVERTENCIA",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes) {
                    try {
                        Cliente nuevoCliente = new Cliente();
                        
                        nuevoCliente.Nombre = textBox_Nombre.Text;
                        nuevoCliente.Apellido = textBox_Apellido.Text;
                        nuevoCliente.Telefono = textBox_Telefono.Text;
                        nuevoCliente.Email = textBox_Email.Text;
                        nuevoCliente.Direccion = textBox_Direccion.Text;
                        nuevoCliente.ZonaID = idZonaSeleccionada;

                        bool respuesta = LogicaCliente.Instancia.CargarCliente(nuevoCliente);
                       
                        if (respuesta && GestionarNuevaCompra() == true) {
                            MessageBox.Show("Datos cargados con éxito", "FELICITACIONES😎", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        RestaurarInputs();

                    } catch (Exception ex) {

                        MessageBox.Show(ex.Message); 
                    }
                }
                if (resultado == DialogResult.No) {
                    return;
                }
                MostrarDatos(); 
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {
            
        }

        private void GestionarComboBox() {

            comboBox_Zona.Items.Clear();
            comboBox_Producto.Items.Clear();
            comboBox_MedioPago.Items.Clear();
            comboBox_Moneda.Items.Clear();

            comboBox_Zona.Items.Insert(0, "Selecciona una Zona");
            comboBox_Zona.SelectedIndex = 0;
            foreach (Zonas zonas in LogicaZona.Instancia.ListarZonas()) {


                comboBox_Zona.Items.Add(zonas.Localidad);
            }
            comboBox_Producto.Items.Insert(0, "Seleccione un producto");
            comboBox_Producto.SelectedIndex = 0;
            foreach (ProductoConTipo prod in ListarProducto.Instancia.ListaProductos()) {



                string displayText = $"{prod.ProductoID} - {prod.Nombre} - {prod.NombreTipo}";


                comboBox_Producto.Items.Add(displayText);
            }
            comboBox_MedioPago.Items.Insert(0, "Selccionar Medio Pago");
            comboBox_MedioPago.SelectedIndex = 0;
            foreach (FormaPago pag in LogicaFormaPago.Instancia.ListarFormaPago()) {


                comboBox_MedioPago.Items.Add(pag.Metodopago);
            }
            comboBox_Moneda.Items.Insert(0, "Selecciona una Moneda");
            comboBox_Moneda.SelectedIndex = 0;
            foreach (Monedas mon in LogicaMoneda.Instancia.ListarMoneda()) {


                comboBox_Moneda.Items.Add(mon.MonedaName);

            }
        }

        private void comboBox_Zona_SelectedIndexChanged(object sender, EventArgs e) {
            foreach (Zonas tipo in LogicaZona.Instancia.ListarZonas()) {
                if (comboBox_Zona.Text.Contains(tipo.Localidad)) {
                    idZonaSeleccionada = tipo.ZonaID;
                    Console.WriteLine("ID SELCCIONADO:" + idZonaSeleccionada);
                }
            }
        }

        private void comboBox_MedioPago_SelectedIndexChanged(object sender, EventArgs e) {
            foreach (FormaPago tipo in LogicaFormaPago.Instancia.ListarFormaPago()) {
                if (comboBox_MedioPago.Text.Contains(tipo.Metodopago)) {
                    idMedioPagoSeleccionado = tipo.FormaPagoID;
                    tasaInteres = tipo.TasaInteres;
                    Console.WriteLine(tasaInteres);
                }
            }
        }

        private void comboBox_Producto_SelectedIndexChanged(object sender, EventArgs e) {
            foreach (ProductoConTipo tipo in ListarProducto.Instancia.ListaProductos()) {
                if (comboBox_Producto.Text.Contains(tipo.NombreTipo) && comboBox_Producto.Text.Contains(tipo.NombreTipo)) {
                    idProductoSeleccionado = tipo.ProductoID;
                    precioProducto = tipo.PrecioVenta;
                    Console.WriteLine(idProductoSeleccionado);
                }
            }
        }

        private void comboBox_Moneda_SelectedIndexChanged(object sender, EventArgs e) {
            foreach (Monedas tipo in LogicaMoneda.Instancia.ListarMoneda()) {
                if (comboBox_Moneda.Text.Contains(tipo.MonedaName)) {
                    idMonedaSeleccionada = tipo.MonedaID;
                    Console.WriteLine(idMonedaSeleccionada);
                }
            }
        }

        private void comboBox_Cantidad_SelectedIndexChanged(object sender, EventArgs e) {

            if (int.TryParse(comboBox_Cantidad.Text, out cantidad)){

            }
                     
                    
        }

        private void comboBox_CantCuotas_SelectedIndexChanged(object sender, EventArgs e) {
            if (int.TryParse(comboBox_CantCuotas.Text, out cuotas)) {

            }
           
        }

        private void ConfigurarColumnas() {
            // Configurar el orden de las columnas de botones para que estén al final
            dataGridView1.Columns["Delete"].DisplayIndex = 15;
            dataGridView1.Columns["Print"].DisplayIndex = 15;

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
            /*if (!dataGridView1.Columns.Contains("Edit")) {
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
            }*/

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

            if (!dataGridView1.Columns.Contains("Print")) {
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

             }


        }

        private void dateTimePicker_Fecha_ValueChanged(object sender, EventArgs e) {
            fechaSeleccionada = dateTimePicker_Fecha.Value;
        }

        private void iconButton_BuscarFecha_Click(object sender, EventArgs e) {
            MostrarDatos();
        }


        /*private void EditarFila(int rowIndex) {

            var seleccionarRow = dataGridView1.Rows[rowIndex];

            var Nombre = seleccionarRow.Cells[4].Value;
            var Apellido = seleccionarRow.Cells[5].Value;
            var Zona = seleccionarRow.Cells[6].Value;
            var Telefono = seleccionarRow.Cells[7].Value;
            var Email = seleccionarRow.Cells[8].Value;
            var Producto = seleccionarRow.Cells[9].Value;
            var MonedaPago = seleccionarRow.Cells[10].Value;
            var Cotizacion = seleccionarRow.Cells[11].Value;
            var Cantidad = seleccionarRow.Cells[12].Value;
            var MedioPago = seleccionarRow.Cells[13].Value;
            var Cuotas = seleccionarRow.Cells[14].Value;



            DatosCompra compra = new DatosCompra() {
                ClienteID
            };
        }*/
    
        private void BorrarFila(int rowIndex) {
            var seleccionarRow = dataGridView1.Rows[rowIndex];

            var IDselected = seleccionarRow.Cells[2].Value;

           
            Console.Write(IDselected);
           
            


            DialogResult result = MessageBox.Show("Seguro que desea borrar toda la fila?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes) {

                DatosCompra datos = new DatosCompra() {
                    DatosCompraID = IDselected.GetHashCode(),

                };
                bool respuesta = LogicaDatosCompra.Instancia.EliminarCompra(datos);

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

        private void Imprimir(int rowIndex) {
            var seleccionarRow = dataGridView1.Rows[rowIndex];

            var IDselected = seleccionarRow.Cells[2].Value;

            Console.Write(IDselected);

            DialogResult result = MessageBox.Show("Seguro que desea Imprimir?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes) {

                DatosCompra datos = new DatosCompra() {
                    DatosCompraID = IDselected.GetHashCode(),

                };
                bool respuesta = ListarClienteCompra.Instancia.GenerarPDFDatosCompra(datos);

            } else if (result == DialogResult.No) {
                return;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) {
                string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

                switch (columnName) {
                    case "Print":
                        Imprimir(e.RowIndex);
                        break;
                    case "Delete":
                        BorrarFila(e.RowIndex);
                        break;

                }
            }
        }


    }
}
