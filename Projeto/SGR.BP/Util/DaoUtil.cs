using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using System.Data;
using SGR.Data.Interfaces;
using SGR.DataBaseFactory;

namespace SGR.BP.Util
{
    internal class DaoUtil
    {
        private static IDataBase _database;
        internal static IDataBase DataBase
        {
            get
            {
                if (General.IsNullOrDisposed(_database))
                    _database = GenericDataBase.DataBase;

                return _database;
            }
        }

        internal static bool AlterarBase(System.Data.IDbCommand pCommand)
        {

            if (pCommand.Connection.State != System.Data.ConnectionState.Open)
                throw new Exception("A conexão deve ser aberta antes de alterar um Objeto");

            return (pCommand.ExecuteNonQuery() > 0);
        }

        internal static bool ExcluirBase(System.Data.IDbCommand pCommand)
        {
            if (pCommand.Connection.State != System.Data.ConnectionState.Open)
                throw new Exception("A conexão deve ser aberta antes de apagar um Objeto");

            return (pCommand.ExecuteNonQuery() > 0);
        }

        internal static int IncluirBase(System.Data.IDbCommand pCommand)
        {
            if (pCommand.Connection.State != System.Data.ConnectionState.Open)
                throw new Exception("A conexão deve ser aberta antes de alterar um Objeto");

            return (int)pCommand.ExecuteScalar();
        }

        internal static IDataReader Carregar(string pProcName,int pID, string pParameterNameID) //where T : ObjectBase
        {
            using(IDbConnection connection = DataBase.GetConnectionObject())
            {
                IDataReader reader = null;
                try
                {
                    connection.Open();
                    
                    List<IDataParameter> parameter = new List<IDataParameter>();
                    parameter.Add(DataBase.NewParameter(pParameterNameID, DbType.Int32, pID));

                    IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, pProcName, parameter);
                    
                    reader = comm.ExecuteReader();
                }
                catch(Exception e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }

                return reader;
            }
        }

        internal static List<T> ListaBase<T>(System.Data.IDbCommand pCommand) where T : ObjectBase
        {
            if (pCommand.Connection.State != System.Data.ConnectionState.Open)
                throw new Exception("A conexão deve ser aberta antes de alterar um Objeto");

            List<T> listaRetorno = new List<T>();

            IDataReader reader = pCommand.ExecuteReader();

            while (reader.Read())
            {
                T novoItem = (T)(typeof(T).Assembly.CreateInstance(typeof(T).ToString()));
                novoItem.PreencheObjeto(reader);
                listaRetorno.Add(novoItem);
            }

            return listaRetorno;
        }

        internal static void PrepareCommand(IDbCommand pCommand, string pProcName, IDataParameterCollection pParameterColection)
        {
            
        }
    }
}
