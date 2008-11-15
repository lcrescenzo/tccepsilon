using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Objeto;
using SGR.BP.Bases;
using System.Data;
using SGR.BP.Util;
using SGR.BP.Objeto.Filtro;

namespace SGR.BP.Dao
{
    internal class DaoUsuario : IDao<Usuario>
    {
        #region Lista
        public static List<Usuario> Lista(FiltroUsuario filtroUsuario)
        {
            IDbConnection connection = DaoUtil.DataBase.GetConnectionObject();

            List<IDataParameter> listParams = ParametrosLista(filtroUsuario);
            try
            {
                connection.Open();
                using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_Usuario_s", listParams))
                {
                    return DaoUtil.ListaBase<Usuario>(comm);
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

        #endregion

        public int Incluir(Usuario objeto)
        {
            int id = 0;
            using (IDbConnection connection = DaoUtil.DataBase.GetConnectionObject())
            {
                IDbTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_Usuario_i", ParametrosIncluir(objeto)))
                    {
                        // Inclui um novo Perfil
                        id = (int)DaoUtil.ExecuteQuery(comm, DaoUtil.ETipoExecucao.Incluir);

                        DaoLogin daoLogin = new DaoLogin();
                        // Inclui o Login
                        objeto.Login.ID = id;
                        objeto.Login.Senha = "846c81d2255f2922e3c5ad9bbaa70c2a";
                        daoLogin.Incluir(objeto.Login, connection);
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
            return id;
        }

        public void Alterar(Usuario objeto)
        {
            DaoUtil.Execute("sp_Usuario_u", ParametrosAlterar(objeto), DaoUtil.ETipoExecucao.Alterar);
        }

        public void Excluir(Usuario objeto)
        {
            using (IDbConnection connection = DaoUtil.DataBase.GetConnectionObject())
            {
                IDbTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    DaoLogin daoLogin = new DaoLogin();
                    // Exclui o Login
                    daoLogin.Excluir(objeto.Login, connection);

                    using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_Usuario_d", ParametrosExcluir(objeto)))
                    {
                        // Exclui um novo Perfil
                        DaoUtil.ExecuteQuery(comm, DaoUtil.ETipoExecucao.Excluir);
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
            DaoUtil.Execute("sp_Usuario_d", ParametrosExcluir(objeto), DaoUtil.ETipoExecucao.Excluir);
        }

        public void Carregar(int pId, Usuario objeto)
        {
            DaoUtil.Carregar("sp_UsuarioById_s", pId, "p_idUsuario", objeto);
        }

        public List<IDataParameter> ParametrosIncluir(Usuario objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_nome", DbType.String, objeto.Nome));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idPerfil", DbType.Int32, objeto.Perfil.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_email", DbType.String, objeto.EMail));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_telefone", DbType.String, objeto.Telefone));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_endereco", DbType.String, objeto.Endereco));
            return parameters;
        }

        public List<IDataParameter> ParametrosExcluir(Usuario objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idUsuario", DbType.Int32, objeto.ID));
            return parameters;
        }

        public List<IDataParameter> ParametrosAlterar(Usuario objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idUsuario", DbType.Int32, objeto.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_nome", DbType.String, objeto.Nome));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idPerfil", DbType.Int32, objeto.Perfil.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_email", DbType.String, objeto.EMail));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_telefone", DbType.String, objeto.Telefone));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_endereco", DbType.String, objeto.Endereco)); 
            return parameters;
        }


        private static List<IDataParameter> ParametrosLista(FiltroUsuario filtroUsuario)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_nome", DbType.String, filtroUsuario.Nome));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idPerfil", DbType.Int32, filtroUsuario.Perfil));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_email", DbType.String, filtroUsuario.EMail));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_telefone", DbType.String, filtroUsuario.Telefone));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_login", DbType.String, filtroUsuario.Usuario));
            return parameters;
        }
    }
}
