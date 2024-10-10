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
    public partial class MovimientoCaja : Form {
        public MovimientoCaja() {
            InitializeComponent();
            InitializeComponent();
            RedondearBoton(btn_IngredarMovimiento, 7);
            RedondearBoton(btn_AbrirCaja, 7);
            RedondearBoton(btn_CerrarCaja, 7);
        }
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
        private void MovimientoCaja_Load(object sender, EventArgs e)
        {

        }

        private void btn_Minimizar_Click(object sender, EventArgs e)
        { 
            // Accede al formulario principal y lo minimiza
            Form formularioPrincipal = Application.OpenForms[0]; // Asume que el formulario principal es el primero abierto
            formularioPrincipal.WindowState = FormWindowState.Minimized;
            
        }

        private void bttn_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_IngredarMovimiento_Click(object sender, EventArgs e)
        {

        }

        private void btn_AbrirCaja_Click(object sender, EventArgs e)
        {

        }

        private void btn_CerrarCaja_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e) {

        }
    }
}
