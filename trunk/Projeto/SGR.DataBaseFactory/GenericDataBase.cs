using System;
using System.Collections.Generic;
using System.Text;
using SGR.Data.Interfaces;
using SGR.DataBaseFactory.Configuration;
using SGR.Data.DataBases;
using System.Configuration;
using System.Xml;
using SGR.DataBaseFactory.Collection;
using System.Web.Configuration;
using SGR.DataBaseFactory.DataBases;


namespace SGR.DataBaseFactory
{

    
    public class GenericDataBase
    {
        private static DataBaseCollection _dataBases;
     
        public static DataBaseCollection DataBase
        {
            get
            {

                if (_dataBases == null)
                    _dataBases = GetDataBase();

                return _dataBases;
            }
        }

        private static DataBaseCollection GetDataBase()
        {
            DataBasesSection section = GetSection();

            DataBaseCollection collection = new DataBaseCollection();

            foreach (DataBaseElement element in section.DataBases)
            {
                collection.Add(element.Chave, CreateDataBase(element.Type, element.ConnectionString));
            }
            
            return collection;
        }

        private static IDataBase CreateDataBase(ETypeDataBase type, string connection)
        {
            IDataBase returnObject = null;
            switch (type)
            {
                case ETypeDataBase.MySql: returnObject = new MySqlDataBase(connection); break;
                case ETypeDataBase.SqlServer: returnObject = new SqlDataBase(connection); break;
                case ETypeDataBase.Oracle: throw new Exception("Tipo de Base não implementada");
                case ETypeDataBase.PostgreSQL: throw new Exception("Tipo de Base não implementada");
                case ETypeDataBase.FireBird: throw new Exception("Tipo de Base não implementada"); 
                default: throw new Exception("Tipo de Base não implementada"); 
            }
            return returnObject;
        }

        private static DataBasesSection GetSection()
        {
            DataBasesSection section = (DataBasesSection)ConfigurationManager.GetSection("databasefactory");
            if (section == null)
                section = (DataBasesSection)WebConfigurationManager.GetSection("databasefactory");
            
            if (section == null)
                return null;

            return section;
        }
    }
}
