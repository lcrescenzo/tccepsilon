using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using System.Data;
using SGR.Data.Interfaces;
using SGR.DataBaseFactory;
using SGR.DataBaseFactory.Collection;

namespace SGR.BP.Util
{
    internal class DaoUtil
    {
        private static IDataBase _database;
        /// <summary>
        /// Factory para gerar os objetos de relacionados a Base de Dados.
        /// </summary>
        internal static IDataBase DataBase
        {
            get
            {
                if (General.IsNullOrDisposed(_database))
                    _database = GenericDataBase.DataBase["teste1"];

                return _database;
            }
        }

        /// <summary>
        /// Método que realiza a execução de um comando de alteração de um registro. 
        /// </summary>
        /// <param name="pCommand">Comando a ser executado.</param>
        /// <returns>Retorna "true" caso a alteração seja realizada com sucesso.</returns>
        private static bool AlterarBase(System.Data.IDbCommand pCommand)
        {

            if (pCommand.Connection.State != System.Data.ConnectionState.Open)
                throw new Exception("A conexão deve ser aberta antes de alterar um Objeto");

            return (pCommand.ExecuteNonQuery() > 0);
        }

        /// <summary>
        /// Método que realiza a execução de um comando de exclusão de um registro.
        /// </summary>
        /// <param name="pCommand">Comando a ser executado.</param>
        /// <returns>Retorna "true" caso a exclusão seja realizada com sucesso.</returns>
        private static bool ExcluirBase(System.Data.IDbCommand pCommand)
        {
            if (pCommand.Connection.State != System.Data.ConnectionState.Open)
                throw new Exception("A conexão deve ser aberta antes de apagar um Objeto");

            return (pCommand.ExecuteNonQuery() > 0);
        }

        /// <summary>
        /// Método que realiza a execução de um comando de inclusão de um registro.
        /// </summary>
        /// <param name="pCommand">Comando a ser executado.</param>
        /// <returns>Retorna "true" caso a inclusão seja realizada com sucesso.</returns>
        private static int IncluirBase(System.Data.IDbCommand pCommand)
        {
            if (pCommand.Connection.State != System.Data.ConnectionState.Open)
                throw new Exception("A conexão deve ser aberta antes de alterar um Objeto");

            object retorno = pCommand.ExecuteScalar();
            
            if (retorno == null)
                retorno = int.MinValue;
            
            return (int)retorno;
        }

        /// <summary>
        /// Método que carrega os dados de um determinado objeto da base mediante Procedure.
        /// </summary>
        /// <param name="pProcName">Nome da procedure a ser executada.</param>
        /// <param name="pID">Identificador do objeto a ser carregado.</param>
        /// <param name="pParameterNameID">Nome do parametro do identificador na procedure.</param>
        /// <returns>Retorna um DataReader com os dados preenchidos.</returns>
        internal static IDataReader Carregar(string pProcName,int pID, string pParameterNameID, ObjectBase objeto) //where T : ObjectBase
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

                    if (reader.Read())
                    {
                        objeto.PreencheObjeto(reader);
                    }
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

        /// <summary>
        /// Executa um comando para carregar vários objetos do mesmo tipo.
        /// </summary>
        /// <typeparam name="T">Tipo do objeto a ser carregado.</typeparam>
        /// <param name="pCommand">Comando a ser executado.</param>
        /// <returns>Retorna uma lista genérica do tipo informado.</returns>
        internal static List<T> ListaBase<T>(System.Data.IDbCommand pCommand) where T : ObjectBase
        {
            if (pCommand.Connection.State != System.Data.ConnectionState.Open)
                throw new Exception("A conexão deve ser aberta antes de alterar um Objeto");

            List<T> listaRetorno = new List<T>();

            IDataReader reader = pCommand.ExecuteReader();

            while (reader.Read())
            {
                ObjectBase novoItem = ((ObjectBase) (typeof(T)).Assembly.CreateInstance((typeof(T)).ToString()));
                novoItem.PreencheObjeto(reader);
                listaRetorno.Add((T)novoItem);
            }

            return listaRetorno;
        }

        /// <summary>
        /// Abre a conexão com a base de dados e inicia uma transação.
        /// </summary>
        /// <param name="connection">Conexão a ser aberta.</param>
        /// <returns>Retorna a transação da conexão.</returns>
        internal static IDbTransaction OpenConnection(IDbConnection connection)
        {
            connection.Open();
            return connection.BeginTransaction();
        }

        /// <summary>
        /// Executa comando do tipo definido, com tratamento de transação.
        /// </summary>
        /// <param name="pProcName">Nome da procedure a ser executada.</param>
        /// <param name="pParameters">Parametros da procedure.</param>
        /// <param name="tipo">Tipo da execução.</param>
        internal static List<IDataParameter> Execute(string pProcName, List<IDataParameter> pParameters, ETipoExecucao tipo)
        {
            List<IDataParameter> outParametars = new List<IDataParameter>();
            using (IDbConnection connection = DaoUtil.DataBase.GetConnectionObject())
            {
                IDbTransaction transaction = null;
                try
                {
                    transaction = DaoUtil.OpenConnection(connection);//Abre uma transação

                    IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, pProcName, pParameters);


                    if (tipo == ETipoExecucao.Incluir)
                        outParametars.Add(DaoUtil.DataBase.NewOutputParameter("id", DbType.Int32, ExecuteQuery(comm, tipo)));
                    else
                        ExecuteQuery(comm, tipo);

                    foreach (IDataParameter param in comm.Parameters)
                    {
                        if (param.Direction == ParameterDirection.Output)
                        {
                            outParametars.Add(param);
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
                finally
                {
                    connection.Close();
                }

                return outParametars;
            }
        }

        /// <summary>
        /// Executa comando do tipo definido, com tratamento de transação.
        /// </summary>
        /// <param name="pProcName">Nome da procedure a ser executada.</param>
        /// <param name="pParameters">Parametros da procedure.</param>
        /// <param name="tipo">Tipo da execução.</param>
        internal static IDataReader Execute(IDbCommand command)
        {
            return command.ExecuteReader();
        }


        /// <summary>
        /// Executa query definida no command.
        /// </summary>
        /// <param name="command">Command a ser executado.</param>
        /// <param name="tipo">Tipo de execução.</param>
        internal static object ExecuteQuery(IDbCommand command, ETipoExecucao tipo)
        {
            switch (tipo)
	        {
                case ETipoExecucao.Excluir: return ExcluirBase(command); 
                case ETipoExecucao.Incluir: return IncluirBase(command); 
                case ETipoExecucao.Alterar: return AlterarBase(command); 
                default: throw new Exception("Tipo de execução não definido.");
                
	        }
        }
        
        /// <summary>
        /// Tipo de execução dos comandos
        /// </summary>
        internal enum ETipoExecucao
        {
            Excluir,
            Incluir,
            Alterar
        }
    }
}
