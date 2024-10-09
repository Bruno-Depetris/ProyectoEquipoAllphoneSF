using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoAllphoneSF {
    public partial class Estadisticas : Form {
        public Estadisticas() {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        // Importar funciones de la API de Windows para mover la ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void Estadisticas_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            // Enviar el mensaje para mover la ventana al formulario principal (ParentForm)
            SendMessage(this.ParentForm.Handle, 0x112, 0xf012, 0); // 0x112 = WM_SYSCOMMAND, 0xf012 = SC_MOVE + HTCAPTION
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
