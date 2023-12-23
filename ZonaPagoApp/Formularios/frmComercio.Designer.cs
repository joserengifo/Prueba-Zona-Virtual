namespace ZonaPagoApp.Formularios
{
    partial class frmComercio
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label9;
            this.dgvResultado = new System.Windows.Forms.DataGridView();
            this.Trans_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strTrans_medio_pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strTrans_estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trans_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trans_fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trans_concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strPuedeEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dtpTrans_fechaIni = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTrans_codigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtusuario_identificacion = new System.Windows.Forms.TextBox();
            this.dtpTrans_fechaFin = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.gbEditarTransaccion = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTrans_concepto = new System.Windows.Forms.TextBox();
            this.dtpTrans_fecha = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTrans_total = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTrans_estado = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbTrans_medio_pago = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTrans_codigoEdit = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).BeginInit();
            this.gbEditarTransaccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(340, 138);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(64, 13);
            label6.TabIndex = 45;
            label6.Text = "Fecha inicio";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(512, 136);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(51, 13);
            label3.TabIndex = 49;
            label3.Text = "Fecha fin";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(25, 64);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(37, 13);
            label9.TabIndex = 62;
            label9.Text = "Fecha";
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
            this.Trans_concepto,
            this.strPuedeEditar});
            this.dgvResultado.Location = new System.Drawing.Point(12, 196);
            this.dgvResultado.Name = "dgvResultado";
            this.dgvResultado.ReadOnly = true;
            this.dgvResultado.Size = new System.Drawing.Size(776, 293);
            this.dgvResultado.TabIndex = 1;
            this.dgvResultado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResultado_CellClick);
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
            // strPuedeEditar
            // 
            this.strPuedeEditar.DataPropertyName = "strPuedeEditar";
            this.strPuedeEditar.HeaderText = "Editar";
            this.strPuedeEditar.Name = "strPuedeEditar";
            this.strPuedeEditar.ReadOnly = true;
            // 
            // dtpTrans_fechaIni
            // 
            this.dtpTrans_fechaIni.CustomFormat = "";
            this.dtpTrans_fechaIni.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTrans_fechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTrans_fechaIni.Location = new System.Drawing.Point(340, 154);
            this.dtpTrans_fechaIni.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dtpTrans_fechaIni.Name = "dtpTrans_fechaIni";
            this.dtpTrans_fechaIni.Size = new System.Drawing.Size(143, 21);
            this.dtpTrans_fechaIni.TabIndex = 46;
            this.dtpTrans_fechaIni.Value = new System.DateTime(2021, 4, 26, 13, 29, 11, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Codigo transacción";
            // 
            // txtTrans_codigo
            // 
            this.txtTrans_codigo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrans_codigo.Location = new System.Drawing.Point(19, 155);
            this.txtTrans_codigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtTrans_codigo.MaxLength = 10;
            this.txtTrans_codigo.Name = "txtTrans_codigo";
            this.txtTrans_codigo.Size = new System.Drawing.Size(140, 21);
            this.txtTrans_codigo.TabIndex = 43;
            this.txtTrans_codigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTrans_codigo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Identificación usuario";
            // 
            // txtusuario_identificacion
            // 
            this.txtusuario_identificacion.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusuario_identificacion.Location = new System.Drawing.Point(182, 155);
            this.txtusuario_identificacion.Margin = new System.Windows.Forms.Padding(4);
            this.txtusuario_identificacion.MaxLength = 10;
            this.txtusuario_identificacion.Name = "txtusuario_identificacion";
            this.txtusuario_identificacion.Size = new System.Drawing.Size(140, 21);
            this.txtusuario_identificacion.TabIndex = 47;
            // 
            // dtpTrans_fechaFin
            // 
            this.dtpTrans_fechaFin.CustomFormat = "";
            this.dtpTrans_fechaFin.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTrans_fechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTrans_fechaFin.Location = new System.Drawing.Point(512, 152);
            this.dtpTrans_fechaFin.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dtpTrans_fechaFin.Name = "dtpTrans_fechaFin";
            this.dtpTrans_fechaFin.Size = new System.Drawing.Size(143, 21);
            this.dtpTrans_fechaFin.TabIndex = 50;
            this.dtpTrans_fechaFin.Value = new System.DateTime(2021, 4, 26, 13, 29, 11, 0);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(676, 145);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(94, 45);
            this.btnBuscar.TabIndex = 51;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(639, 515);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(119, 18);
            this.lblTotal.TabIndex = 52;
            this.lblTotal.Text = "Total: $ 0.00";
            // 
            // gbEditarTransaccion
            // 
            this.gbEditarTransaccion.Controls.Add(this.btnCancelar);
            this.gbEditarTransaccion.Controls.Add(this.btnGuardar);
            this.gbEditarTransaccion.Controls.Add(this.label8);
            this.gbEditarTransaccion.Controls.Add(this.txtTrans_concepto);
            this.gbEditarTransaccion.Controls.Add(this.dtpTrans_fecha);
            this.gbEditarTransaccion.Controls.Add(label9);
            this.gbEditarTransaccion.Controls.Add(this.label10);
            this.gbEditarTransaccion.Controls.Add(this.txtTrans_total);
            this.gbEditarTransaccion.Controls.Add(this.label5);
            this.gbEditarTransaccion.Controls.Add(this.cbTrans_estado);
            this.gbEditarTransaccion.Controls.Add(this.label7);
            this.gbEditarTransaccion.Controls.Add(this.cbTrans_medio_pago);
            this.gbEditarTransaccion.Controls.Add(this.label4);
            this.gbEditarTransaccion.Controls.Add(this.txtTrans_codigoEdit);
            this.gbEditarTransaccion.Location = new System.Drawing.Point(19, 12);
            this.gbEditarTransaccion.Name = "gbEditarTransaccion";
            this.gbEditarTransaccion.Size = new System.Drawing.Size(769, 121);
            this.gbEditarTransaccion.TabIndex = 53;
            this.gbEditarTransaccion.TabStop = false;
            this.gbEditarTransaccion.Text = "Editar transacción";
            this.gbEditarTransaccion.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(623, 76);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(86, 32);
            this.btnCancelar.TabIndex = 67;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(530, 76);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(86, 32);
            this.btnGuardar.TabIndex = 66;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(183, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 65;
            this.label8.Text = "Concepto";
            // 
            // txtTrans_concepto
            // 
            this.txtTrans_concepto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrans_concepto.Location = new System.Drawing.Point(186, 80);
            this.txtTrans_concepto.Margin = new System.Windows.Forms.Padding(4);
            this.txtTrans_concepto.MaxLength = 100;
            this.txtTrans_concepto.Multiline = true;
            this.txtTrans_concepto.Name = "txtTrans_concepto";
            this.txtTrans_concepto.Size = new System.Drawing.Size(315, 34);
            this.txtTrans_concepto.TabIndex = 64;
            // 
            // dtpTrans_fecha
            // 
            this.dtpTrans_fecha.CustomFormat = "";
            this.dtpTrans_fecha.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTrans_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTrans_fecha.Location = new System.Drawing.Point(25, 80);
            this.dtpTrans_fecha.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dtpTrans_fecha.Name = "dtpTrans_fecha";
            this.dtpTrans_fecha.Size = new System.Drawing.Size(143, 21);
            this.dtpTrans_fecha.TabIndex = 63;
            this.dtpTrans_fecha.Value = new System.DateTime(2021, 4, 26, 13, 29, 11, 0);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(527, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 61;
            this.label10.Text = "Total";
            // 
            // txtTrans_total
            // 
            this.txtTrans_total.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrans_total.Location = new System.Drawing.Point(530, 38);
            this.txtTrans_total.Margin = new System.Windows.Forms.Padding(4);
            this.txtTrans_total.Name = "txtTrans_total";
            this.txtTrans_total.Size = new System.Drawing.Size(140, 21);
            this.txtTrans_total.TabIndex = 60;
            this.txtTrans_total.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTrans_codigo_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(355, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Estado";
            // 
            // cbTrans_estado
            // 
            this.cbTrans_estado.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTrans_estado.FormattingEnabled = true;
            this.cbTrans_estado.Location = new System.Drawing.Point(358, 38);
            this.cbTrans_estado.Margin = new System.Windows.Forms.Padding(4);
            this.cbTrans_estado.Name = "cbTrans_estado";
            this.cbTrans_estado.Size = new System.Drawing.Size(143, 21);
            this.cbTrans_estado.TabIndex = 58;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(183, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 57;
            this.label7.Text = "Medio de pago";
            // 
            // cbTrans_medio_pago
            // 
            this.cbTrans_medio_pago.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTrans_medio_pago.FormattingEnabled = true;
            this.cbTrans_medio_pago.Location = new System.Drawing.Point(186, 38);
            this.cbTrans_medio_pago.Margin = new System.Windows.Forms.Padding(4);
            this.cbTrans_medio_pago.Name = "cbTrans_medio_pago";
            this.cbTrans_medio_pago.Size = new System.Drawing.Size(143, 21);
            this.cbTrans_medio_pago.TabIndex = 56;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "Codigo transacción";
            // 
            // txtTrans_codigoEdit
            // 
            this.txtTrans_codigoEdit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrans_codigoEdit.Location = new System.Drawing.Point(25, 38);
            this.txtTrans_codigoEdit.Margin = new System.Windows.Forms.Padding(4);
            this.txtTrans_codigoEdit.MaxLength = 10;
            this.txtTrans_codigoEdit.Name = "txtTrans_codigoEdit";
            this.txtTrans_codigoEdit.ReadOnly = true;
            this.txtTrans_codigoEdit.Size = new System.Drawing.Size(140, 21);
            this.txtTrans_codigoEdit.TabIndex = 54;
            // 
            // frmComercio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 553);
            this.Controls.Add(this.gbEditarTransaccion);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dtpTrans_fechaFin);
            this.Controls.Add(label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtusuario_identificacion);
            this.Controls.Add(this.dtpTrans_fechaIni);
            this.Controls.Add(label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTrans_codigo);
            this.Controls.Add(this.dgvResultado);
            this.Name = "frmComercio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmComercio";
            this.Load += new System.EventHandler(this.frmComercio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).EndInit();
            this.gbEditarTransaccion.ResumeLayout(false);
            this.gbEditarTransaccion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvResultado;
        private System.Windows.Forms.DateTimePicker dtpTrans_fechaIni;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTrans_codigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtusuario_identificacion;
        private System.Windows.Forms.DateTimePicker dtpTrans_fechaFin;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.GroupBox gbEditarTransaccion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTrans_codigoEdit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTrans_estado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbTrans_medio_pago;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTrans_concepto;
        private System.Windows.Forms.DateTimePicker dtpTrans_fecha;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTrans_total;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trans_codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn strTrans_medio_pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn strTrans_estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trans_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trans_fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trans_concepto;
        private System.Windows.Forms.DataGridViewButtonColumn strPuedeEditar;
    }
}