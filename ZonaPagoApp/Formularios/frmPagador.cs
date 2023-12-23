using cmpComercio.Comercio;
using cmpComercio.ModelosConstantes;
using cmpComercio.Transaccion;
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
    public partial class frmPagador : Form
    {
        clsTrans_Medio_Pago oTrans_Medio_Pago;
        clsTrans_Estado oTrans_Estado;
        clsComercio oComercio;
        clsUsuario oUsuario;
        string strIdentificacion;

        public frmPagador(string pstrIdentificacion)
        {
            InitializeComponent();

            oTrans_Medio_Pago = new clsTrans_Medio_Pago();
            oTrans_Estado = new clsTrans_Estado();
            oComercio = new clsComercio();
            oUsuario = new clsUsuario();
            strIdentificacion = pstrIdentificacion;                       
        }

        private void frmPagador_Load(object sender, EventArgs e)
        {
            try
            {
                List<clsComercio> oListComercio = new List<clsComercio>();
                List<clsTrans_Medio_Pago> oListMedioPago = new List<clsTrans_Medio_Pago>();
                List<clsTrans_Estado> oListEstado = new List<clsTrans_Estado>();

                oListComercio = oComercio.ObtenerComercios();
                oListMedioPago = oTrans_Medio_Pago.ObtenerMediosPago();
                oListEstado = oTrans_Estado.ObtenerEstados();

                cbcomercio_codigo.DataSource = oListComercio;
                cbcomercio_codigo.DisplayMember = "comercio_nombre";
                cbcomercio_codigo.ValueMember = "comercio_codigo";

                cbTrans_medio_pago.DataSource = oListMedioPago;
                cbTrans_medio_pago.DisplayMember = "str_Trans_medio_pago";
                cbTrans_medio_pago.ValueMember = "Trans_medio_pago";

                cbTrans_estado.DataSource = oListEstado;
                cbTrans_estado.DisplayMember = "str_Trans_estado";
                cbTrans_estado.ValueMember = "Trans_estado";
                //------------------------------------------------
                llenarDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pagador: Error  " + ex, "Pagador", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTrans_codigo.Text.Trim() == "")
                    MessageBox.Show("Error, Debe ingresar un 'Codigo transacción'","Pagador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    clsTransaccion oTransaccion = new clsTransaccion(Convert.ToInt64(txtTrans_codigo.Text), Convert.ToInt32(cbTrans_medio_pago.SelectedValue),
                        Convert.ToInt32(cbTrans_estado.SelectedValue), Convert.ToDouble(txtTrans_total.Text),
                        Convert.ToDateTime(dtpTrans_fecha.Value), txtTrans_concepto.Text, Convert.ToInt64(cbcomercio_codigo.SelectedValue),
                        strIdentificacion);
                    long longResult = oTransaccion.Insertar_Transaccion();

                    MessageBox.Show((longResult == 1 ? "Error, Codigo transacción ya existente" : "La transacción se guardo exitosamente."),
                                "Pagador", MessageBoxButtons.OK, (longResult == 1 ? MessageBoxIcon.Warning : MessageBoxIcon.Information));

                    if (longResult != 1)
                    {
                        txtTrans_codigo.Text = "";
                        txtTrans_total.Text = "0";
                        txtTrans_concepto.Text = "";
                        llenarDGV();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pagador: Error  " + ex, "Pagador", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void llenarDGV()
        {
            try
            {
                dgvResultado.AutoGenerateColumns = false;
                dgvResultado.DataSource = oUsuario.ObtenerTransaccionesPagador(strIdentificacion);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pagador: Error  " + ex, "Pagador", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void txtTrans_codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }        
}
