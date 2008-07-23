using System;
using System.Web;
using System.Xml;
using System.Configuration;
using SGR.Data.DataBases;

namespace SGR.DataBaseFactory.Configuration
{
    public enum DataBaseType
    {
        MySql,
        SqlServer,
        Oracle,
        PostgreSql,
        Firebird
    }

    public class DataBaseSectionHandler : IConfigurationSectionHandler
    {
        public virtual object Create(object parent, object configContext, XmlNode section)
        {
            int iLevel = 0;
            string sName = string.Empty;
    	
            ConfigHelper.GetEnumValue(section, "type", typeof(DataBaseType), ref iLevel);
            ConfigHelper.GetStringValue(section, "connectionstring", ref sName);
            return new DataBaseSection((DataBaseType)iLevel, sName);
        }
    }
    
    public class DataBaseSection
    {
        private DataBaseType _dataBaseType = DataBaseType.SqlServer;
        private string _connectionString = string.Empty;
      
        public DataBaseSection(DataBaseType pDataBaseType, string pConnectionString)
        {
            _dataBaseType = pDataBaseType;
            _connectionString = pConnectionString;
        }
        public DataBaseType Type
        {
            get {return _dataBaseType;}
        }
        
        public string ConnectionString
        {
            get {return _connectionString;}
        }
    }
    
    internal class ConfigHelper
    {
        public static XmlNode GetEnumValue(XmlNode _node, string _attribute,Type _enumType, ref int _val)
        {
            XmlNode a = _node.Attributes.RemoveNamedItem(_attribute);
            if(a==null)
                throw new ConfigurationErrorsException("Attribute required: " + _attribute);
            
            if(Enum.IsDefined(_enumType, a.Value))
                _val = (int)Enum.Parse(_enumType,a.Value);
            else
                throw new ConfigurationErrorsException("Invalid Level", a);
            
            return a;
        }
        
        public static XmlNode GetStringValue(XmlNode _node, string _attribute, ref string _val)
        {
            XmlNode a = _node.Attributes.RemoveNamedItem(_attribute);
            if(a==null)
                throw new ConfigurationErrorsException("Attribute required: " + _attribute);
            else
                _val = a.Value;
            return a;		
        }
    }
}
	