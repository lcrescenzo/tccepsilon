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
        IDbTransaction GetTransactionObject(IDbCommand pCommand);
        IDataParameter NewParameter();

    }
}
