﻿using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;

namespace cmpGeneral
{
    public class clsStoreProcedures
    {
        public string strNombreSP { get; set; }
        public List<OleDbParameter> oParams { get; set; }

        public clsStoreProcedures(string pstrNombreSP)
        {
            strNombreSP = pstrNombreSP;
            oParams = new List<OleDbParameter>();
        }

        public void AddParametro(string ParameterName, OleDbType OleDbType, ParameterDirection Direction, Object Value)
        {
            OleDbParameter oParam = new OleDbParameter();
            oParam.ParameterName = ParameterName;
            oParam.OleDbType = OleDbType;
            oParam.Direction = Direction;
            oParam.Value = Value;
            oParams.Add(oParam);
        }

        public void AddParametro(string ParameterName, OleDbType OleDbType, ParameterDirection Direction, Object Value, int Size)
        {
            OleDbParameter oParam = new OleDbParameter();
            oParam.ParameterName = ParameterName;
            oParam.OleDbType = OleDbType;
            oParam.Direction = Direction;
            oParam.Value = Value;
            oParam.Size = Size;
            oParams.Add(oParam);
        }
    }
}
