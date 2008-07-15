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
        public IDbCommand GetCommandProcObject(System.Data.IDbConnection pConnection, string pProcName, IDataParameterCollection pParameters)
        {
            IDbCommand comm = new MySqlCommand();
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = pProcName;
            comm.Connection = pConnection;
            foreach(IDataParameter parameter in pParameters)
            {
                comm.Parameters.Add(parameter);
            }

            return comm;
        }

        public IDbCommand GetCommandQueryObject(System.Data.IDbConnection pConnection, string pQuery, IDataParameterCollection pParameters)
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

        public IDataParameter NewParameter(string pParameterName, DbType pType,object pValue)
        {
            IDataParameter parameter = new MySqlParameter(pParameterName, ConvertDbType(pType));
            if (pValue != null)
                parameter.Value = pValue;
            else
                parameter.Value = DBNull.Value;

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
                case DbType.AnsiString: return MySqlDbType.String; break;
                case DbType.AnsiStringFixedLength: return MySqlDbType.VarChar; break;
                case DbType.Binary: return MySqlDbType.Binary; break;
                case DbType.Boolean: return MySqlDbType.Bit; break;
                case DbType.Byte: return MySqlDbType.Byte; break;
                case DbType.Currency: return MySqlDbType.Decimal; break;
                case DbType.Date: return MySqlDbType.Date; break;
                case DbType.DateTime: return MySqlDbType.DateTime; break;
                case DbType.DateTime2: return MySqlDbType.Datetime; break;
                case DbType.DateTimeOffset: return MySqlDbType.Datetime; break;
                case DbType.Decimal: return MySqlDbType.Decimal; break;
                case DbType.Double: return MySqlDbType.Double; break;
                case DbType.Guid: return MySqlDbType.String; break;
                case DbType.Int16: return MySqlDbType.Int16; break;
                case DbType.Int32: return MySqlDbType.Int32; break;
                case DbType.Int64: return MySqlDbType.Int64; break;
                case DbType.Object: throw new Exception("Tipo não suportado"); break;
                case DbType.SByte: return MySqlDbType.UByte; break;
                case DbType.Single: return MySqlDbType.Float; break;
                case DbType.String: return MySqlDbType.String; break;
                case DbType.StringFixedLength: return MySqlDbType.VarChar; break;
                case DbType.Time: return MySqlDbType.Time; break;
                case DbType.UInt16: return MySqlDbType.UInt16; break;
                case DbType.UInt32: return MySqlDbType.UInt32; break;
                case DbType.UInt64: return MySqlDbType.UInt64; break;
                case DbType.VarNumeric: return MySqlDbType.LongBlob; break;
                case DbType.Xml: return MySqlDbType.LongText; break;
                default: throw new Exception("Tipo não suportado"); break;
            }
        }

    }
}