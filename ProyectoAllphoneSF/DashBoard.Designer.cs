namespace ProyectoAllphoneSF {
    partial class DashBoard {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.label_EstadoBaseDatos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_EstadoBaseDatos
            // 
            this.label_EstadoBaseDatos.AutoSize = true;
            this.label_EstadoBaseDatos.Location = new System.Drawing.Point(245, 92);
            this.label_EstadoBaseDatos.Name = "label_EstadoBaseDatos";
            this.label_EstadoBaseDatos.Size = new System.Drawing.Size(35, 13);
            this.label_EstadoBaseDatos.TabIndex = 0;
            this.label_EstadoBaseDatos.Text = "label1";
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_EstadoBaseDatos);
            this.Name = "DashBoard";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_EstadoBaseDatos;
    }
}

