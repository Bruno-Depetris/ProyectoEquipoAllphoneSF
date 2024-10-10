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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ProductoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrevioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_BuscarPorProducto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_CargarNuevoProducto
            // 
            this.btn_CargarNuevoProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(191)))), ((int)(((byte)(236)))));
            this.btn_CargarNuevoProducto.FlatAppearance.BorderSize = 0;
            this.btn_CargarNuevoProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CargarNuevoProducto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CargarNuevoProducto.Location = new System.Drawing.Point(296, 383);
            this.btn_CargarNuevoProducto.Name = "btn_CargarNuevoProducto";
            this.btn_CargarNuevoProducto.Size = new System.Drawing.Size(187, 27);
            this.btn_CargarNuevoProducto.TabIndex = 43;
            this.btn_CargarNuevoProducto.Text = "Cargar Nuevo Producto";
            this.btn_CargarNuevoProducto.UseVisualStyleBackColor = false;
            this.btn_CargarNuevoProducto.Click += new System.EventHandler(this.btn_CargarNuevoProducto_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Arboria Book", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(533, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(236, 30);
            this.textBox1.TabIndex = 42;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Nirmala UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 54);
            this.label12.TabIndex = 41;
            this.label12.Text = "Stock";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductoID,
            this.Nombre,
            this.Tipo,
            this.PrecioCosto,
            this.PrevioVenta});
            this.dataGridView1.Location = new System.Drawing.Point(26, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(743, 295);
            this.dataGridView1.TabIndex = 44;
            // 
            // ProductoID
            // 
            this.ProductoID.HeaderText = "PRODUCTOID";
            this.ProductoID.Name = "ProductoID";
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "NOMBRE";
            this.Nombre.Name = "Nombre";
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "TIPO";
            this.Tipo.Name = "Tipo";
            // 
            // PrecioCosto
            // 
            this.PrecioCosto.HeaderText = "PRECIOCOSTO";
            this.PrecioCosto.Name = "PrecioCosto";
            // 
            // PrevioVenta
            // 
            this.PrevioVenta.HeaderText = "PRECIOVENTA";
            this.PrevioVenta.Name = "PrevioVenta";
            // 
            // button_BuscarPorProducto
            // 
            this.button_BuscarPorProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_BuscarPorProducto.Font = new System.Drawing.Font("Arboria Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_BuscarPorProducto.Location = new System.Drawing.Point(402, 10);
            this.button_BuscarPorProducto.Name = "button_BuscarPorProducto";
            this.button_BuscarPorProducto.Size = new System.Drawing.Size(125, 37);
            this.button_BuscarPorProducto.TabIndex = 45;
            this.button_BuscarPorProducto.Text = "Buscar";
            this.button_BuscarPorProducto.UseVisualStyleBackColor = true;
            this.button_BuscarPorProducto.Click += new System.EventHandler(this.button_BuscarPorProducto_Click);
            // 
            // Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_BuscarPorProducto);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_CargarNuevoProducto);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Stock";
            this.Text = "Stock";
            this.Load += new System.EventHandler(this.Stock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_CargarNuevoProducto;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrevioVenta;
        private System.Windows.Forms.Button button_BuscarPorProducto;
    }
}