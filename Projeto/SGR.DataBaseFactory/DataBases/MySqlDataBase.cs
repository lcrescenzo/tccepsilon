using System;
using System.Collections.Generic;
using System.Text;
using SGR.Data.Interfaces;
using MySql.Data.MySqlClient;

namespace SGR.Data.DataBases
{
    internal class MySqlDataBase : IDataBase
    {
        public MySqlDataBase(string pConnectionString)
        {
            _connectionString = pConnectionString;
        }

        private string _connectionString = null;
        
        public System.Data.IDbConnection GetConnectionObject()
        {
            return new MySqlConnection(_connectionString);
        }

        public System.Data.IDbCommand GetCommandObject()
        {
            return new MySqlCommand();
        }

        public System.Data.IDbTransaction GetTransactionObject(System.Data.IDbCommand pCommand)
        {
            return pCommand.Transaction;
        }

        public System.Data.IDataParameter NewParameter()
        {
            return new MySqlParameter();
        }

    }
}
