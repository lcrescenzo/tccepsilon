using System;
using System.Collections.Generic;
using System.Text;
using SGR.Data.Interfaces;
using SGR.DataBaseFactory.Configuration;
using SGR.Data.DataBases;
using System.Configuration;


namespace SGR.DataBaseFactory
{

    
    public class GenericDataBase
    {

        private static IDataBase _dataBase = null;
        
        public static IDataBase DataBase
        {
            get
            {

                if (_dataBase == null)
                    _dataBase = GetDataBase();

                return _dataBase;
            }
            internal set 
            {
                _dataBase = value;
            }

        }

        private static IDataBase GetDataBase()
        {
            IDataBase returnObject;
            DataBaseSection dataBase = (DataBaseSection)ConfigurationManager.GetSection("system.web/myConfig");

            switch (dataBase.Type)
            {
                case DataBaseType.MySql: returnObject = new MySqlDataBase(dataBase.ConnectionString); break;
                case DataBaseType.SqlServer: returnObject = new SqlDataBase(dataBase.ConnectionString); break;
                case DataBaseType.Oracle: throw new Exception("Tipo de Base não implementada"); break;
                case DataBaseType.PostgreSql: throw new Exception("Tipo de Base não implementada"); break;
                case DataBaseType.Firebird: throw new Exception("Tipo de Base não implementada"); break;
                default: throw new Exception("Tipo de Base não implementada"); break;
            }
            return returnObject;
        }
    }
}
