using System;
using System.Collections.Generic;
using System.Text;
using SGR.Data.Interfaces;

namespace SGR.BP.Util
{
    public class DataBaseParameters
    {
        public DataBaseParameters(ETypeDataBase pTypeDataBase, string pConnectionString)
        {
        }

        private ETypeDataBase _typeDataBase;

        internal ETypeDataBase TypeDataBase
	    {
		    get { return _typeDataBase;}
	    }

        internal string _connectionString;

        public string ConnectionString
        {
            get { return ConnectionString; }
        }
    }
}
