namespace ZonaPagoApp.Formularios
{
    partial class frmPagador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label6;
            this.dgvResultado = new System.Windows.Forms.DataGridView();
            this.Trans_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strTrans_medio_pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strTrans_estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trans_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trans_fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trans_concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbcomercio_codigo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTrans_codigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTrans_medio_pago = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTrans_estado = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTrans_total = new System.Windows.Forms.TextBox();
            this.dtpTrans_fecha = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTrans_concepto = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(12, 130);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(37, 13);
            label6.TabIndex = 41;
            label6.Text = "Fecha";
            // 
            // dgvResultado
            // 
            this.dgvResultado.AllowUserToAddRows = false;
            this.dgvResultado.AllowUserToDeleteRows = false;
            this.dgvResultado.AllowUserToOrderColumns = true;
            this.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Trans_codigo,
            this.strTrans_medio_pago,
            this.strTrans_estado,
            this.Trans_total,
            this.Trans_fecha,
            this.Trans_concepto});
            this.dgvResultado.Location = new System.Drawing.Point(15, 244);
            this.dgvResultado.Name = "dgvResultado";
            this.dgvResultado.ReadOnly = true;
            this.dgvResultado.Size = new System.Drawing.Size(776, 293);
            this.dgvResultado.TabIndex = 0;
            // 
            // Trans_codigo
            // 
            this.Trans_codigo.DataPropertyName = "Trans_codigo";
            this.Trans_codigo.HeaderText = "Condigo Transacción";
            this.Trans_codigo.Name = "Trans_codigo";
            this.Trans_codigo.ReadOnly = true;
            // 
            // strTrans_medio_pago
            // 
            this.strTrans_medio_pago.DataPropertyName = "strTrans_medio_pago";
            this.strTrans_medio_pago.HeaderText = "Medio de pago";
            this.strTrans_medio_pago.Name = "strTrans_medio_pago";
            this.strTrans_medio_pago.ReadOnly = true;
            // 
            // strTrans_estado
            // 
            this.strTrans_estado.DataPropertyName = "strTrans_estado";
            this.strTrans_estado.HeaderText = "Estado";
            this.strTrans_estado.Name = "strTrans_estado";
            this.strTrans_estado.ReadOnly = true;
            // 
            // Trans_total
            // 
            this.Trans_total.DataPropertyName = "Trans_total";
            this.Trans_total.HeaderText = "Total";
            this.Trans_total.Name = "Trans_total";
            this.Trans_total.ReadOnly = true;
            // 
            // Trans_fecha
            // 
            this.Trans_fecha.DataPropertyName = "Trans_fecha";
            this.Trans_fecha.HeaderText = "Fecha";
            this.Trans_fecha.Name = "Trans_fecha";
            this.Trans_fecha.ReadOnly = true;
            // 
            // Trans_concepto
            // 
            this.Trans_concepto.DataPropertyName = "Trans_concepto";
            this.Trans_concepto.HeaderText = "Concepto";
            this.Trans_concepto.Name = "Trans_concepto";
            this.Trans_concepto.ReadOnly = true;
            // 
            // cbcomercio_codigo
            // 
            this.cbcomercio_codigo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbcomercio_codigo.FormattingEnabled = true;
            this.cbcomercio_codigo.Location = new System.Drawing.Point(12, 34);
            this.cbcomercio_codigo.Margin = new System.Windows.Forms.Padding(4);
            this.cbcomercio_codigo.Name = "cbcomercio_codigo";
            this.cbcomercio_codigo.Size = new System.Drawing.Size(293, 21);
            this.cbcomercio_codigo.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Comercio";
            // 
            // txtTrans_codigo
            // 
            this.txtTrans_codigo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrans_codigo.Location = new System.Drawing.Point(15, 88);
            this.txtTrans_codigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtTrans_codigo.MaxLength = 10;
            this.txtTrans_codigo.Name = "txtTrans_codigo";
            this.txtTrans_codigo.Size = new System.Drawing.Size(140, 21);
            this.txtTrans_codigo.TabIndex = 33;
            this.txtTrans_codigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTrans_codigo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Codigo transacción";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Medio de pago";
            // 
            // cbTrans_medio_pago
            // 
            this.cbTrans_medio_pago.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTrans_medio_pago.FormattingEnabled = true;
            this.cbTrans_medio_pago.Location = new System.Drawing.Point(187, 88);
            this.cbTrans_medio_pago.Margin = new System.Windows.Forms.Padding(4);
            this.cbTrans_medio_pago.Name = "cbTrans_medio_pago";
            this.cbTrans_medio_pago.Size = new System.Drawing.Size(143, 21);
            this.cbTrans_medio_pago.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(356, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Estado";
            // 
            // cbTrans_estado
            // 
            this.cbTrans_estado.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTrans_estado.FormattingEnabled = true;
            this.cbTrans_estado.Location = new System.Drawing.Point(359, 88);
            this.cbTrans_estado.Margin = new System.Windows.Forms.Padding(4);
            this.cbTrans_estado.Name = "cbTrans_estado";
            this.cbTrans_estado.Size = new System.Drawing.Size(143, 21);
            this.cbTrans_estado.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(529, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Total";
            // 
            // txtTrans_total
            // 
            this.txtTrans_total.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrans_total.Location = new System.Drawing.Point(532, 88);
            this.txtTrans_total.Margin = new System.Windows.Forms.Padding(4);
            this.txtTrans_total.Name = "txtTrans_total";
            this.txtTrans_total.Size = new System.Drawing.Size(140, 21);
            this.txtTrans_total.TabIndex = 39;
            this.txtTrans_total.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTrans_codigo_KeyPress);
            // 
            // dtpTrans_fecha
            // 
            this.dtpTrans_fecha.CustomFormat = "";
            this.dtpTrans_fecha.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTrans_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTrans_fecha.Location = new System.Drawing.Point(12, 146);
            this.dtpTrans_fecha.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dtpTrans_fecha.Name = "dtpTrans_fecha";
            this.dtpTrans_fecha.Size = new System.Drawing.Size(143, 21);
            this.dtpTrans_fecha.TabIndex = 42;
            this.dtpTrans_fecha.Value = new System.DateTime(2021, 4, 26, 13, 29, 11, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(184, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "Concepto";
            // 
            // txtTrans_concepto
            // 
            this.txtTrans_concepto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrans_concepto.Location = new System.Drawing.Point(187, 146);
            this.txtTrans_concepto.Margin = new System.Windows.Forms.Padding(4);
            this.txtTrans_concepto.MaxLength = 100;
            this.txtTrans_concepto.Multiline = true;
            this.txtTrans_concepto.Name = "txtTrans_concepto";
            this.txtTrans_concepto.Size = new System.Drawing.Size(315, 44);
            this.txtTrans_concepto.TabIndex = 43;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(532, 144);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 46);
            this.btnGuardar.TabIndex = 45;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmPagador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 549);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTrans_concepto);
            this.Controls.Add(this.dtpTrans_fecha);
            this.Controls.Add(label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTrans_total);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbTrans_estado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbTrans_medio_pago);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTrans_codigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbcomercio_codigo);
            this.Controls.Add(this.dgvResultado);
            this.Name = "frmPagador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPagador";
            this.Load += new System.EventHandler(this.frmPagador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvResultado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trans_codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn strTrans_medio_pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn strTrans_estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trans_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trans_fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trans_concepto;
        private System.Windows.Forms.ComboBox cbcomercio_codigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTrans_codigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTrans_medio_pago;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTrans_estado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTrans_total;
        private System.Windows.Forms.DateTimePicker dtpTrans_fecha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTrans_concepto;
        private System.Windows.Forms.Button btnGuardar;
    }
}