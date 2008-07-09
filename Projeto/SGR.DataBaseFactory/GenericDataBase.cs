using System;
using System.Collections.Generic;
using System.Text;
using SGR.Data.Interfaces;

namespace SGR.DataBaseFactory
{

    
    public class GenericDataBase
    {

        private static IDataBase _dataBase = null;
        
        public static IDataBase DataBase
        {
            get
            {
                return _dataBase;
            }
            internal set 
            {
                _dataBase = value;
            }

        }
    }
}
