using cmpComercio.Comercio;
using cmpComercio.Configuracion;
using cmpGeneral;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmpComercio.Transaccion
{
    public class clsTransaccion
    {
        #region "Atributos"
        public long Trans_codigo { get; set; }
        public int Trans_medio_pago { get; set; }
        public int Trans_estado { get; set; }
        public string strTrans_medio_pago { get; set; }
        public string strTrans_estado { get; set; }
        public double Trans_total { get; set; }
        public DateTime Trans_fecha { get; set; }
        public string Trans_concepto { get; set; }
        public long comercio_codigo { get; set; }
        public string usuario_identificacion { get; set; }

        //De apoyo
        public string strPuedeEditar { get; set; }
        public string comercio_nit { get; set; }
        public DateTime Trans_fechaIni { get; set; }
        public DateTime Trans_fechaFin { get; set; }
        public DataView dv { get; set; }
        private clsAccesoDat oAD { get; set; }
        private List<clsStoreProcedures> oProcedimientos { get; set; }
        #endregion


        #region "Constructores"
        public clsTransaccion()
        {
            Trans_codigo = 0;
            Trans_medio_pago = 0;
            Trans_estado = 0;
            Trans_total = 0;
            Trans_fecha = DateTime.Now;
            Trans_concepto = "";
            comercio_codigo = 0;
            usuario_identificacion = "";
            strTrans_medio_pago = "";
            strTrans_estado = "";
            comercio_nit = "";
            Trans_fechaIni = DateTime.Now;
            Trans_fechaFin = DateTime.Now;
            strPuedeEditar = "";

            DefinicionSP();
        }

        public clsTransaccion(long pTrans_codigo, int pTrans_medio_pago, int pTrans_estado, double pTrans_total, DateTime pTrans_fecha, string pTrans_concepto,
            long pcomercio_codigo, string pusuario_identificacion, string pstrTrans_medio_pago = "", string pstrTrans_estado = "", string pstrPuedeEditar = "")
        {
            Trans_codigo = pTrans_codigo;
            Trans_medio_pago = pTrans_medio_pago;
            Trans_estado = pTrans_estado;
            Trans_total = pTrans_total;
            Trans_fecha = pTrans_fecha;
            Trans_concepto = pTrans_concepto;
            comercio_codigo = pcomercio_codigo;
            usuario_identificacion = pusuario_identificacion;
            strTrans_medio_pago = pstrTrans_medio_pago;
            strTrans_estado = pstrTrans_estado;
            strPuedeEditar = pstrPuedeEditar;

            DefinicionSP();
        }
        #endregion

        #region "Métodos"
        private void DefinicionSP()
        {
            oProcedimientos = new List<clsStoreProcedures>();
            //Otener todos los producto
            oProcedimientos.Add(new clsStoreProcedures("SP_ObtenerTransaccionesComercio"));
            oProcedimientos[0].AddParametro("@comercio_nit", OleDbType.VarChar, ParameterDirection.Input, DBNull.Value);
            oProcedimientos[0].AddParametro("@Trans_fechaIni", OleDbType.Date, ParameterDirection.Input, DBNull.Value);
            oProcedimientos[0].AddParametro("@Trans_fechaFin", OleDbType.Date, ParameterDirection.Input, DBNull.Value);
            oProcedimientos[0].AddParametro("@Trans_codigo", OleDbType.Numeric, ParameterDirection.Input, DBNull.Value);
            oProcedimientos[0].AddParametro("@usuario_identificacion", OleDbType.VarChar, ParameterDirection.Input, DBNull.Value);

            oProcedimientos.Add(new clsStoreProcedures("SP_TblTransaccion_Verifica_Agrega"));
            oProcedimientos[1].AddParametro("@Trans_codigo", OleDbType.Numeric, ParameterDirection.Input, DBNull.Value);
            oProcedimientos[1].AddParametro("@Trans_medio_pago", OleDbType.Integer, ParameterDirection.Input, DBNull.Value, 50);
            oProcedimientos[1].AddParametro("@Trans_estado", OleDbType.Integer, ParameterDirection.Input, DBNull.Value);
            oProcedimientos[1].AddParametro("@Trans_total", OleDbType.Numeric, ParameterDirection.Input, DBNull.Value, 50);
            oProcedimientos[1].AddParametro("@Trans_fecha", OleDbType.Date, ParameterDirection.Input, DBNull.Value);
            oProcedimientos[1].AddParametro("@Trans_concepto", OleDbType.VarChar, ParameterDirection.Input, DBNull.Value, 100);
            oProcedimientos[1].AddParametro("@comercio_codigo", OleDbType.Numeric, ParameterDirection.Input, DBNull.Value);
            oProcedimientos[1].AddParametro("@usuario_identificacion", OleDbType.VarChar, ParameterDirection.Input, DBNull.Value, 50);

            oProcedimientos.Add(new clsStoreProcedures("SP_ObtenerTransaccion"));
            oProcedimientos[2].AddParametro("@Trans_codigo", OleDbType.Numeric, ParameterDirection.Input, DBNull.Value);

            oProcedimientos.Add(new clsStoreProcedures("SP_ActualizarTransaccion"));
            oProcedimientos[3].AddParametro("@Trans_codigo", OleDbType.Numeric, ParameterDirection.Input, DBNull.Value);
            oProcedimientos[3].AddParametro("@Trans_medio_pago", OleDbType.Integer, ParameterDirection.Input, DBNull.Value, 50);
            oProcedimientos[3].AddParametro("@Trans_estado", OleDbType.Integer, ParameterDirection.Input, DBNull.Value);
            oProcedimientos[3].AddParametro("@Trans_total", OleDbType.Numeric, ParameterDirection.Input, DBNull.Value, 50);
            oProcedimientos[3].AddParametro("@Trans_fecha", OleDbType.Date, ParameterDirection.Input, DBNull.Value);
            oProcedimientos[3].AddParametro("@Trans_concepto", OleDbType.VarChar, ParameterDirection.Input, DBNull.Value, 100);
        }

        public List<clsTransaccion> ObtenerTransaccionesComercio(string pcomercio_nit, DateTime pTrans_fechaIni, DateTime pTrans_fechaFin,
            long pTrans_codigo, string pusuario_identificacion)
        {
            try
            {
                List<clsTransaccion> oListTransaccion = new List<clsTransaccion>();
                DataView dv;
                oAD = new clsAccesoDat(new clsConstante().strCadenaConexionSIC);
                comercio_nit = pcomercio_nit;
                Trans_fechaIni = pTrans_fechaIni;
                Trans_fechaFin = pTrans_fechaFin;
                Trans_codigo = pTrans_codigo;
                usuario_identificacion = pusuario_identificacion;

                dv = oAD.RunProcSQL_DataView(oProcedimientos[0].strNombreSP, this, oProcedimientos[0].oParams);
                foreach (DataRowView oRow in dv)
                {
                    oListTransaccion.Add(new clsTransaccion(Convert.ToInt64(oRow["Trans_codigo"]), Convert.ToInt32(oRow["Trans_medio_pago"]),
                        Convert.ToInt32(oRow["Trans_estado"]), Convert.ToDouble(oRow["Trans_total"]), Convert.ToDateTime(oRow["Trans_fecha"]),
                        Convert.ToString(oRow["Trans_concepto"]), Convert.ToInt64(oRow["comercio_codigo"]), Convert.ToString(oRow["usuario_identificacion"]),
                        Convert.ToString(oRow["strTrans_medio_pago"]), Convert.ToString(oRow["strTrans_estado"]), 
                        (Convert.ToInt32(oRow["intPuedeEditar"])==1?"Actualizar":"...")));
                }
                return oListTransaccion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insertar_Transaccion()
        {
            try
            {
                oAD = new clsAccesoDat(new clsConstante().strCadenaConexionSIC);
                Trans_codigo = oAD.RunProcSQL_Int(oProcedimientos[1].strNombreSP, this, oProcedimientos[1].oParams);
                return Trans_codigo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerTransaccion(long pTrans_codigo, ref clsTransaccion oTransaccion)
        {
            try
            {
                DataView dv;
                oAD = new clsAccesoDat(new clsConstante().strCadenaConexionSIC);
                Trans_codigo = pTrans_codigo;

                dv = oAD.RunProcSQL_DataView(oProcedimientos[2].strNombreSP, this, oProcedimientos[2].oParams);
                foreach (DataRowView oRow in dv)
                {
                    oTransaccion.Trans_codigo = pTrans_codigo;
                    oTransaccion.Trans_medio_pago = Convert.ToInt32(oRow["Trans_medio_pago"]);
                    oTransaccion.Trans_estado = Convert.ToInt32(oRow["Trans_estado"]);
                    oTransaccion.Trans_total = Convert.ToDouble(oRow["Trans_total"]);
                    oTransaccion.Trans_fecha = Convert.ToDateTime(oRow["Trans_fecha"]);
                    oTransaccion.Trans_concepto = Convert.ToString(oRow["Trans_concepto"]);
                    oTransaccion.comercio_codigo = Convert.ToInt64(oRow["comercio_codigo"]);
                    oTransaccion.usuario_identificacion = Convert.ToString(oRow["usuario_identificacion"]);
                    oTransaccion.strTrans_medio_pago = Convert.ToString(oRow["strTrans_medio_pago"]);
                    oTransaccion.strTrans_estado = Convert.ToString(oRow["strTrans_estado"]);
                    oTransaccion.strPuedeEditar = (Convert.ToInt32(oRow["intPuedeEditar"]) == 1 ? "Actualizar" : "...");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ActualizarTransaccion(long pTrans_codigo, int pTrans_medio_pago, int pTrans_estado, double pTrans_total, DateTime pTrans_fecha,
            string pTrans_concepto)
        {
            try
            {
                oAD = new clsAccesoDat(new clsConstante().strCadenaConexionSIC);
                Trans_codigo = pTrans_codigo;
                Trans_medio_pago = pTrans_medio_pago;
                Trans_estado = pTrans_estado;
                Trans_total = pTrans_total;
                Trans_fecha = pTrans_fecha;
                Trans_concepto = pTrans_concepto;

                int result = oAD.RunProcSQL_Int(oProcedimientos[3].strNombreSP, this, oProcedimientos[3].oParams);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
