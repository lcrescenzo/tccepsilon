using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Objeto;
using System.Data;
using SGR.BP.Util;

namespace SGR.BP.Dao
{
    class DaoMovimentacao : IDao<Movimentacao>
    {
        public static Movimentacao Carregar(CADRI cadri, Residuo residuo)
        {
            IDbConnection connection = DaoUtil.DataBase.GetConnectionObject();

            List<IDataParameter> listParams = ParametrosCarregar(cadri, residuo);
            try
            {
                connection.Open();
                using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_Movimentacao_s", listParams))
                {
                    List<Movimentacao> movimentacao = new List<Movimentacao>();
                    movimentacao = DaoUtil.ListaBase<Movimentacao>(comm);
                    if (movimentacao.Count > 0)
                        return movimentacao[0];
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

        public void Carregar(int pId, Movimentacao objeto)
        {
            DaoUtil.Carregar("sp_MovimentacaoById_s", pId, "p_idMovimentacao", objeto);
        }

       


        public List<Transporte> CarregarUltimosTransportes(Movimentacao objeto, int quantidade)
        {
            IDbConnection connection = DaoUtil.DataBase.GetConnectionObject();

            List<IDataParameter> listParams = ParametrosCarregarUltimosTransportes(objeto, quantidade);
            try
            {
                connection.Open();
                using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_UltimosTransportes_s", listParams))
                {
                    return DaoUtil.ListaBase<Transporte>(comm);
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

        private List<IDataParameter> ParametrosCarregarUltimosTransportes(Movimentacao objeto, int quantidade)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idMovimentacao", DbType.Int32, objeto.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_Ultimos", DbType.Int32, quantidade));
            return parameters;
        }

        public int Incluir(Movimentacao objeto)
        {
            int id = 0;
            using (IDbConnection connection = DaoUtil.DataBase.GetConnectionObject())
            {
                IDbTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_Movimentacao_i", ParametrosIncluir(objeto)))
                    {
                        
                        id = (int)DaoUtil.ExecuteQuery(comm, DaoUtil.ETipoExecucao.Incluir); 
                            
                        
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

        public void Alterar(Movimentacao objeto)
        {
            
        }

        public void Excluir(Movimentacao objeto)
        {
            using (IDbConnection connection = DaoUtil.DataBase.GetConnectionObject())
            {
                IDbTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_Movimentacao_d", ParametrosExcluir(objeto)))
                    {
                        DaoTransporte dao = new DaoTransporte();
                        foreach (Transporte transporte in objeto.Transportes)
                        {
                            dao.Excluir(transporte, connection);
                        }

                        DaoUtil.ExecuteQuery(comm, DaoUtil.ETipoExecucao.Incluir);
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

        public List<IDataParameter> ParametrosIncluir(Movimentacao objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idResiduo", DbType.Int32, objeto.Residuo.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idCadri", DbType.Int32, objeto.CADRI.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idUsuario", DbType.Int32, objeto.Login.ID));
            return parameters;
        }

        public List<IDataParameter> ParametrosExcluir(Movimentacao objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idMovimentacao", DbType.Int32, objeto.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idUsuario", DbType.Int32, objeto.Login.ID));
            return parameters;
        }

        public List<IDataParameter> ParametrosAlterar(Movimentacao objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private static List<IDataParameter> ParametrosCarregar(CADRI cadri, Residuo residuo)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idMovimentacao", DbType.Int32, null));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idCadri", DbType.Int32, cadri.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idResiduo", DbType.Int32, residuo.ID));
            return parameters;
        }
                
        public List<Transporte> CarregarTransportes(Movimentacao movimentacao)
        {
            return DaoTransporte.Carregar(movimentacao);
        }
    }
}
