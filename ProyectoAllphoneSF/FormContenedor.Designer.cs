namespace ProyectoAllphoneSF {
    partial class FormContenedor {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormContenedor));
            this.panel_ContenedorMenu = new System.Windows.Forms.Panel();
            this.panel_Botones = new System.Windows.Forms.Panel();
            this.panel_SeguirSeleccion = new System.Windows.Forms.Panel();
            this.gradienteButtonTop2 = new ProyectoAllphoneSF.GradienteButtonTop();
            this.button_CrearBackup = new System.Windows.Forms.Button();
            this.Button_MovimientosCaja = new System.Windows.Forms.Button();
            this.ButtonGestionarStock = new System.Windows.Forms.Button();
            this.Button_CargarCliente = new System.Windows.Forms.Button();
            this.button_Configuracion = new System.Windows.Forms.Button();
            this.panel_Logo = new System.Windows.Forms.Panel();
            this.pictureBox_LogoNegocio = new System.Windows.Forms.PictureBox();
            this.panel_ContenedorTop = new System.Windows.Forms.Panel();
            this.label_Hora = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label_Fecha = new System.Windows.Forms.Label();
            this.label_EstadoBaseDatos = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_ContenedorMain = new System.Windows.Forms.Panel();
            this.gradienteButtonTop1 = new ProyectoAllphoneSF.GradienteButtonTop();
            this.HoraFecha = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel_ContenedorMenu.SuspendLayout();
            this.panel_Botones.SuspendLayout();
            this.panel_Logo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_LogoNegocio)).BeginInit();
            this.panel_ContenedorTop.SuspendLayout();
            this.panel_ContenedorMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_ContenedorMenu
            // 
            this.panel_ContenedorMenu.Controls.Add(this.panel_Botones);
            this.panel_ContenedorMenu.Controls.Add(this.panel_Logo);
            this.panel_ContenedorMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_ContenedorMenu.Location = new System.Drawing.Point(0, 0);
            this.panel_ContenedorMenu.Name = "panel_ContenedorMenu";
            this.panel_ContenedorMenu.Size = new System.Drawing.Size(211, 561);
            this.panel_ContenedorMenu.TabIndex = 19;
            // 
            // panel_Botones
            // 
            this.panel_Botones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel_Botones.Controls.Add(this.panel_SeguirSeleccion);
            this.panel_Botones.Controls.Add(this.gradienteButtonTop2);
            this.panel_Botones.Controls.Add(this.button_CrearBackup);
            this.panel_Botones.Controls.Add(this.Button_MovimientosCaja);
            this.panel_Botones.Controls.Add(this.ButtonGestionarStock);
            this.panel_Botones.Controls.Add(this.Button_CargarCliente);
            this.panel_Botones.Controls.Add(this.button_Configuracion);
            this.panel_Botones.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Botones.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel_Botones.Location = new System.Drawing.Point(0, 110);
            this.panel_Botones.Name = "panel_Botones";
            this.panel_Botones.Size = new System.Drawing.Size(211, 451);
            this.panel_Botones.TabIndex = 1;
            // 
            // panel_SeguirSeleccion
            // 
            this.panel_SeguirSeleccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(191)))), ((int)(((byte)(236)))));
            this.panel_SeguirSeleccion.Location = new System.Drawing.Point(0, 62);
            this.panel_SeguirSeleccion.Name = "panel_SeguirSeleccion";
            this.panel_SeguirSeleccion.Size = new System.Drawing.Size(3, 100);
            this.panel_SeguirSeleccion.TabIndex = 13;
            // 
            // gradienteButtonTop2
            // 
            this.gradienteButtonTop2.BackColor = System.Drawing.Color.Transparent;
            this.gradienteButtonTop2.ColorButton = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.gradienteButtonTop2.ColorTop = System.Drawing.Color.WhiteSmoke;
            this.gradienteButtonTop2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradienteButtonTop2.Location = new System.Drawing.Point(0, 0);
            this.gradienteButtonTop2.Name = "gradienteButtonTop2";
            this.gradienteButtonTop2.Size = new System.Drawing.Size(211, 12);
            this.gradienteButtonTop2.TabIndex = 12;
            // 
            // button_CrearBackup
            // 
            this.button_CrearBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_CrearBackup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_CrearBackup.FlatAppearance.BorderSize = 0;
            this.button_CrearBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_CrearBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_CrearBackup.ForeColor = System.Drawing.Color.Transparent;
            this.button_CrearBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_CrearBackup.Location = new System.Drawing.Point(0, 388);
            this.button_CrearBackup.Name = "button_CrearBackup";
            this.button_CrearBackup.Size = new System.Drawing.Size(211, 63);
            this.button_CrearBackup.TabIndex = 11;
            this.button_CrearBackup.Text = "Crear Backup";
            this.button_CrearBackup.UseVisualStyleBackColor = true;
            this.button_CrearBackup.Click += new System.EventHandler(this.button_CrearBackup_Click);
            // 
            // Button_MovimientosCaja
            // 
            this.Button_MovimientosCaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Button_MovimientosCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_MovimientosCaja.FlatAppearance.BorderSize = 0;
            this.Button_MovimientosCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_MovimientosCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_MovimientosCaja.ForeColor = System.Drawing.Color.White;
            this.Button_MovimientosCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_MovimientosCaja.Location = new System.Drawing.Point(0, 192);
            this.Button_MovimientosCaja.Name = "Button_MovimientosCaja";
            this.Button_MovimientosCaja.Size = new System.Drawing.Size(211, 65);
            this.Button_MovimientosCaja.TabIndex = 8;
            this.Button_MovimientosCaja.Text = "Mov Caja";
            this.Button_MovimientosCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button_MovimientosCaja.UseVisualStyleBackColor = false;
            this.Button_MovimientosCaja.Click += new System.EventHandler(this.Button_MovimientosCaja_Click);
            // 
            // ButtonGestionarStock
            // 
            this.ButtonGestionarStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ButtonGestionarStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonGestionarStock.FlatAppearance.BorderSize = 0;
            this.ButtonGestionarStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonGestionarStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonGestionarStock.ForeColor = System.Drawing.Color.White;
            this.ButtonGestionarStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonGestionarStock.Location = new System.Drawing.Point(0, 120);
            this.ButtonGestionarStock.Name = "ButtonGestionarStock";
            this.ButtonGestionarStock.Size = new System.Drawing.Size(211, 65);
            this.ButtonGestionarStock.TabIndex = 7;
            this.ButtonGestionarStock.Text = "Gestionar Stock";
            this.ButtonGestionarStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonGestionarStock.UseVisualStyleBackColor = false;
            this.ButtonGestionarStock.Click += new System.EventHandler(this.ButtonGestionarStock_Click);
            // 
            // Button_CargarCliente
            // 
            this.Button_CargarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Button_CargarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_CargarCliente.FlatAppearance.BorderSize = 0;
            this.Button_CargarCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(114)))), ((int)(((byte)(141)))));
            this.Button_CargarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_CargarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_CargarCliente.ForeColor = System.Drawing.Color.White;
            this.Button_CargarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_CargarCliente.Location = new System.Drawing.Point(0, 49);
            this.Button_CargarCliente.Name = "Button_CargarCliente";
            this.Button_CargarCliente.Size = new System.Drawing.Size(211, 65);
            this.Button_CargarCliente.TabIndex = 6;
            this.Button_CargarCliente.Text = "Gestionar Compra";
            this.Button_CargarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button_CargarCliente.UseVisualStyleBackColor = false;
            this.Button_CargarCliente.Click += new System.EventHandler(this.Button_CargarCliente_Click);
            // 
            // button_Configuracion
            // 
            this.button_Configuracion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.button_Configuracion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Configuracion.FlatAppearance.BorderSize = 0;
            this.button_Configuracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Configuracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Configuracion.ForeColor = System.Drawing.Color.White;
            this.button_Configuracion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Configuracion.Location = new System.Drawing.Point(0, 263);
            this.button_Configuracion.Name = "button_Configuracion";
            this.button_Configuracion.Size = new System.Drawing.Size(211, 65);
            this.button_Configuracion.TabIndex = 14;
            this.button_Configuracion.Text = "Configuracion";
            this.button_Configuracion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Configuracion.UseVisualStyleBackColor = false;
            this.button_Configuracion.Click += new System.EventHandler(this.button_Configuracion_Click);
            // 
            // panel_Logo
            // 
            this.panel_Logo.Controls.Add(this.pictureBox_LogoNegocio);
            this.panel_Logo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Logo.Location = new System.Drawing.Point(0, 0);
            this.panel_Logo.Name = "panel_Logo";
            this.panel_Logo.Size = new System.Drawing.Size(211, 110);
            this.panel_Logo.TabIndex = 0;
            // 
            // pictureBox_LogoNegocio
            // 
            this.pictureBox_LogoNegocio.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox_LogoNegocio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_LogoNegocio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_LogoNegocio.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_LogoNegocio.Image")));
            this.pictureBox_LogoNegocio.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_LogoNegocio.Name = "pictureBox_LogoNegocio";
            this.pictureBox_LogoNegocio.Size = new System.Drawing.Size(211, 110);
            this.pictureBox_LogoNegocio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_LogoNegocio.TabIndex = 9;
            this.pictureBox_LogoNegocio.TabStop = false;
            this.pictureBox_LogoNegocio.Click += new System.EventHandler(this.pictureBox_LogoNegocio_Click);
            // 
            // panel_ContenedorTop
            // 
            this.panel_ContenedorTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.panel_ContenedorTop.Controls.Add(this.label_Hora);
            this.panel_ContenedorTop.Controls.Add(this.label);
            this.panel_ContenedorTop.Controls.Add(this.label_Fecha);
            this.panel_ContenedorTop.Controls.Add(this.label_EstadoBaseDatos);
            this.panel_ContenedorTop.Controls.Add(this.label1);
            this.panel_ContenedorTop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_ContenedorTop.Location = new System.Drawing.Point(211, 526);
            this.panel_ContenedorTop.Name = "panel_ContenedorTop";
            this.panel_ContenedorTop.Size = new System.Drawing.Size(1073, 35);
            this.panel_ContenedorTop.TabIndex = 20;
            // 
            // label_Hora
            // 
            this.label_Hora.AutoSize = true;
            this.label_Hora.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_Hora.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Hora.ForeColor = System.Drawing.Color.Transparent;
            this.label_Hora.Location = new System.Drawing.Point(795, 0);
            this.label_Hora.Name = "label_Hora";
            this.label_Hora.Size = new System.Drawing.Size(71, 29);
            this.label_Hora.TabIndex = 19;
            this.label_Hora.Text = "12:33";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Dock = System.Windows.Forms.DockStyle.Right;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.Transparent;
            this.label.Location = new System.Drawing.Point(866, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(104, 29);
            this.label.TabIndex = 18;
            this.label.Text = "hs           ";
            // 
            // label_Fecha
            // 
            this.label_Fecha.AutoSize = true;
            this.label_Fecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_Fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Fecha.ForeColor = System.Drawing.Color.Transparent;
            this.label_Fecha.Location = new System.Drawing.Point(970, 0);
            this.label_Fecha.Name = "label_Fecha";
            this.label_Fecha.Size = new System.Drawing.Size(103, 29);
            this.label_Fecha.TabIndex = 17;
            this.label_Fecha.Text = "19:34:22";
            // 
            // label_EstadoBaseDatos
            // 
            this.label_EstadoBaseDatos.AutoSize = true;
            this.label_EstadoBaseDatos.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_EstadoBaseDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_EstadoBaseDatos.Location = new System.Drawing.Point(148, 0);
            this.label_EstadoBaseDatos.Name = "label_EstadoBaseDatos";
            this.label_EstadoBaseDatos.Size = new System.Drawing.Size(51, 29);
            this.label_EstadoBaseDatos.TabIndex = 16;
            this.label_EstadoBaseDatos.Text = "null";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 29);
            this.label1.TabIndex = 15;
            this.label1.Text = "Base Datos: ";
            // 
            // panel_ContenedorMain
            // 
            this.panel_ContenedorMain.BackColor = System.Drawing.Color.Transparent;
            this.panel_ContenedorMain.Controls.Add(this.gradienteButtonTop1);
            this.panel_ContenedorMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_ContenedorMain.Location = new System.Drawing.Point(211, 0);
            this.panel_ContenedorMain.Name = "panel_ContenedorMain";
            this.panel_ContenedorMain.Size = new System.Drawing.Size(1073, 526);
            this.panel_ContenedorMain.TabIndex = 21;
            // 
            // gradienteButtonTop1
            // 
            this.gradienteButtonTop1.ColorButton = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.gradienteButtonTop1.ColorTop = System.Drawing.Color.Transparent;
            this.gradienteButtonTop1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gradienteButtonTop1.Location = new System.Drawing.Point(0, 516);
            this.gradienteButtonTop1.Name = "gradienteButtonTop1";
            this.gradienteButtonTop1.Size = new System.Drawing.Size(1073, 10);
            this.gradienteButtonTop1.TabIndex = 0;
            // 
            // HoraFecha
            // 
            this.HoraFecha.Enabled = true;
            this.HoraFecha.Tick += new System.EventHandler(this.HoraFecha_Tick);
            // 
            // FormContenedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1284, 561);
            this.Controls.Add(this.panel_ContenedorMain);
            this.Controls.Add(this.panel_ContenedorTop);
            this.Controls.Add(this.panel_ContenedorMenu);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "FormContenedor";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Allphone.SF";
            this.Load += new System.EventHandler(this.FormContenedor_Load);
            this.panel_ContenedorMenu.ResumeLayout(false);
            this.panel_Botones.ResumeLayout(false);
            this.panel_Logo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_LogoNegocio)).EndInit();
            this.panel_ContenedorTop.ResumeLayout(false);
            this.panel_ContenedorTop.PerformLayout();
            this.panel_ContenedorMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_ContenedorMenu;
        private System.Windows.Forms.Panel panel_ContenedorTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_EstadoBaseDatos;
        private System.Windows.Forms.Panel panel_Logo;
        private System.Windows.Forms.PictureBox pictureBox_LogoNegocio;
        private System.Windows.Forms.Label label_Fecha;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label_Hora;
        private System.Windows.Forms.Panel panel_Botones;
        private System.Windows.Forms.Button Button_MovimientosCaja;
        private System.Windows.Forms.Button ButtonGestionarStock;
        private System.Windows.Forms.Button Button_CargarCliente;
        private System.Windows.Forms.Panel panel_ContenedorMain;
        private System.Windows.Forms.Timer HoraFecha;
        private System.Windows.Forms.Button button_CrearBackup;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GradienteButtonTop gradienteButtonTop1;
        private GradienteButtonTop gradienteButtonTop2;
        private System.Windows.Forms.Panel panel_SeguirSeleccion;
        private System.Windows.Forms.Button button_Configuracion;
    }
}