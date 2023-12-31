﻿using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;

namespace cmpGeneral
{
    public class clsAccesoDat
    {
        //Atributos
        private OleDbConnection oConexion { get; set; }
        private OleDbCommand oComando { get; set; }
        //permite consultar y resivir los datos
        private OleDbDataAdapter oAdapter { get; set; }
        //private OleDbDataReader oReader { get; set; }
        private DataSet oDatos { get; set; }

        public clsAccesoDat(string strCadena)
        {
            //Inicialisa conexion
            oConexion = new OleDbConnection(strCadena);
        }

        //Ejecuta el procedimiento en el SQL
        public bool RunProcSQL(string strNomProc, object oObjeto, List<OleDbParameter> oParametros)
        {
            try
            {
                RefinarParametros(oObjeto, ref oParametros);

                oComando = new OleDbCommand(strNomProc, oConexion);
                oComando.CommandTimeout = 100;
                oComando.CommandType = CommandType.StoredProcedure;
                foreach (var item in oParametros)
                {
                    oComando.Parameters.Add(item);
                }

                oConexion.Open();
                oComando.ExecuteNonQuery();
                oConexion.Close();
                oComando.Parameters.Clear();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Ejecuta el procedimiento en el SQL obteniendo su respuesta (si es auto increment obtiene su resultado)
        public int RunProcSQL_Int(string strNomProc, object oObjeto, List<OleDbParameter> oParametros)
        {
            try
            {
                int intResul;

                RefinarParametros(oObjeto, ref oParametros);

                oComando = new OleDbCommand(strNomProc, oConexion);
                oComando.CommandTimeout = 100;
                oComando.CommandType = CommandType.StoredProcedure;
                //Variables solicitadas por el procedimiento
                foreach (var item in oParametros)
                {
                    oComando.Parameters.Add(item);
                }

                oConexion.Open();
                intResul = Convert.ToInt32(oComando.ExecuteScalar());
                oConexion.Close();
                oComando.Parameters.Clear();

                return intResul;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Obtener listas como select solicitados
        public DataView RunProcSQL_DataView(string strNomProc, object oObjeto, List<OleDbParameter> oParametros)
        {
            try
            {
                RefinarParametros(oObjeto, ref oParametros);

                oComando = new OleDbCommand(strNomProc, oConexion);
                oComando.Parameters.Clear();
                oComando.CommandTimeout = 1000;
                oComando.CommandType = CommandType.StoredProcedure;
                foreach (var item in oParametros)
                {
                    oComando.Parameters.Add(item);
                }

                oConexion.Open();
                //permite consultar y resivir los datos
                oAdapter = new OleDbDataAdapter(oComando);
                oDatos = new DataSet();
                oAdapter.Fill(oDatos);
                oConexion.Close();
                oComando.Parameters.Clear();

                return new DataView(oDatos.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Organisar los valores para las variables
        private void RefinarParametros(object oObjeto, ref List<OleDbParameter> oParametros)
        {
            //Otorga los valores de las variables definidas en las clase para los parametros SQL
            foreach (var oProp in oObjeto.GetType().GetProperties())
            {
                if (oParametros.Find(x => x.ParameterName == "@" + oProp.Name) != null)
                {
                    oParametros.Find(x => x.ParameterName == "@" + oProp.Name).Value = oProp.GetValue(oObjeto, null);
                }
            }
        }
    }
}
