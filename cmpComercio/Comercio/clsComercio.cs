using cmpComercio.Configuracion;
using cmpComercio.ModelosConstantes;
using cmpComercio.Transaccion;
using cmpGeneral;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmpComercio.Comercio
{
    public class clsComercio
    {
        #region "Atributos"
        public long comercio_codigo { get; set; }
        public string comercio_nombre { get; set; }
        public string comercio_nit { get; set; }
        public string comercio_direccion { get; set; }
        public string strUsuario { get; set; }
        public string strContrasenna { get; set; }

        //Externas
        public DataView dv { get; set; }
        public List<clsTransaccion> oListTransaccion { get; set; }

        //De apoyo
        public string identificador { get; set; }
        public int intAyuda { get; set; }
        private clsAccesoDat oAD { get; set; }
        private List<clsStoreProcedures> oProcedimientos { get; set; }
        #endregion

        #region "Constructores"
        public clsComercio()
        {
            comercio_codigo = 0;
            comercio_nombre = "";
            comercio_nit = "";
            comercio_direccion = "";
            strUsuario = "";
            strContrasenna = "";
            intAyuda = 0;
            identificador = "";

            oListTransaccion = new List<clsTransaccion>();
            DefinicionSP();
        }

        public clsComercio(long pcomercio_codigo, string pcomercio_nombre, string pcomercio_nit, string pcomercio_direccion, string pstrUsuario="", string pstrContrasenna="")
        {
            comercio_codigo = pcomercio_codigo;
            comercio_nombre = pcomercio_nombre;
            comercio_nit = pcomercio_nit;
            comercio_direccion = pcomercio_direccion;
            strUsuario = pstrUsuario;
            strContrasenna = pstrContrasenna;

            DefinicionSP();
        }
        #endregion

        #region "Métodos"
        private void DefinicionSP()
        {
            oProcedimientos = new List<clsStoreProcedures>();
            //Otener todos los producto
            oProcedimientos.Add(new clsStoreProcedures("SP_ObtenerComercios"));

            oProcedimientos.Add(new clsStoreProcedures("SP_TblComercio_Verifica_Agrega"));
            oProcedimientos[1].AddParametro("@comercio_codigo", OleDbType.Numeric, ParameterDirection.Input, DBNull.Value);
            oProcedimientos[1].AddParametro("@comercio_nombre", OleDbType.VarChar, ParameterDirection.Input, DBNull.Value,50);
            oProcedimientos[1].AddParametro("@comercio_nit", OleDbType.VarChar, ParameterDirection.Input, DBNull.Value, 50);
            oProcedimientos[1].AddParametro("@comercio_direccion", OleDbType.VarChar, ParameterDirection.Input, DBNull.Value, 50);
            
            oProcedimientos.Add(new clsStoreProcedures("SP_UsuarioExistente"));
            oProcedimientos[2].AddParametro("@identificador", OleDbType.VarChar, ParameterDirection.Input, DBNull.Value);
            oProcedimientos[2].AddParametro("@intAyuda", OleDbType.Integer, ParameterDirection.Input, DBNull.Value);

            oProcedimientos.Add(new clsStoreProcedures("SP_CrearUsuario"));
            oProcedimientos[3].AddParametro("@identificador", OleDbType.VarChar, ParameterDirection.Input, DBNull.Value);
            oProcedimientos[3].AddParametro("@strUsuario", OleDbType.VarChar, ParameterDirection.Input, DBNull.Value);
            oProcedimientos[3].AddParametro("@strContrasenna", OleDbType.VarChar, ParameterDirection.Input, DBNull.Value);
            oProcedimientos[3].AddParametro("@intAyuda", OleDbType.Integer, ParameterDirection.Input, DBNull.Value);

            oProcedimientos.Add(new clsStoreProcedures("SP_InicioSesion"));
            oProcedimientos[4].AddParametro("@strUsuario", OleDbType.VarChar, ParameterDirection.Input, DBNull.Value);
            oProcedimientos[4].AddParametro("@strContrasenna", OleDbType.VarChar, ParameterDirection.Input, DBNull.Value);
            oProcedimientos[4].AddParametro("@intAyuda", OleDbType.Integer, ParameterDirection.Input, DBNull.Value);
                        
        }
        public List<clsComercio> ObtenerComercios()
        {
            try
            {
                List<clsComercio> lsComercio = new List<clsComercio>();
                oAD = new clsAccesoDat(new clsConstante().strCadenaConexionSIC);

                DataView dv;
                dv = oAD.RunProcSQL_DataView(oProcedimientos[0].strNombreSP, this, oProcedimientos[0].oParams);
                foreach (DataRowView oRow in dv)
                {
                    lsComercio.Add(new clsComercio(Convert.ToInt64(oRow["comercio_codigo"]), Convert.ToString(oRow["comercio_nombre"]), 
                        Convert.ToString(oRow["comercio_nit"]), Convert.ToString(oRow["comercio_direccion"])));
                }
                return lsComercio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insertar_Comercio()
        {
            try
            {
                oAD = new clsAccesoDat(new clsConstante().strCadenaConexionSIC);
                comercio_codigo = oAD.RunProcSQL_Int(oProcedimientos[1].strNombreSP, this, oProcedimientos[1].oParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UsuarioExistente(string pcomercio_nit)
        {
            try
            {
                oAD = new clsAccesoDat(new clsConstante().strCadenaConexionSIC);
                comercio_nit = pcomercio_nit;
                identificador = pcomercio_nit;
                intAyuda = 2;

                //Respuesta 1-Existe y Tiene usuario - 2-Existe pero no tiene usuario
                return oAD.RunProcSQL_Int(oProcedimientos[2].strNombreSP, this, oProcedimientos[2].oParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CrearUsuario(string pcomercio_nit, string pstrUsuario, string pstrContrasenna)
        {
            try
            {
                oAD = new clsAccesoDat(new clsConstante().strCadenaConexionSIC);
                comercio_nit = pcomercio_nit;
                identificador = pcomercio_nit;
                strUsuario = pstrUsuario;
                strContrasenna = pstrContrasenna;
                intAyuda = 2;
                //resultado -1 usuario ya existente, resultado 1 exito al crear usuario
                return oAD.RunProcSQL_Int(oProcedimientos[3].strNombreSP, this, oProcedimientos[3].oParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InicioSesion(string pstrUsuario, string pstrContrasenna)
        {
            try
            {
                oAD = new clsAccesoDat(new clsConstante().strCadenaConexionSIC);
                strUsuario = pstrUsuario;
                strContrasenna = pstrContrasenna;
                intAyuda = 1;
                //Resultado mayor a 0 exitoso
                return oAD.RunProcSQL_Int(oProcedimientos[4].strNombreSP, this, oProcedimientos[4].oParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
