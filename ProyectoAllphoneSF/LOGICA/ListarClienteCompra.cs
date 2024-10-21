using iTextSharp.text.pdf;
using iTextSharp.text;
using ProyectoAllphoneSF.MODELO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Globalization;

namespace ProyectoAllphoneSF.LOGICA {
    internal class ListarClienteCompra {


        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;


        private static ListarClienteCompra _ListarClienteCompra;

        public ListarClienteCompra() {

        }

        public static ListarClienteCompra Instancia {
            get {
                if (_ListarClienteCompra == null) {
                    _ListarClienteCompra = new ListarClienteCompra();

                }
                return _ListarClienteCompra;
            }
        }

        public List<ListarCompra> ListarComprasPorFecha(DateTime fechaFiltro) {
            List<ListarCompra> listaCompras = new List<ListarCompra>();

            using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
                conexion.Open();

                string query = @"
        SELECT
            DatosCompra.DatosCompraID,
            DatosCompra.Fecha, 
            DatosCompra.Cuotas,
            Cliente.Nombre AS NombreCliente, 
            Cliente.Apellido AS ApellidoCliente, 
            Cliente.Direccion,
            Cliente.Email, 
            Productos.Nombre AS Producto, 
            Productos.PrecioVenta, 
            FormaPago.TasaInteres, 
            FormaPago.MetodoPago AS FormaPago, 
            Monedas.Moneda AS Moneda,  
            DatosCompra.Cantidad, 
            DatosCompra.TotalVenta
        FROM
            DatosCompra
        LEFT JOIN
            Cliente ON DatosCompra.ClienteID = Cliente.ClienteID
        LEFT JOIN
            Zonas ON Cliente.ZonaID = Zonas.ZonaID
        LEFT JOIN
            FormaPago ON DatosCompra.FormaPagoID = FormaPago.FormaPagoID
        LEFT JOIN
            Productos ON DatosCompra.ProductoID = Productos.ProductoID
        LEFT JOIN
            Monedas ON DatosCompra.MonedaID = Monedas.MonedaID
        WHERE
            DATE(DatosCompra.Fecha) = @FechaFiltro
        ";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conexion)) {
                    // Pasar el parámetro de fecha al comando SQL
                    cmd.Parameters.AddWithValue("@FechaFiltro", fechaFiltro.ToString("yyyy-MM-dd"));

                    using (SQLiteDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            ListarCompra compra = new ListarCompra() {
                                DatosCompraID = int.Parse(reader["DatosCompraID"].ToString()),
                                Fecha = DateTime.Parse(reader["Fecha"].ToString()),
                                NombreCliente = reader["NombreCliente"].ToString(),
                                ApellidoCliente = reader["ApellidoCliente"].ToString(),
                                Direccion = reader["Direccion"].ToString(),
                                Email = reader["Email"].ToString(),
                                Producto = reader["Producto"].ToString(),
                                PrecioVenta = decimal.Parse(reader["PrecioVenta"].ToString()),
                                Cuotas = int.Parse(reader["Cuotas"].ToString()),
                                TasaInteres = decimal.Parse(reader["TasaInteres"].ToString()),
                                FormaPago = reader["FormaPago"].ToString(),
                                Moneda = reader["Moneda"].ToString(),
                                Cantidad = int.Parse(reader["Cantidad"].ToString()),
                                TotalVenta = decimal.Parse(reader["TotalVenta"].ToString())
                            };

                            listaCompras.Add(compra);
                        }
                    }
                }
            }

            return listaCompras;
        }

        public bool GenerarPDFDatosCompra(DatosCompra comp) {
            try {
                // Crear el diálogo para guardar el archivo
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files|*.pdf";
                saveFileDialog.Title = "Guardar PDF";
                saveFileDialog.FileName = "Compra_" + comp.DatosCompraID + ".pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                    // Obtener la ubicación donde el usuario desea guardar el archivo
                    string filePath = saveFileDialog.FileName;

                    // Obtener datos de la base de datos
                    using (SQLiteConnection conexion = new SQLiteConnection(cadena)) {
                        conexion.Open();

                        string query = @"
                SELECT
                    DatosCompra.DatosCompraID,
                    DatosCompra.Fecha, 
                    DatosCompra.Cuotas,
                    Cliente.Nombre AS NombreCliente, 
                    Cliente.Apellido AS ApellidoCliente, 
                    Cliente.Direccion,
                    Cliente.Email, 
                    Productos.Nombre AS Producto, 
                    Productos.PrecioVenta, 
                    FormaPago.TasaInteres, 
                    FormaPago.MetodoPago AS FormaPago, 
                    Monedas.Moneda AS Moneda,  
                    DatosCompra.Cantidad, 
                    DatosCompra.TotalVenta
                FROM
                    DatosCompra
                LEFT JOIN
                    Cliente ON DatosCompra.ClienteID = Cliente.ClienteID
                LEFT JOIN
                    Zonas ON Cliente.ZonaID = Zonas.ZonaID
                LEFT JOIN
                    FormaPago ON DatosCompra.FormaPagoID = FormaPago.FormaPagoID
                LEFT JOIN
                    Productos ON DatosCompra.ProductoID = Productos.ProductoID
                LEFT JOIN
                    Monedas ON DatosCompra.MonedaID = Monedas.MonedaID
                WHERE
                    DatosCompra.DatosCompraID = @DatosCompraID";

                        SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                        cmd.Parameters.AddWithValue("@DatosCompraID", comp.DatosCompraID);

                        using (SQLiteDataReader reader = cmd.ExecuteReader()) {
                            if (reader.Read()) {
                                // Obtener los datos necesarios
                                DateTime fecha = DateTime.Parse(reader["Fecha"].ToString());
                                string nombreCliente = reader["NombreCliente"].ToString();
                                string apellidoCliente = reader["ApellidoCliente"].ToString();
                                string direccion = reader["Direccion"].ToString();
                                string email = reader["Email"].ToString();
                                string producto = reader["Producto"].ToString();
                                string formaPago = reader["FormaPago"].ToString();
                                string moneda = reader["Moneda"].ToString();
                                int cantidad = int.Parse(reader["Cantidad"].ToString());
                                decimal totalVenta = decimal.Parse(reader["TotalVenta"].ToString());
                                int cuotas = int.Parse(reader["Cuotas"].ToString());
                                decimal tasaInteres = decimal.Parse(reader["TasaInteres"].ToString());

                                // Crear el documento en formato A4 con márgenes
                                Document documento = new Document(PageSize.A4, 50, 50, 50, 50);
                                PdfWriter.GetInstance(documento, new FileStream(filePath, FileMode.Create));
                                documento.Open();

                                // Añadir metadatos
                                documento.AddCreator("AllphoneSF");
                                documento.AddTitle("Recibo de Compra - AllphoneSF");

                                Console.WriteLine("Base Directory: " + AppDomain.CurrentDomain.BaseDirectory);


                                string logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\IMG\logo.png");

                                Console.WriteLine("Ruta de la imagen: " + logoPath); // Para verificar

                                if (File.Exists(logoPath)) {
                                    Image logo = Image.GetInstance(logoPath);
                                    logo.Alignment = Element.ALIGN_CENTER;
                                    logo.ScaleToFit(150f, 150f); 
                                    documento.Add(logo);
                                } else {
                                    Console.WriteLine("NO LO ENCONTRE");
                                }


                                // Espacio entre el logo y el contenido
                                documento.Add(new Paragraph("\n"));

                                // Título de la compra centrado
                                Font fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                                Paragraph titulo = new Paragraph("Gracias por tu compra", fontTitulo);
                                titulo.Alignment = Element.ALIGN_CENTER;
                                documento.Add(titulo);

                                // Espacio entre el logo y el contenido
                                documento.Add(new Paragraph("\n"));

                                // Información del cliente centrada y estilizada
                                Font fontCliente = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                                Paragraph datosCliente = new Paragraph(
                                    $"Cliente: {nombreCliente} {apellidoCliente}\nDirección: {direccion}\nEmail: {email}",
                                    fontCliente);
                                datosCliente.Alignment = Element.ALIGN_CENTER;
                                documento.Add(datosCliente);

                                // Espacio entre el logo y el contenido
                                documento.Add(new Paragraph("\n"));

                                // Muestra info del prod
                                Font fontDetalle = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                                documento.Add(new Paragraph("Detalles de la Compra:", fontDetalle));

                                Font fontTexto = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                                Paragraph detallesCompra = new Paragraph(
                                    $@"Fecha: {fecha.ToShortDateString()}
                                    Producto: {producto}
                                    Forma de Pago: {formaPago}
                                    Cuotas: {cuotas} (Tasa de Interés: {tasaInteres}%)
                                    Moneda: {moneda}
                                    Cantidad: {cantidad}
                                    Total de la Venta: {totalVenta.ToString("C", new CultureInfo("en-US"))}",
                                    fontTexto);
                                detallesCompra.Alignment = Element.ALIGN_LEFT;
                                documento.Add(detallesCompra);

                                documento.Add(new Paragraph("---------------------------------------------"));

                                // Mensaje final de agradecimiento
                                Font fontFinal = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 12);

                                Paragraph mensajeFinal = new Paragraph(
                                    "Esperamos que disfrutes tu compra. ¡Gracias por elegir AllphoneSF!",
                                    fontFinal);
                                mensajeFinal.Alignment = Element.ALIGN_CENTER;
                                documento.Add(mensajeFinal);


                                Paragraph leyenda = new Paragraph(
                                    "Comprobante no valido como factura",
                                    fontFinal);
                                leyenda.Alignment = Element.ALIGN_CENTER;
                                documento.Add(leyenda);

                                // Cerrar el documento
                                documento.Close();
                            } else {
                                Console.WriteLine("No se encontró una compra con el ID proporcionado.");
                            }
                        }
                    }
                    return true;
                } else {
                    return false; // El usuario canceló la operación de guardado
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }



    }
}
