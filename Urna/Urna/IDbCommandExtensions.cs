﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class IDbCommandExtensions
    {
        //IDbCommand.protorype.addParameter = function(nome,value){...}
        public static void AddParameter(this IDbCommand cmd, string nome, object value)
        {
            IDbDataParameter param = cmd.CreateParameter();
            param.ParameterName = nome;
            param.Value = value ?? DBNull.Value;

            cmd.Parameters.Add(param);
        }
    }
}
