using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Objeto;
using SGR.BP.Bases;
using System.Data;
using SGR.BP.Util;

namespace SGR.BP.Dao
{
    public class DaoConfiguracao
    {

        public static string ValorDe(int? idUsuario, string chave)
        {
            IDbConnection connection = DaoUtil.DataBase.GetConnectionObject();
            try
            {
                connection.Open();
                string valor = null;
                using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_Configuracao_s", ParametrosValorDe(idUsuario, chave)))
                {
                    // Este é um caso que não houve possibilidade de a Classe implementar ObjectBase
                    IDataReader reader = comm.ExecuteReader();
                    if(reader.Read())
                    {
                        valor = reader["valor"].ToString();
                    }
                }
                return valor;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }

        private static List<IDataParameter> ParametrosValorDe(int? idUsuario, string chave)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idUsuario", DbType.Int32, idUsuario));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_chave", DbType.String, chave));
            return parameters; 
        }

        public static Configuracao Carregar(int? idUsuario)
        {
            Configuracao configuracao = new Configuracao();
            IDbConnection connection = DaoUtil.DataBase.GetConnectionObject();

            List<IDataParameter> listParams = ParametrosCarregar(idUsuario);
            try
            {
                connection.Open();
                using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_Configuracao_s", listParams))
                {
                    // Este é um caso que não houve possibilidade de a Classe implementar ObjectBase
                    IDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                            configuracao.Add(reader["chave"].ToString(), reader["valor"].ToString());
                    }
                
                    if (idUsuario.HasValue && configuracao.Keys.Count <= 0)
                        return Carregar(null);
                    else if (configuracao.Keys.Count > 0)
                        return configuracao;
                    else
                        return null;
                }
                
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }

        private static List<IDataParameter> ParametrosCarregar(int? idUsuario)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idUsuario", DbType.Int32, idUsuario));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_chave", DbType.String, null));
            return parameters; 
        }

        public static void Incluir(Configuracao objeto)
        {

            IDbTransaction transaction = null;
            IDbConnection connection = DaoUtil.DataBase.GetConnectionObject();
            try
            {
                transaction = DaoUtil.OpenConnection(connection);

                foreach (string chave in objeto.Keys)
                {
                    using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_Configuracao_i", ParametrosIncluir(chave , objeto)))
                    {
                        comm.ExecuteNonQuery();
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
        }

        private static List<IDataParameter> ParametrosIncluir(string chave, Configuracao objeto)
        {
            
            List<IDataParameter> parameters = new List<IDataParameter>();
            if(objeto.Login != null)
                parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idUsuario", DbType.Int32, objeto.Login.ID));
            else
                parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idUsuario", DbType.Int32, null));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_chave", DbType.String, chave));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_valor", DbType.String, objeto[chave]));
            return parameters; 
        }

        public static void Alterar(Configuracao objeto)
        {
            Excluir(objeto);
            Incluir(objeto);
        }

        private static List<IDataParameter> ParametrosAlterar(int? idUsuario, string chave, string valor)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idUsuario", DbType.Int32, idUsuario));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_chave", DbType.String, chave));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_valor", DbType.String, valor));
            return parameters; 
        }

        public static void Excluir(Configuracao objeto)
        {
            DaoUtil.Execute("sp_Configuracao_d", ParametrosExcluir(objeto), DaoUtil.ETipoExecucao.Excluir);
        }

        public static List<IDataParameter> ParametrosExcluir(Configuracao objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            if (objeto.Login != null)
                parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idUsuario", DbType.Int32, objeto.Login.ID));
            else
                parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idUsuario", DbType.Int32, null));
            
            return parameters; 
        }

    }
}
