using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;


namespace ProyectoAllphoneSF {
    public partial class DashBoard : Form {
        
        public DashBoard()
        {
            InitializeComponent();
            ConfigurarGraficoVentas(ventasPorMes);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }
        // ejemplo
        int[] ventasPorMes = { 50, 70, 60, 80, 90, 100, 110, 120, 140, 230, 310, 550 };
        private void ConfigurarGraficoVentas(int[] ventasPorMes)
        {
            // Limpiar las series anteriores del gráfico
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Titles.Add("Ventas de Productos en el Año");
            
            // Crear una nueva serie del tipo Spline
            var series = new System.Windows.Forms.DataVisualization.Charting.Series("Ventas");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series.BorderWidth = 5; // Ajustamos el grosor de la línea
            
            series.IsValueShownAsLabel = true;
            series.LabelForeColor = Color.Black;
            series.MarkerSize = 13;
            series.MarkerStyle = MarkerStyle.Circle;
            series.LabelForeColor = Color.White; // Color de los valores en los puntos


            // Agregar los puntos de datos a la serie
            for (int i = 0; i < ventasPorMes.Length; i++)
            {
                series.Points.AddXY(i + 1, ventasPorMes[i]);
            }

            // Añadir la serie al gráfico
            chart1.Series.Add(series);

            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            chart1.ChartAreas[0].AxisX.CustomLabels.Clear();

            for (int i = 0; i < meses.Length; i++)
            {
                chart1.ChartAreas[0].AxisX.CustomLabels.Add(i + 0.5, i + 1.5, meses[i]);
            }
                                  
            chart1.ChartAreas[0].AxisY.Title = "Cant.Vendidos";
            // Cambiar color de las etiquetas y títulos de los ejes a blanco
            chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White; // Nombres de los meses en blanco
            chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White; // Números del eje Y en blanco
            chart1.ChartAreas[0].AxisX.TitleForeColor = Color.White; // Título del eje X en blanco
            chart1.ChartAreas[0].AxisY.TitleForeColor = Color.White; // Título del eje Y en blanco






        }




        private void label6_Click(object sender, EventArgs e) {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_valor_stok_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label__total_productos_Click(object sender, EventArgs e)
        {
            
        }

        private void label__Valor_stock_Click(object sender, EventArgs e)
        {

        }

        private void label__Ganancias_mes_Click(object sender, EventArgs e)
        {

        }
    }
}
