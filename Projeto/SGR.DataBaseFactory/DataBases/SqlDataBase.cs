using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SGR.Data.Interfaces;

namespace SGR.Data.DataBases
{
    internal class SqlDataBase : IDataBase
    {
        public SqlDataBase(string pConnectionString)
        {
            _connectionString = pConnectionString;
        }

        private string _connectionString = null;

        #region Connection
        public IDbConnection GetConnectionObject()
        {
            return new SqlConnection(_connectionString);
        }
        #endregion

        #region Command
        public IDbCommand GetCommandObject()
        {
            return new SqlCommand();
        }

        public IDbCommand GetCommandQueryObject(IDbConnection pConnection, string pQuery, List<IDataParameter> pParameters)
        {
            IDbCommand comm = new SqlCommand();
            comm.CommandType = CommandType.Text;
            comm.CommandText = pQuery;
            comm.Connection = pConnection;
            foreach (IDataParameter parameter in pParameters)
            {
                comm.Parameters.Add(parameter);
            }

            return comm;
        }

        public IDbCommand GetCommandProcObject(IDbConnection pConnection, string pProcName, List<IDataParameter> pParameters)
        {
            IDbCommand comm = new SqlCommand();
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = pProcName;
            comm.Connection = pConnection;
            foreach (IDataParameter parameter in pParameters)
            {
                comm.Parameters.Add(parameter);
            }

            return comm;
        }
        #endregion

        #region Transaction
        public IDbTransaction GetTransactionObject(IDbCommand pCommand)
        {
            return pCommand.Transaction;
        }
        #endregion

        #region Parameter
        public IDataParameter NewParameter()
        {
            return new SqlParameter();
        }

        public IDataParameter NewParameter(string pParameterName, DbType pType, object pValue)
        {
            IDbDataParameter parameter = new SqlParameter(pParameterName, pType);
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

        internal SqlDbType ConvetDbType(DbType pType)
        {
            switch (pType)
            {
                case DbType.AnsiString: return SqlDbType.VarChar; 
                case DbType.AnsiStringFixedLength: return SqlDbType.NChar; 
                case DbType.Binary: return SqlDbType.Binary; 
                case DbType.Boolean: return SqlDbType.Bit; 
                case DbType.Byte: return SqlDbType.Binary; 
                case DbType.Currency: return SqlDbType.Money; 
                case DbType.Date: return SqlDbType.Date; 
                case DbType.DateTime: return SqlDbType.DateTime; 
                case DbType.DateTime2: return SqlDbType.DateTime2; 
                case DbType.DateTimeOffset: return SqlDbType.DateTimeOffset; 
                case DbType.Decimal: return SqlDbType.Decimal; 
                case DbType.Double: return SqlDbType.Decimal; 
                case DbType.Guid: return SqlDbType.UniqueIdentifier; 
                case DbType.Int16: return SqlDbType.SmallInt; 
                case DbType.Int32: return SqlDbType.Int; 
                case DbType.Int64: return SqlDbType.BigInt; 
                case DbType.Object: return SqlDbType.Variant; 
                case DbType.SByte: return SqlDbType.VarBinary;
                case DbType.Single: return SqlDbType.Float; 
                case DbType.String: return SqlDbType.VarChar; 
                case DbType.StringFixedLength: return SqlDbType.NVarChar; 
                case DbType.Time: return SqlDbType.Time; 
                case DbType.UInt16: return SqlDbType.SmallInt; 
                case DbType.UInt32: return SqlDbType.Int; 
                case DbType.UInt64: return SqlDbType.BigInt; 
                case DbType.VarNumeric: return SqlDbType.Decimal; 
                case DbType.Xml: return SqlDbType.Xml; 
                default: throw new Exception("Tipo não suportado!"); 
            }
        }

    }
}
