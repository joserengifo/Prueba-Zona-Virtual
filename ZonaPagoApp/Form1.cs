using cmpComercio.Comercio;
using cmpComercio.Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZonaPagoApp.ConsumoServicio;
using ZonaPagoApp.Formularios;

namespace ZonaPagoApp
{
    public partial class Form1 : Form
    {
        clsUsuario oUsuario;
        clsComercio oComercio;
        frmInicioSesion frmInises;
        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("¿Desea consumir el servicio?", "Verificasión", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Resultado == DialogResult.Yes)
            {
                ConsumoServicios.PostItem();
            }
            oUsuario = new clsUsuario();
            oComercio = new clsComercio();
        }

        private void btnPagador_Click(object sender, EventArgs e)
        {
            int result = oUsuario.UsuarioExistente(txtDocumento.Text);
            if (result == 0)
                MessageBox.Show("El numero de identificación no existe.", "Verificasión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else {
                frmInises = new frmInicioSesion(1, txtDocumento.Text, result);           
                this.Hide();
                frmInises.ShowDialog();
                this.Show();
            }
        }

        private void btnComercio_Click(object sender, EventArgs e)
        {
            int result = oComercio.UsuarioExistente(txtDocumento.Text);
            if (result == 0)
                MessageBox.Show("El numero de identificación no existe.", "Verificasión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                frmInises = new frmInicioSesion(2, txtDocumento.Text, result);
                this.Hide();
                frmInises.ShowDialog();
                this.Show();
            }
        
        }

    }
}
