using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using SGR.Data.Interfaces;
using SGR.BP.Util;
using SGR.DataBaseFactory;

namespace SGR.BP.Bases
{
    internal class DaoBase
    {
        private static IDataBase _database;

        protected static IDataBase DataBase
        {
            get
            {
                if (General.IsNullOrDisposed(_database))
                    _database = GenericDataBase.DataBase;

                return _database;
            }
        }

        protected bool AlterarBase(System.Data.IDbCommand pCommand, IDataParameterCollection pParameterColection)
        {
            
            if(pCommand.Connection.State != System.Data.ConnectionState.Open)
                throw new Exception("A conexão deve ser aberta antes de alterar um Objeto");

            return (pCommand.ExecuteNonQuery() > 0);
        }

        protected bool ExcluirBase(System.Data.IDbCommand pCommand, IDataParameterCollection pParameterColection)
        {
            if (pCommand.Connection.State != System.Data.ConnectionState.Open)
                throw new Exception("A conexão deve ser aberta antes de apagar um Objeto");

            return (pCommand.ExecuteNonQuery() > 0);
        }

        protected int IncluirBase(System.Data.IDbCommand pCommand, IDataParameterCollection pParameterColection)
        {
            if (pCommand.Connection.State != System.Data.ConnectionState.Open)
                throw new Exception("A conexão deve ser aberta antes de alterar um Objeto");

            return (int)pCommand.ExecuteScalar();
        }

        protected static List<T> ListaBase<T>(System.Data.IDbCommand pCommand, IDataParameterCollection pParameterColection) where T : ObjectBase
        {
            if (pCommand.Connection.State != System.Data.ConnectionState.Open)
                throw new Exception("A conexão deve ser aberta antes de alterar um Objeto");
            
            List<T> listaRetorno = new List<T>();

            IDataReader reader = pCommand.ExecuteReader();

            while(reader.Read())
            {
                T novoItem = (T)(typeof(T).Assembly.CreateInstance(typeof(T).ToString()));
                novoItem.PreencheObjeto(reader);
                listaRetorno.Add(novoItem);
            }

            return listaRetorno;
        }

        
    }
}
