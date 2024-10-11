using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace ProyectoAllphoneSF {
    class GradientPanel : Panel {
        public Color ColorLeft { get; set; }
        public Color ColorRight { get; set; }

        protected override void OnPaint(PaintEventArgs e) {
            // Cambiar el ángulo a 0 grados para un gradiente de izquierda a derecha
            LinearGradientBrush lgb = new LinearGradientBrush(this.ClientRectangle, this.ColorLeft, this.ColorRight, 0F);
            Graphics g = e.Graphics;
            g.FillRectangle(lgb, this.ClientRectangle);
            base.OnPaint(e);
        }
    }
}


