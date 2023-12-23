using cmpComercio.Configuracion;
using cmpGeneral;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmpComercio.ModelosConstantes
{
    public class clsTrans_Estado
    {
        #region "Atributos"
        public int Trans_estado { get; set; }
        public string str_Trans_estado { get; set; }

        //De apoyo
        private clsAccesoDat oAD { get; set; }
        private List<clsStoreProcedures> oProcedimientos { get; set; }
        #endregion

        #region "Constructores"
        public clsTrans_Estado()
        {
            Trans_estado = 0;
            str_Trans_estado = "";
            DefinicionSP();
        }

        public clsTrans_Estado(int pTrans_estado, string pstr_Trans_estado)
        {
            Trans_estado = pTrans_estado;
            str_Trans_estado = pstr_Trans_estado;
        }
        #endregion

        #region "Métodos"
        private void DefinicionSP()
        {
            oProcedimientos = new List<clsStoreProcedures>();
            //Otener todos los producto
            oProcedimientos.Add(new clsStoreProcedures("SP_ObtenerEstados"));
        }
        public List<clsTrans_Estado> ObtenerEstados()
        {
            try
            {
                List<clsTrans_Estado> lsTrans_Estado = new List<clsTrans_Estado>();
                oAD = new clsAccesoDat(new clsConstante().strCadenaConexionSIC);

                DataView dv;
                dv = oAD.RunProcSQL_DataView(oProcedimientos[0].strNombreSP, this, oProcedimientos[0].oParams);
                foreach (DataRowView oRow in dv)
                {
                    lsTrans_Estado.Add(new clsTrans_Estado(Convert.ToInt32(oRow["Trans_estado"]), Convert.ToString(oRow["str_Trans_estado"])));
                }
                return lsTrans_Estado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
