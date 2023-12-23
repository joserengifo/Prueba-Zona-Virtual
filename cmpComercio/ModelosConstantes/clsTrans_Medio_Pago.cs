using cmpComercio.Configuracion;
using cmpGeneral;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmpComercio.ModelosConstantes
{
    public class clsTrans_Medio_Pago
    {
        #region "Atributos"
        public int Trans_medio_pago { get; set; }
        public string str_Trans_medio_pago { get; set; }

        //De apoyo
        private clsAccesoDat oAD { get; set; }
        private List<clsStoreProcedures> oProcedimientos { get; set; }
        #endregion

        #region "Constructores"
        public clsTrans_Medio_Pago()
        {
            Trans_medio_pago = 0;
            str_Trans_medio_pago = "";
            DefinicionSP();
        }

        public clsTrans_Medio_Pago(int pTrans_medio_pago, string pstr_Trans_medio_pago)
        {
            Trans_medio_pago = pTrans_medio_pago;
            str_Trans_medio_pago = pstr_Trans_medio_pago;
        }
        #endregion

        #region "Métodos"
        private void DefinicionSP()
        {
            oProcedimientos = new List<clsStoreProcedures>();
            //Otener todos los producto
            oProcedimientos.Add(new clsStoreProcedures("SP_ObtenerMediosPago"));
        }
        public List<clsTrans_Medio_Pago> ObtenerMediosPago()
        {
            try
            {
                List<clsTrans_Medio_Pago> lsTrans_Medio_Pago = new List<clsTrans_Medio_Pago>();
                oAD = new clsAccesoDat(new clsConstante().strCadenaConexionSIC);

                DataView dv;
                dv = oAD.RunProcSQL_DataView(oProcedimientos[0].strNombreSP, this, oProcedimientos[0].oParams);
                foreach (DataRowView oRow in dv)
                {
                    lsTrans_Medio_Pago.Add(new clsTrans_Medio_Pago(Convert.ToInt32(oRow["Trans_medio_pago"]), Convert.ToString(oRow["str_Trans_medio_pago"])));
                }
                return lsTrans_Medio_Pago;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
