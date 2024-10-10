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
        public Stock() 
        {
            InitializeComponent();
            RedondearBoton(btn_CargarNuevoProducto, 7);
        }

        #region redondear botones
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

        #endregion
        private void Stock_Load(object sender, EventArgs e)
        {
            button_BuscarPorProducto.Enabled = false;
        }

        private void btn_CargarNuevoProducto_Click(object sender, EventArgs e)
        {
            Form formNuevoProducto = new BtnNuevoProducto();
            formNuevoProducto.ShowDialog();
        }

        private void button_BuscarPorProducto_Click(object sender, EventArgs e) {
 
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            if(textBox1.Text.Length > 0) {
                button_BuscarPorProducto.Enabled = true;
            } else {
                button_BuscarPorProducto.Enabled = false;
            }
        }
    }
}
