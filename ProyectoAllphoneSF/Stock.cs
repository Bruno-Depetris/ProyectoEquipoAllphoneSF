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

        }

        private void Stock_Load(object sender, EventArgs e)
        {

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

            } else {

            }
        }
    }
}
