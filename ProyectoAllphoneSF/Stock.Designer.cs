namespace ProyectoAllphoneSF {
    partial class Stock {
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
            this.btn_CargarNuevoProducto = new System.Windows.Forms.Button();
            this.textBox_BusquedaNombre = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox_OrdenarPor = new System.Windows.Forms.ComboBox();
            this.iconButton_BuscarNombre = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_CargarNuevoProducto
            // 
            this.btn_CargarNuevoProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CargarNuevoProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(191)))), ((int)(((byte)(236)))));
            this.btn_CargarNuevoProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CargarNuevoProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CargarNuevoProducto.Font = new System.Drawing.Font("Arboria Book", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CargarNuevoProducto.Location = new System.Drawing.Point(248, 342);
            this.btn_CargarNuevoProducto.Name = "btn_CargarNuevoProducto";
            this.btn_CargarNuevoProducto.Size = new System.Drawing.Size(271, 43);
            this.btn_CargarNuevoProducto.TabIndex = 43;
            this.btn_CargarNuevoProducto.Text = "Cargar Nuevo Producto";
            this.btn_CargarNuevoProducto.UseVisualStyleBackColor = false;
            this.btn_CargarNuevoProducto.Click += new System.EventHandler(this.btn_CargarNuevoProducto_Click);
            // 
            // textBox_BusquedaNombre
            // 
            this.textBox_BusquedaNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_BusquedaNombre.Font = new System.Drawing.Font("Arboria Book", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_BusquedaNombre.Location = new System.Drawing.Point(4, 6);
            this.textBox_BusquedaNombre.Name = "textBox_BusquedaNombre";
            this.textBox_BusquedaNombre.Size = new System.Drawing.Size(236, 30);
            this.textBox_BusquedaNombre.TabIndex = 42;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Nirmala UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(147, 54);
            this.label12.TabIndex = 41;
            this.label12.Text = "STOCK";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(775, 275);
            this.dataGridView1.TabIndex = 46;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox_OrdenarPor);
            this.panel1.Controls.Add(this.iconButton_BuscarNombre);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.btn_CargarNuevoProducto);
            this.panel1.Controls.Add(this.textBox_BusquedaNombre);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 396);
            this.panel1.TabIndex = 55;
            // 
            // comboBox_OrdenarPor
            // 
            this.comboBox_OrdenarPor.BackColor = System.Drawing.Color.White;
            this.comboBox_OrdenarPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_OrdenarPor.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_OrdenarPor.FormattingEnabled = true;
            this.comboBox_OrdenarPor.Location = new System.Drawing.Point(397, 7);
            this.comboBox_OrdenarPor.Name = "comboBox_OrdenarPor";
            this.comboBox_OrdenarPor.Size = new System.Drawing.Size(231, 29);
            this.comboBox_OrdenarPor.TabIndex = 56;
            this.comboBox_OrdenarPor.SelectedIndexChanged += new System.EventHandler(this.comboBox_OrdenarPor_SelectedIndexChanged);
            // 
            // iconButton_BuscarNombre
            // 
            this.iconButton_BuscarNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.iconButton_BuscarNombre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton_BuscarNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton_BuscarNombre.Font = new System.Drawing.Font("Arboria Book", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton_BuscarNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(191)))), ((int)(((byte)(236)))));
            this.iconButton_BuscarNombre.IconChar = FontAwesome.Sharp.IconChar.Searchengin;
            this.iconButton_BuscarNombre.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(191)))), ((int)(((byte)(236)))));
            this.iconButton_BuscarNombre.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton_BuscarNombre.IconSize = 25;
            this.iconButton_BuscarNombre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton_BuscarNombre.Location = new System.Drawing.Point(246, 6);
            this.iconButton_BuscarNombre.Name = "iconButton_BuscarNombre";
            this.iconButton_BuscarNombre.Size = new System.Drawing.Size(102, 30);
            this.iconButton_BuscarNombre.TabIndex = 54;
            this.iconButton_BuscarNombre.Text = "Buscar";
            this.iconButton_BuscarNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton_BuscarNombre.UseVisualStyleBackColor = false;
            this.iconButton_BuscarNombre.Click += new System.EventHandler(this.iconButton_BuscarNombre_Click);
            // 
            // Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Stock";
            this.Text = "Stock";
            this.Load += new System.EventHandler(this.Stock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_CargarNuevoProducto;
        private System.Windows.Forms.TextBox textBox_BusquedaNombre;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton iconButton_BuscarNombre;
        private System.Windows.Forms.ComboBox comboBox_OrdenarPor;
    }
}