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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lbl_Ventas = new System.Windows.Forms.Label();
            this.Lbl_Dashboard = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label__Ganancias_mes = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label__Ventas_medio_pago = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label__ventas_moneda = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label__total_productos = new System.Windows.Forms.Label();
            this.label__Valor_stock = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Ventas
            // 
            this.lbl_Ventas.AutoSize = true;
            this.lbl_Ventas.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Ventas.Font = new System.Drawing.Font("Nirmala UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Ventas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.lbl_Ventas.Location = new System.Drawing.Point(329, 0);
            this.lbl_Ventas.Name = "lbl_Ventas";
            this.lbl_Ventas.Size = new System.Drawing.Size(129, 47);
            this.lbl_Ventas.TabIndex = 2;
            this.lbl_Ventas.Text = "Ventas";
            // 
            // Lbl_Dashboard
            // 
            this.Lbl_Dashboard.AutoSize = true;
            this.Lbl_Dashboard.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_Dashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.Lbl_Dashboard.Font = new System.Drawing.Font("Nirmala UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Dashboard.ForeColor = System.Drawing.Color.Black;
            this.Lbl_Dashboard.Location = new System.Drawing.Point(0, 0);
            this.Lbl_Dashboard.Name = "Lbl_Dashboard";
            this.Lbl_Dashboard.Size = new System.Drawing.Size(272, 54);
            this.Lbl_Dashboard.TabIndex = 12;
            this.Lbl_Dashboard.Text = "DASHBOARD";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(815, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 475);
            this.panel1.TabIndex = 30;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(191)))), ((int)(((byte)(236)))));
            this.panel2.Controls.Add(this.chart1);
            this.panel2.Location = new System.Drawing.Point(53, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(734, 237);
            this.panel2.TabIndex = 31;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            chartArea8.AxisX.MajorGrid.Enabled = false;
            chartArea8.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea8.AxisY.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea8.BackColor = System.Drawing.Color.Transparent;
            chartArea8.BorderColor = System.Drawing.Color.WhiteSmoke;
            chartArea8.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea8);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart1.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(170)))), ((int)(((byte)(235)))))};
            series8.BorderColor = System.Drawing.Color.Transparent;
            series8.BorderWidth = 4;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series8.IsValueShownAsLabel = true;
            series8.MarkerSize = 13;
            series8.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series8.Name = "Series1";
            this.chart1.Series.Add(series8);
            this.chart1.Size = new System.Drawing.Size(734, 237);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel3.Controls.Add(this.panel9);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(53, 311);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(339, 196);
            this.panel3.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OldLace;
            this.label1.Location = new System.Drawing.Point(40, 349);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "GANANCIAS DEL MES";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(448, 311);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(339, 196);
            this.panel4.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.OldLace;
            this.label2.Location = new System.Drawing.Point(65, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "VALOR DEL STOCK";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label__Ganancias_mes);
            this.panel5.Location = new System.Drawing.Point(44, 392);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(232, 65);
            this.panel5.TabIndex = 0;
            // 
            // label__Ganancias_mes
            // 
            this.label__Ganancias_mes.AutoSize = true;
            this.label__Ganancias_mes.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label__Ganancias_mes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(170)))), ((int)(((byte)(235)))));
            this.label__Ganancias_mes.Location = new System.Drawing.Point(30, 17);
            this.label__Ganancias_mes.Name = "label__Ganancias_mes";
            this.label__Ganancias_mes.Size = new System.Drawing.Size(182, 32);
            this.label__Ganancias_mes.TabIndex = 0;
            this.label__Ganancias_mes.Text = "999999999999";
            this.label__Ganancias_mes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label__Ganancias_mes.Click += new System.EventHandler(this.label__Ganancias_mes_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label__Valor_stock);
            this.panel6.Location = new System.Drawing.Point(69, 55);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(204, 92);
            this.panel6.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.label__Ventas_medio_pago);
            this.panel7.Location = new System.Drawing.Point(44, 60);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(232, 92);
            this.panel7.TabIndex = 1;
            // 
            // label__Ventas_medio_pago
            // 
            this.label__Ventas_medio_pago.AutoSize = true;
            this.label__Ventas_medio_pago.Font = new System.Drawing.Font("Nirmala UI", 36F, System.Drawing.FontStyle.Bold);
            this.label__Ventas_medio_pago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(170)))), ((int)(((byte)(235)))));
            this.label__Ventas_medio_pago.Location = new System.Drawing.Point(44, 13);
            this.label__Ventas_medio_pago.Name = "label__Ventas_medio_pago";
            this.label__Ventas_medio_pago.Size = new System.Drawing.Size(140, 65);
            this.label__Ventas_medio_pago.TabIndex = 0;
            this.label__Ventas_medio_pago.Text = "9999";
            this.label__Ventas_medio_pago.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "seleccione metodo de pago"});
            this.comboBox1.Location = new System.Drawing.Point(81, 33);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(148, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "seleccione moneda"});
            this.comboBox2.Location = new System.Drawing.Point(81, 212);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(148, 21);
            this.comboBox2.TabIndex = 4;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.label__ventas_moneda);
            this.panel8.Location = new System.Drawing.Point(44, 239);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(232, 92);
            this.panel8.TabIndex = 3;
            // 
            // label__ventas_moneda
            // 
            this.label__ventas_moneda.AutoSize = true;
            this.label__ventas_moneda.Font = new System.Drawing.Font("Nirmala UI", 36F, System.Drawing.FontStyle.Bold);
            this.label__ventas_moneda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(170)))), ((int)(((byte)(235)))));
            this.label__ventas_moneda.Location = new System.Drawing.Point(44, 17);
            this.label__ventas_moneda.Name = "label__ventas_moneda";
            this.label__ventas_moneda.Size = new System.Drawing.Size(140, 65);
            this.label__ventas_moneda.TabIndex = 0;
            this.label__ventas_moneda.Text = "9999";
            this.label__ventas_moneda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.OldLace;
            this.label3.Location = new System.Drawing.Point(18, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(318, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "TOTAL DE PRODUCTOS VENDIDOS";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Transparent;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.label__total_productos);
            this.panel9.Location = new System.Drawing.Point(56, 55);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(204, 95);
            this.panel9.TabIndex = 1;
            // 
            // label__total_productos
            // 
            this.label__total_productos.AutoSize = true;
            this.label__total_productos.Font = new System.Drawing.Font("Nirmala UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label__total_productos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(170)))), ((int)(((byte)(235)))));
            this.label__total_productos.Location = new System.Drawing.Point(18, 13);
            this.label__total_productos.Name = "label__total_productos";
            this.label__total_productos.Size = new System.Drawing.Size(168, 65);
            this.label__total_productos.TabIndex = 0;
            this.label__total_productos.Text = "99999";
            this.label__total_productos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label__total_productos.Click += new System.EventHandler(this.label__total_productos_Click);
            // 
            // label__Valor_stock
            // 
            this.label__Valor_stock.AutoSize = true;
            this.label__Valor_stock.Font = new System.Drawing.Font("Nirmala UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label__Valor_stock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(170)))), ((int)(((byte)(235)))));
            this.label__Valor_stock.Location = new System.Drawing.Point(3, 27);
            this.label__Valor_stock.Name = "label__Valor_stock";
            this.label__Valor_stock.Size = new System.Drawing.Size(200, 47);
            this.label__Valor_stock.TabIndex = 0;
            this.label__Valor_stock.Text = "999999999";
            this.label__Valor_stock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label__Valor_stock.Click += new System.EventHandler(this.label__Valor_stock_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.OldLace;
            this.label5.Location = new System.Drawing.Point(16, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(278, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "VENTAS POR MEDIO DE PAGO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.OldLace;
            this.label6.Location = new System.Drawing.Point(50, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(207, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "VENTAS POR MONEDA";
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1121, 529);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Lbl_Dashboard);
            this.Controls.Add(this.lbl_Ventas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashBoard";
            this.Text = " ";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lbl_Ventas;
        private System.Windows.Forms.Label Lbl_Dashboard;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label__Ventas_medio_pago;
        private System.Windows.Forms.Label label__Ganancias_mes;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label__ventas_moneda;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label__total_productos;
        private System.Windows.Forms.Label label__Valor_stock;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

