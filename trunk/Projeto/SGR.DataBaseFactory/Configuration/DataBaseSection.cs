using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Xml;
using SGR.Data.DataBases;

namespace SGR.DataBaseFactory.Configuration
{
    class DataBaseSection : IConfigurationSectionHandler
    {

        #region IConfigurationSectionHandler Members

        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            foreach (XmlNode node in section.ChildNodes)
	        {
                if(node.Name == "DataBase")
                {
                    if (node.Attributes.GetNamedItem("Type") == null)
                        throw new Exception("O atributo Type da seção DataBase não foi definido.");

                    if (node.Attributes.GetNamedItem("ConnectionString") == null)
                        throw new Exception("O atributo ConnectionString da seção DataBase não foi definido.");

                    switch(node.Attributes.GetNamedItem("Type").Value)
                    {
                        case "SqlServer": GenericDataBase.DataBase = new SqlDataBase(node.Attributes.GetNamedItem("ConnectionString").Value); break;
                        case "MySql": GenericDataBase.DataBase = new MySqlDataBase(node.Attributes.GetNamedItem("ConnectionString").Value); break;
                    }
                }
	        }
            return GenericDataBase.DataBase;
        }

        #endregion
    }
}
