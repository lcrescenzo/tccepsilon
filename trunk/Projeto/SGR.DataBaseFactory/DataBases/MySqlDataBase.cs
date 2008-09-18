using System;
using System.Collections.Generic;
using System.Text;
using SGR.Data.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;

namespace SGR.Data.DataBases
{
    internal class MySqlDataBase : IDataBase
    { 
        private string _connectionString = null;
        
        public MySqlDataBase(string pConnectionString)
        {
            _connectionString = pConnectionString;
        }
        
        #region Connection
        public IDbConnection GetConnectionObject()
        {
            return new MySqlConnection(_connectionString);
        }
        #endregion

        #region Command
        public IDbCommand GetCommandProcObject(System.Data.IDbConnection pConnection, string pProcName, List<IDataParameter> pParameters)
        {
            IDbCommand comm = new MySqlCommand();
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = pProcName;
            comm.Connection = pConnection;
            
            foreach(IDataParameter parameter in pParameters)
            {
                comm.CreateParameter();
                comm.Parameters.Add(parameter);
            }
            
            return comm;
        }

        public IDbCommand GetCommandQueryObject(System.Data.IDbConnection pConnection, string pQuery, List<IDataParameter> pParameters)
        {
            IDbCommand comm = new MySqlCommand();
            comm.CommandType = CommandType.Text;
            comm.CommandText = pQuery;
            comm.Connection = pConnection;
            
            foreach (IDataParameter parameter in pParameters)
            {
                comm.Parameters.Add(parameter);
            }

            return comm;
        }

        public IDbCommand GetCommandObject()
        {
            return new MySqlCommand();
        }
        #endregion

        #region Transaction
        public IDbTransaction GetTransactionObject(System.Data.IDbCommand pCommand)
        {
            return pCommand.Transaction;
        }
        #endregion

        #region Parameter
        public IDataParameter NewParameter()
        {
            return new MySqlParameter();
        }


        public IDataParameter NewParameter(string pParameterName, object pValue)
        {
            IDataParameter parameter = null;
            if (pValue == null)
            {
                parameter = new MySqlParameter();
                parameter.ParameterName = PrefixParameter + pParameterName;
            }
            else
                parameter = new MySqlParameter(PrefixParameter + pParameterName, pValue);
            
            return parameter;
        }

        public IDataParameter NewParameter(string pParameterName, DbType pType,object pValue)
        {
            IDataParameter parameter = new MySqlParameter(PrefixParameter + pParameterName, ConvertDbType(pType));
            if (pValue != null)
            {
                parameter.Value = pValue;
            }
            
            return parameter;
        }

        public IDataParameter NewOutputParameter(string pParameterName, DbType pType, object pValue)
        {
            IDataParameter parameter = NewParameter(pParameterName, pType, pValue);
            parameter.Direction = ParameterDirection.Output;
            return parameter;
        }
        #endregion

        private MySqlDbType ConvertDbType(DbType pType)
        {
            switch (pType)
            {
                case DbType.AnsiString: return MySqlDbType.String; 
                case DbType.AnsiStringFixedLength: return MySqlDbType.VarChar; 
                case DbType.Binary: return MySqlDbType.Binary; 
                case DbType.Boolean: return MySqlDbType.Bit; 
                case DbType.Byte: return MySqlDbType.Byte; 
                case DbType.Currency: return MySqlDbType.Decimal; 
                case DbType.Date: return MySqlDbType.Date; 
                case DbType.DateTime: return MySqlDbType.DateTime; 
                case DbType.DateTime2: return MySqlDbType.DateTime; 
                case DbType.DateTimeOffset: return MySqlDbType.DateTime; 
                case DbType.Decimal: return MySqlDbType.Decimal; 
                case DbType.Double: return MySqlDbType.Double; 
                case DbType.Guid: return MySqlDbType.String; 
                case DbType.Int16: return MySqlDbType.Int16; 
                case DbType.Int32: return MySqlDbType.Int32; 
                case DbType.Int64: return MySqlDbType.Int64; 
                case DbType.Object: throw new Exception("Tipo não suportado"); 
                case DbType.SByte: return MySqlDbType.UByte; 
                case DbType.Single: return MySqlDbType.Float; 
                case DbType.String: return MySqlDbType.VarChar; 
                case DbType.StringFixedLength: return MySqlDbType.VarChar; 
                case DbType.Time: return MySqlDbType.Time; 
                case DbType.UInt16: return MySqlDbType.UInt16; 
                case DbType.UInt32: return MySqlDbType.UInt32; 
                case DbType.UInt64: return MySqlDbType.UInt64; 
                case DbType.VarNumeric: return MySqlDbType.LongBlob; 
                case DbType.Xml: return MySqlDbType.LongText; 
                default: throw new Exception("Tipo não suportado"); 
            }
        }


        
        public string PrefixParameter
        {
            get { return string.Empty; }
        }

    }
}