using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using SGR.DataBaseFactory.DataBases;
using System.Xml;

namespace SGR.DataBaseFactory.Configuration
{
    #region Element
    public sealed class DataBaseElement : ConfigurationElement
    {
        public DataBaseElement(string newChave, string newConnectionString, ETypeDataBase newType)
        {
            Chave = newChave;
            ConnectionString = newConnectionString;
            Type = newType;

        }

        public DataBaseElement()
        {

        }

        public DataBaseElement(string elementName)
        {
            Chave = elementName;
        }

        [ConfigurationProperty("chave", DefaultValue = "database", IsRequired = true, IsKey = true)]
        public string Chave
        {
            get
            {
                return (string)this["chave"];
            }
            set
            {
                this["chave"] = value;
            }
        }

        [ConfigurationProperty("connectionstring", DefaultValue = "", IsRequired = true)]
        public string ConnectionString
        {
            get
            {
                return (string)this["connectionstring"];
            }
            set
            {
                this["connectionstring"] = value;
            }
        }

        [ConfigurationProperty("type", DefaultValue = ETypeDataBase.SqlServer, IsRequired = true)]
        public ETypeDataBase Type
        {
            get
            {
                return (ETypeDataBase)this["type"];
            }
            set
            {
                this["type"] = value;
            }
        }

        protected override void DeserializeElement(XmlReader reader, bool serializeCollectionKey)
        {
            base.DeserializeElement(reader, serializeCollectionKey);
        }
    }
    #endregion

    #region Collection

    public sealed class DataBasesCollection : ConfigurationElementCollection
    {
        public DataBasesCollection()
        {
            DataBaseElement database = (DataBaseElement)CreateNewElement();
            // Add the element to the collection.
            Add(database);
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new DataBaseElement();
        }
        
        protected override ConfigurationElement CreateNewElement(string elementName)
        {
            return new DataBaseElement(elementName);
        }
        
        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((DataBaseElement)element).Chave;
        }
        
        public new string AddElementName
        {
            get
            { return base.AddElementName; }

            set
            { base.AddElementName = value; }

        }

        public new string ClearElementName
        {
            get
            { return base.ClearElementName; }

            set
            { base.AddElementName = value; }

        }

        public new string RemoveElementName
        {
            get
            { return base.RemoveElementName; }


        }

        public new int Count
        {
            get { return base.Count; }
        }
        
        public DataBaseElement this[int indice]
        {
            get
            {
                return (DataBaseElement)BaseGet(indice);
            }
            set
            {
                if (BaseGet(indice) != null)
                {
                    BaseRemoveAt(indice);
                }
                BaseAdd(indice, value);
            }
        }

        new public DataBaseElement this[string Chave]
        {
            get
            {
                return (DataBaseElement)BaseGet(Chave);
            }
        }

        public int IndexOf(DataBaseElement dataBase)
        {
            return BaseIndexOf(dataBase);
        }

        public void Add(DataBaseElement dataBase)
        {
            BaseAdd(dataBase);

            // Add custom code here.
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
            //TODO: Avaliar
        }

        public void Remove(DataBaseElement dataBase)
        {
            if (BaseIndexOf(dataBase) >= 0)
                BaseRemove(dataBase.Chave);
        }

        public void RemoveAt(int indice)
        {
            BaseRemoveAt(indice);
        }

        public void Remove(string chave)
        {
            BaseRemove(chave);
        }

        public void Clear()
        {
            BaseClear();
            
        }
    }
    #endregion

    #region Section
    public sealed class DataBasesSection : ConfigurationSection
    {
        DataBaseElement dataBase;

        public DataBasesSection()
        {
            dataBase = new DataBaseElement();
        }

        [ConfigurationProperty("databases", IsDefaultCollection = false)]
        public DataBasesCollection DataBases
        {
            get
            {
                DataBasesCollection dataBasesCollection = (DataBasesCollection)base["databases"];
                return dataBasesCollection;
            }
        }

        protected override void DeserializeSection(System.Xml.XmlReader reader)
        {
            base.DeserializeSection(reader);
        }

        protected override string SerializeSection(ConfigurationElement parentElement, string name, ConfigurationSaveMode saveMode)
        {
            return base.SerializeSection(parentElement, name, saveMode);
        }

    }
    #endregion
}
