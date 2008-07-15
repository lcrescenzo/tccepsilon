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

        internal static T Carregar<T>(string pProcName,int pID, string pParameterNameID) where T : ObjectBase
        {
            IDbCommand comm = DaoUtil.DataBase.GetCommandObject();
            IDbDataParameter parameter = comm.CreateParameter();

            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = pProcName;

            parameter.DbType = DbType.Int32;
            parameter.ParameterName = pParameterNameID;
            parameter.Value = pID;
            
            IDataReader reader = comm.ExecuteReader();
            
            T objeto = (T)(typeof(T).Assembly.CreateInstance(typeof(T).ToString()));
            objeto.PreencheObjeto(reader);

            return objeto;
        }

        internal static List<T> ListaBase<T>(System.Data.IDbCommand pCommand, IDataParameterCollection pParameterColection) where T : ObjectBase
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
