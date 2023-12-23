namespace ZonaPagoApp
{
    partial class Form1
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
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.btnPagador = new System.Windows.Forms.Button();
            this.btnComercio = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDocumento
            // 
            this.txtDocumento.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumento.Location = new System.Drawing.Point(46, 45);
            this.txtDocumento.Margin = new System.Windows.Forms.Padding(4);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(217, 21);
            this.txtDocumento.TabIndex = 33;
            // 
            // btnPagador
            // 
            this.btnPagador.Location = new System.Drawing.Point(46, 104);
            this.btnPagador.Name = "btnPagador";
            this.btnPagador.Size = new System.Drawing.Size(80, 79);
            this.btnPagador.TabIndex = 34;
            this.btnPagador.Text = "Pagador";
            this.btnPagador.UseVisualStyleBackColor = true;
            this.btnPagador.Click += new System.EventHandler(this.btnPagador_Click);
            // 
            // btnComercio
            // 
            this.btnComercio.Location = new System.Drawing.Point(183, 104);
            this.btnComercio.Name = "btnComercio";
            this.btnComercio.Size = new System.Drawing.Size(80, 79);
            this.btnComercio.TabIndex = 35;
            this.btnComercio.Text = "Comercio";
            this.btnComercio.UseVisualStyleBackColor = true;
            this.btnComercio.Click += new System.EventHandler(this.btnComercio_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Identificacion / Nit";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 307);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnComercio);
            this.Controls.Add(this.btnPagador);
            this.Controls.Add(this.txtDocumento);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Button btnPagador;
        private System.Windows.Forms.Button btnComercio;
        private System.Windows.Forms.Label label1;
    }
}

