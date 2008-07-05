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

        public IDbConnection GetConnectionObject()
        {
            return new SqlConnection(_connectionString);
        }

        public IDbCommand GetCommandObject()
        {
            return new SqlCommand();
        }

        public IDbTransaction GetTransactionObject(IDbCommand pCommand)
        {
            return pCommand.Transaction;
        }

        public IDataParameter NewParameter()
        {
            return new SqlParameter();
        }
    }
}
