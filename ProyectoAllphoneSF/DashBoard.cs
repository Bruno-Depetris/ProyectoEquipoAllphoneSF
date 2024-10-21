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
            CrearGraficoDona();
        }

        private void CrearGraficoDona()
        {

            // Crear una nueva serie de datos
            Series series = new Series("Datos");

            // Definir el tipo de gráfico (Dona)
            series.ChartType = SeriesChartType.Doughnut;

            // Agregar datos de ejemplo (enteros)
            series.Points.AddXY("", 30);
            series.Points.AddXY("", 20);
            series.Points.AddXY("", 25);
            series.Points.AddXY("", 15);
            series.Points.AddXY("", 10);

            // Agregar la serie al gráfico
            chart_GraficoDonaVentas.Series.Clear();  // Limpiar las series previas si existen
            chart_GraficoDonaVentas.Series.Add(series);

            // Opcional: Personalizar el gráfico
            chart_GraficoDonaVentas.Legends.Add(new Legend("Leyenda"));
            chart_GraficoDonaVentas.Legends["Leyenda"].Docking = Docking.Bottom; 
          
        }

        private void label6_Click(object sender, EventArgs e) {

        }
    }
}
