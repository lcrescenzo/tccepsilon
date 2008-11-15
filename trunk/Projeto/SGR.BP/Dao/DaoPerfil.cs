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
    internal class DaoPerfil : IDao<Perfil>
    {
        public int Incluir(Perfil objeto)
        {
            int id = 0;
            using (IDbConnection connection = DaoUtil.DataBase.GetConnectionObject())
            {
                IDbTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_Perfil_i", ParametrosIncluir(objeto)))
                    {
                        // Inclui um novo Perfil
                        id = (int)DaoUtil.ExecuteQuery(comm, DaoUtil.ETipoExecucao.Incluir);

                        // Inclui a relação entre Perfil X Recurso
                        foreach (Recurso recurso in objeto.Recursos)
                        {
                            IncluirRecurso(recurso, id, connection);
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
            return id;
        }

        private void IncluirRecurso(Recurso recurso, int idPerfil, IDbConnection connection)
        {
            using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_RecursoPerfil_i", ParametrosRecurso(recurso.ID, idPerfil)))
            {
                comm.ExecuteNonQuery();
            }
        }

        public void Alterar(Perfil objeto)
        {
            using (IDbConnection connection = DaoUtil.DataBase.GetConnectionObject())
            {
                IDbTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    //Exclui a relação de Perfil X Recurso
                    ExcluirTodosRecursos(objeto, connection);

                    using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_Perfil_u", ParametrosAlterar(objeto)))
                    {
                        DaoUtil.ExecuteQuery(comm, DaoUtil.ETipoExecucao.Alterar); //Atualiza o Perfil

                        //Inclui a relação entre Perfil X Recurso
                        foreach (Recurso recurso in objeto.Recursos)
                        {
                            IncluirRecurso(recurso, objeto.ID, connection);
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

            DaoUtil.Execute("sp_Perfil_u", ParametrosAlterar(objeto), DaoUtil.ETipoExecucao.Alterar);
        }

        public void Excluir(Perfil objeto)
        {
            using (IDbConnection connection = DaoUtil.DataBase.GetConnectionObject())
            {
                IDbTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    
                    // Exclui Recursos
                    ExcluirTodosRecursos(objeto, connection);

                    using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_Perfil_d", ParametrosExcluir(objeto)))
                    {
                        DaoUtil.ExecuteQuery(comm, DaoUtil.ETipoExecucao.Excluir); // Exclui Perfil
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
        }

        private void ExcluirTodosRecursos(Perfil perfil, IDbConnection connection)
        {
            using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_RecursoPerfilTodos_d", ParametrosExcluirTodosRecursos(perfil)))
            {
                comm.ExecuteNonQuery();
            }
        }

        private List<IDataParameter> ParametrosExcluirTodosRecursos(Perfil perfil)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idPerfil", DbType.Int32, perfil.ID));
            return parameters;
        }

        public void Carregar(int pId, Perfil objeto)
        {
            DaoUtil.Carregar("sp_PerfilById_s", pId, "p_idPerfil", objeto);
        }

        internal List<Recurso> CarregarMenu(Perfil perfil, int? idRecursoPai)
        {
            using (IDbConnection connection = DaoUtil.DataBase.GetConnectionObject())
            {
                try
                {
                    connection.Open();
                    using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_RecursoByPerfilRecursoPai_s", ParametrosCarregarMenu(perfil, idRecursoPai)))
                    {
                        return DaoUtil.ListaBase<Recurso>(comm);
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
        }

        internal List<Recurso> Recursos(Perfil perfil)
        {
            using (IDbConnection connection = DaoUtil.DataBase.GetConnectionObject())
            {
                try
                {
                    connection.Open();
                    using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_RecursoByPerfil_s", ParametrosRecursos(perfil)))
                    {
                        return DaoUtil.ListaBase<Recurso>(comm);
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
        }

        private List<IDataParameter> ParametrosRecursos(Perfil perfil)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idPerfil", DbType.Int32, perfil.ID));
            return parameters;
        }

        internal static List<Perfil> Lista(FiltroPerfil filtroPerfil)
        {
            IDbConnection connection = DaoUtil.DataBase.GetConnectionObject();

            List<IDataParameter> listParams = ParametrosLista(filtroPerfil);
            try
            {
                connection.Open();
                using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_Perfil_s", listParams))
                {
                    return DaoUtil.ListaBase<Perfil>(comm);
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

        private List<IDataParameter> ParametrosCarregarMenu(Perfil perfil, int? idRecursoPai)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idPerfil", DbType.Int32, perfil.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idRecursoPai", DbType.Int32, idRecursoPai));
            return parameters;
        }

        public List<IDataParameter> ParametrosIncluir(Perfil objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_descricao", DbType.String, objeto.Nome));
            return parameters;
        }

        public List<IDataParameter> ParametrosExcluir(Perfil objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idPerfil", DbType.Int32, objeto.ID));
            return parameters;
        }

        public List<IDataParameter> ParametrosAlterar(Perfil objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idPerfil", DbType.Int32, objeto.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_descricao", DbType.String, objeto.Nome));
            return parameters;
        }

        private static List<IDataParameter> ParametrosLista(FiltroPerfil filtroPerfil)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_descricao", DbType.String, filtroPerfil.Nome));
            return parameters;
        }

        private List<IDataParameter> ParametrosRecurso(int idRecurso, int idPerfil)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idPerfil", DbType.Int32, idPerfil));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idRecurso", DbType.Int32, idRecurso));
            return parameters;
        }
    }
}
