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

namespace ProyectoAllphoneSF
{
    public partial class Configuraciones : Form
    {
        public Configuraciones()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Accede al formulario principal y lo minimiza
            Form formularioPrincipal = Application.OpenForms[0]; // Asume que el formulario principal es el primero abierto
            formularioPrincipal.WindowState = FormWindowState.Minimized;
        }
        // Importar funciones de la API de Windows para mover la ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void Configuraciones_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            // Enviar el mensaje para mover la ventana al formulario principal (ParentForm)
            SendMessage(this.ParentForm.Handle, 0x112, 0xf012, 0); // 0x112 = WM_SYSCOMMAND, 0xf012 = SC_MOVE + HTCAPTION
        }
    }
}
