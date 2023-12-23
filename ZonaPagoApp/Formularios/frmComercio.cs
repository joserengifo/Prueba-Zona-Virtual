using cmpComercio.Comercio;
using cmpComercio.ModelosConstantes;
using cmpComercio.Transaccion;
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
    public partial class frmComercio : Form
    {
        clsTrans_Medio_Pago oTrans_Medio_Pago;
        clsTrans_Estado oTrans_Estado;
        clsTransaccion oTransaccion;
        string strIdentificacion;
        public frmComercio(string pstrIdentificacion)
        {
            InitializeComponent();

            oTrans_Medio_Pago = new clsTrans_Medio_Pago();
            oTrans_Estado = new clsTrans_Estado();
            oTransaccion = new clsTransaccion();
            strIdentificacion = pstrIdentificacion;
        }

        private void frmComercio_Load(object sender, EventArgs e)
        {
            llenarCb();
        }

        private void llenarCb()
        {
            try
            {
                List<clsTrans_Medio_Pago> oListMedioPago = new List<clsTrans_Medio_Pago>();
                List<clsTrans_Estado> oListEstado = new List<clsTrans_Estado>();

                oListMedioPago = oTrans_Medio_Pago.ObtenerMediosPago();
                oListEstado = oTrans_Estado.ObtenerEstados();

                cbTrans_medio_pago.DataSource = oListMedioPago;
                cbTrans_medio_pago.DisplayMember = "str_Trans_medio_pago";
                cbTrans_medio_pago.ValueMember = "Trans_medio_pago";

                cbTrans_estado.DataSource = oListEstado;
                cbTrans_estado.DisplayMember = "str_Trans_estado";
                cbTrans_estado.ValueMember = "Trans_estado";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Comercio: Error  " + ex, "Comercio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void llenarDGV()
        {
            try
            {
                dgvResultado.AutoGenerateColumns = false;
                dgvResultado.DataSource = oTransaccion.ObtenerTransaccionesComercio(strIdentificacion, dtpTrans_fechaIni.Value, dtpTrans_fechaFin.Value,
                    Convert.ToInt64((txtTrans_codigo.Text.Length==0?"0":txtTrans_codigo.Text)), txtusuario_identificacion.Text);

                double dbTotal = 0;
                foreach (DataGridViewRow row in dgvResultado.Rows)
                {
                    dbTotal = dbTotal + Convert.ToDouble(row.Cells["Trans_total"].Value);
                }
                lblTotal.Text = "Total: $ " + dbTotal.ToString("N");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Comercio: Error  " + ex, "Comercio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void EditarTransaccion(int pTrans_codigo)
        {
            try
            {
                clsTransaccion oTransaccionAyuda = new clsTransaccion();
                oTransaccion.ObtenerTransaccion(pTrans_codigo, ref oTransaccionAyuda);
                if (oTransaccionAyuda.Trans_codigo > 0)
                {
                    gbEditarTransaccion.Visible = true;
                    llenarCb();

                    txtTrans_codigoEdit.Text = oTransaccionAyuda.Trans_codigo.ToString();
                    cbTrans_medio_pago.SelectedValue = oTransaccionAyuda.Trans_medio_pago;
                    cbTrans_estado.SelectedValue = oTransaccionAyuda.Trans_estado;
                    txtTrans_total .Text = oTransaccionAyuda.Trans_total.ToString();
                    dtpTrans_fecha.Value = oTransaccionAyuda.Trans_fecha;
                    txtTrans_concepto.Text = oTransaccionAyuda.Trans_concepto;
                }
                else
                    MessageBox.Show("Comercio: Error no se logro identificar el registro.", "Comercio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Comercio: Error  " + ex, "Comercio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            llenarDGV();
        }

        private void dgvResultado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if click is on new row or header row
            if (e.RowIndex == dgvResultado.NewRowIndex || e.RowIndex < 0)
                return;

            //Check if click is on specific column 
            if (e.ColumnIndex == dgvResultado.Columns["strPuedeEditar"].Index)
            {
                if (dgvResultado.Rows[e.RowIndex].Cells["strPuedeEditar"].Value.ToString() == "Actualizar")
                    EditarTransaccion(Convert.ToInt32(dgvResultado.Rows[e.RowIndex].Cells["Trans_codigo"].Value));
                else
                    MessageBox.Show("El pago ya fue 'Aprovado', no es posible su edición.", "Comercio", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtTrans_codigoEdit.Text = "";
            txtTrans_total.Text = "";
            dtpTrans_fecha.Value =DateTime.Now;
            txtTrans_concepto.Text = "";

            gbEditarTransaccion.Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int result = oTransaccion.ActualizarTransaccion(Convert.ToInt32(txtTrans_codigoEdit.Text), Convert.ToInt32(cbTrans_medio_pago.SelectedValue), 
                    Convert.ToInt32(cbTrans_estado.SelectedValue),Convert.ToDouble(txtTrans_total.Text), dtpTrans_fecha.Value, txtTrans_concepto.Text);

                MessageBox.Show((result == 1?"Pago actualizado exitosamente":"Error, no fue posible actualizar la ifnromacion del pago."), "Comercio",
                    MessageBoxButtons.OK, (result == 1 ? MessageBoxIcon.Information: MessageBoxIcon.Warning));

                if (result == 1)
                {
                    gbEditarTransaccion.Visible = false;

                    txtTrans_codigoEdit.Text = "";
                    txtTrans_total.Text = "";
                    dtpTrans_fecha.Value = DateTime.Now;
                    txtTrans_concepto.Text = "";

                    llenarDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Comercio: Error  " + ex, "Comercio", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
