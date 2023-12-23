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

namespace cmpComercio.Usuario
{
    public class clsUsuario
    {
        #region "Atributos"
        public string usuario_identificacion { get; set; }
        public string usuario_nombre { get; set; }
        public string usuario_email { get; set; }
        public string strUsuario { get; set; }
        public string strContrasenna { get; set; }

        //De apoyo
        public string identificador { get; set; }
        public int intAyuda { get; set; }
        private clsAccesoDat oAD { get; set; }
        private List<clsStoreProcedures> oProcedimientos { get; set; }
        #endregion

        #region "Constructores"
        public clsUsuario()
        {
            usuario_identificacion = "";
            usuario_nombre = "";
            usuario_email = "";
            strUsuario = "";
            strContrasenna = "";
            intAyuda = 0;
            identificador = "";

            DefinicionSP();
        }

        public clsUsuario(string pusuario_identificacion, string pusuario_nombre, string pusuario_email, string pstrUsuario = "", string pstrContrasenna = "")
        {
            usuario_identificacion = pusuario_identificacion;
            usuario_nombre = pusuario_nombre;
            usuario_email = pusuario_email;
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
            oProcedimientos.Add(new clsStoreProcedures("SP_ObtenerTransaccionesPagador"));
            oProcedimientos[0].AddParametro("@usuario_identificacion", OleDbType.VarChar, ParameterDirection.Input, DBNull.Value);

            oProcedimientos.Add(new clsStoreProcedures("SP_TblUsuario_Verifica_Agrega"));
            oProcedimientos[1].AddParametro("@usuario_identificacion", OleDbType.VarChar, ParameterDirection.Input, DBNull.Value);
            oProcedimientos[1].AddParametro("@usuario_nombre", OleDbType.VarChar, ParameterDirection.Input, DBNull.Value);
            oProcedimientos[1].AddParametro("@usuario_email", OleDbType.VarChar, ParameterDirection.Input, DBNull.Value);

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
        public List<clsTransaccion> ObtenerTransaccionesPagador(string pusuario_identificacion)
        {
            try
            {
                List<clsTransaccion> oListTransaccion = new List<clsTransaccion>();
                DataView dv;
                oAD = new clsAccesoDat(new clsConstante().strCadenaConexionSIC);
                usuario_identificacion = pusuario_identificacion;
                
                dv = oAD.RunProcSQL_DataView(oProcedimientos[0].strNombreSP, this, oProcedimientos[0].oParams);
                foreach (DataRowView oRow in dv)
                {
                    oListTransaccion.Add(new clsTransaccion(Convert.ToInt64(oRow["Trans_codigo"]), Convert.ToInt32(oRow["Trans_medio_pago"]),
                        Convert.ToInt32(oRow["Trans_estado"]), Convert.ToDouble(oRow["Trans_total"]), Convert.ToDateTime(oRow["Trans_fecha"]),
                        Convert.ToString(oRow["Trans_concepto"]), Convert.ToInt64(oRow["comercio_codigo"]), Convert.ToString(oRow["usuario_identificacion"]),
                        Convert.ToString(oRow["strTrans_medio_pago"]), Convert.ToString(oRow["strTrans_estado"])));
                }
                return oListTransaccion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insertar_usuario()
        {
            try
            {
                oAD = new clsAccesoDat(new clsConstante().strCadenaConexionSIC);
                oAD.RunProcSQL(oProcedimientos[1].strNombreSP, this, oProcedimientos[1].oParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UsuarioExistente(string pusuario_identificacion)
        {
            try
            {
                oAD = new clsAccesoDat(new clsConstante().strCadenaConexionSIC);
                usuario_identificacion = pusuario_identificacion;
                identificador = pusuario_identificacion;
                intAyuda = 1;

                //Respuesta 1-Existe y Tiene usuario - 2-Existe pero no tiene usuario
                int result = oAD.RunProcSQL_Int(oProcedimientos[2].strNombreSP, this, oProcedimientos[2].oParams);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CrearUsuario(string pusuario_identificacion, string pstrUsuario, string pstrContrasenna)
        {
            try
            {
                oAD = new clsAccesoDat(new clsConstante().strCadenaConexionSIC);
                usuario_identificacion = pusuario_identificacion;
                identificador = pusuario_identificacion;
                strUsuario = pstrUsuario;
                strContrasenna = pstrContrasenna;
                intAyuda = 1;
                //resultado -1 usuario ya existente, resultado 1 exito al crear usuario
                return oAD.RunProcSQL_Int(oProcedimientos[3].strNombreSP, this, oProcedimientos[3].oParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InicioSesion(string pstrUsuario,string pstrContrasenna)
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
