using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SGR.Data.Interfaces
{
    public interface IDataBase
    {
        IDbConnection GetConnectionObject();
        IDbCommand GetCommandObject();
        IDbCommand GetCommandQueryObject(System.Data.IDbConnection pConnection, string pQuery, IDataParameterCollection pParameters);
        IDbCommand GetCommandProcObject(System.Data.IDbConnection pConnection, string pProcName, IDataParameterCollection pParameters);
        IDbTransaction GetTransactionObject(IDbCommand pCommand);
        IDataParameter NewParameter();
        IDataParameter NewParameter(string pParameterName, DbType pType,object pValue);
        IDataParameter NewOutputParameter(string pParameterName, DbType pType, object pValue);
    }
}
