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

namespace ZonaPagoApp.Formularios
{
    public partial class frmInicioSesion : Form
    {
        clsUsuario oUsuario;
        clsComercio oComercio;
        int intPagador_Comercio = 0;
        string strIdentificacion = "";
        int intTieneUsuario = 0;

        public frmInicioSesion(int pintPagador_Comercio, string pstrIdentificacion, int pintTieneUsuario)
        {
            InitializeComponent();
            oUsuario = new clsUsuario();
            oComercio = new clsComercio();
            
            intPagador_Comercio = pintPagador_Comercio;//pintPagador_Comercio = 1 pagador - 2 comercio
            strIdentificacion = pstrIdentificacion;
            intTieneUsuario = pintTieneUsuario;// 1 Tiene usuario, 2 no Tiene usuario

            if (intTieneUsuario == 2)//Debe crear usuario
                btnCrearIngresar.Text = "Crear usuario";
        }

        private void btnCrearIngresar_Click(object sender, EventArgs e)
        {
            //Pagador
            if (intPagador_Comercio == 1)
            {
                if (intTieneUsuario == 2)
                {
                    int result = oUsuario.CrearUsuario(strIdentificacion, txtUsuario.Text, txtContrasenna.Text);
                    MessageBox.Show((result == -1 ? "Usuario ya existente, por favor cambielo." : "Creado exitosamente, Ya puede ingresar."),
                        "Sesion", MessageBoxButtons.OK, (result == -1 ? MessageBoxIcon.Warning : MessageBoxIcon.Information));
                    if (result == 1) { 
                        btnCrearIngresar.Text = "Ingresar";
                        intTieneUsuario = 1;
                    }
                }
                else
                {
                    int result = oUsuario.InicioSesion(txtUsuario.Text, txtContrasenna.Text);
                    MessageBox.Show((result > 0 ? "Ingreso exitoso." : "Error, Verifique Usuario y Contraseña."),
                        "Sesion", MessageBoxButtons.OK, (result > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning));
                    if (result >0)
                    {
                        frmPagador fPagador = new frmPagador(strIdentificacion);
                        this.Hide();
                        fPagador.ShowDialog();
                        this.Close();
                    }
                    
                }
            }
            else//Comercio
            {
                if (intTieneUsuario == 2)
                {
                    int result = oComercio.CrearUsuario(strIdentificacion, txtUsuario.Text, txtContrasenna.Text);
                    MessageBox.Show((result == -1 ? "Usuario ya existente, por favor cambielo." : "Creado exitosamente, Ya puede ingresar."),
                        "Sesion", MessageBoxButtons.OK, (result == -1 ? MessageBoxIcon.Warning : MessageBoxIcon.Information));
                    if (result == 1)
                    {
                        btnCrearIngresar.Text = "Ingresar";
                        intTieneUsuario = 1;
                    }
                }
                else
                {
                    int result = oComercio.InicioSesion(txtUsuario.Text, txtContrasenna.Text);
                    MessageBox.Show((result > 0 ? "Ingreso exitoso." : "Error, Verifique Usuario y Contraseña."),
                        "Sesion", MessageBoxButtons.OK, (result > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning));
                    if (result > 0)
                    {
                        frmComercio fComercio = new frmComercio(strIdentificacion);
                        this.Hide();
                        fComercio.ShowDialog();
                        this.Close();
                    }                    
                }
            }

        }
    }
}
