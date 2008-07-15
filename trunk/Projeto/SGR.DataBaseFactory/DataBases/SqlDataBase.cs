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

        public IDbCommand GetCommandQueryObject(IDbConnection pConnection, string pQuery, IDataParameterCollection pParameters)
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

        public IDbCommand GetCommandProcObject(IDbConnection pConnection, string pProcName, IDataParameterCollection pParameters)
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
                case DbType.AnsiString: return SqlDbType.VarChar; break;
                case DbType.AnsiStringFixedLength: return SqlDbType.NChar; break;
                case DbType.Binary: return SqlDbType.Binary; break;
                case DbType.Boolean: return SqlDbType.Bit; break;
                case DbType.Byte: return SqlDbType.Binary; break;
                case DbType.Currency: return SqlDbType.Money; break;
                case DbType.Date: return SqlDbType.Date; break;
                case DbType.DateTime: return SqlDbType.DateTime; break;
                case DbType.DateTime2: return SqlDbType.DateTime2; break;
                case DbType.DateTimeOffset: return SqlDbType.DateTimeOffset; break;
                case DbType.Decimal: return SqlDbType.Decimal; break;
                case DbType.Double: return SqlDbType.Decimal; break;
                case DbType.Guid: return SqlDbType.UniqueIdentifier; break;
                case DbType.Int16: return SqlDbType.SmallInt; break;
                case DbType.Int32: return SqlDbType.Int; break;
                case DbType.Int64: return SqlDbType.BigInt; break;
                case DbType.Object: return SqlDbType.Variant; break;
                case DbType.SByte: return SqlDbType.VarBinary; break;
                case DbType.Single: return SqlDbType.Float; break;
                case DbType.String: return SqlDbType.VarChar; break;
                case DbType.StringFixedLength: return SqlDbType.NVarChar; break;
                case DbType.Time: return SqlDbType.Time; break;
                case DbType.UInt16: return SqlDbType.SmallInt; break;
                case DbType.UInt32: return SqlDbType.Int; break;
                case DbType.UInt64: return SqlDbType.BigInt; break;
                case DbType.VarNumeric: return SqlDbType.Decimal; break;
                case DbType.Xml: return SqlDbType.Xml; break;
                default: throw new Exception("Tipo não suportado!"); break;
            }
        }

    }
}
