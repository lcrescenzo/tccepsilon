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
    internal class DaoCADRI : IDao<CADRI>
    {
        #region Lista
        public static List<CADRI> Lista(FiltroCADRI filtroCADRI)
        {
            IDbConnection connection = DaoUtil.DataBase.GetConnectionObject();

            List<IDataParameter> listParams = ParametrosLista(filtroCADRI);
            try
            {
                connection.Open();
                using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_Cadri_s", listParams))
                {
                    return DaoUtil.ListaBase<CADRI>(comm);
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

        public static List<CADRI> Lista(Residuo residuo)
        {
            IDbConnection connection = DaoUtil.DataBase.GetConnectionObject();

            List<IDataParameter> listParams = ParametrosListaPorResiduo(residuo);
            try
            {
                connection.Open();
                using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_CadriPorResiduo_s", listParams))
                {
                    return DaoUtil.ListaBase<CADRI>(comm);
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

        #region Incluir
        public int Incluir(CADRI objeto)
        {
            int id = 0;
            using (IDbConnection connection = DaoUtil.DataBase.GetConnectionObject())
            {
                IDbTransaction transaction = null;
                try
                {
                    transaction = DaoUtil.OpenConnection(connection);// Seta transa�ao
                    
                    using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_Cadri_i", ParametrosIncluir(objeto)))// Inclus�o do CADRI
                    {

                        objeto.ID = (int)DaoUtil.ExecuteQuery(comm, DaoUtil.ETipoExecucao.Incluir);
                        foreach (Residuo residuo in objeto.Residuos)
                        {
                            IncluirResiduos(objeto, residuo,  connection);// Inclus�o de Residuos para o CADRI
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

                return id;
            }
        }

        public void IncluirResiduos(CADRI objetoCADRI, Residuo objetoResiduo, IDbConnection connection)
        {
            using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_ResiduoCadri_i", ParametrosIncluirResiduos(objetoCADRI, objetoResiduo)))// Inclus�o de residuos no cadri
            {
                DaoUtil.ExecuteQuery(comm, DaoUtil.ETipoExecucao.Incluir);
            }
        }
        #endregion

        #region Alterar
        public void Alterar(CADRI objeto)
        {
            
            using (IDbConnection connection = DaoUtil.DataBase.GetConnectionObject())
            {
                IDbTransaction transaction = null;
                try
                {
                    
                    transaction = DaoUtil.OpenConnection(connection);// Seta transa��o

                    using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_Cadri_u", ParametrosAlterar(objeto)))
                    {

                        DaoUtil.ExecuteQuery(comm, DaoUtil.ETipoExecucao.Alterar);

                        ExcluirResiduosPeloCadri(objeto, connection);

                        foreach (Residuo residuo in objeto.Residuos)
                        {
                            AlterarResiduos(objeto, residuo, connection);
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
        }

        public void AlterarResiduos(CADRI objetoCADRI, Residuo objetoResiduo, IDbConnection connection)
        {
            Movimentacao movimentacao = Movimentacao.Carregar(objetoCADRI, objetoResiduo);
            if (movimentacao == null)
            {
                IncluirResiduos(objetoCADRI, objetoResiduo, connection);
            }
        }
        #endregion

        #region Excluir
        public void Excluir(CADRI objeto)
        {
            using (IDbConnection connection = DaoUtil.DataBase.GetConnectionObject())
            {
                IDbTransaction transaction = null;
                try
                {
                    transaction = DaoUtil.OpenConnection(connection);//Seta transa��o

                    foreach (Residuo residuo in objeto.Residuos)
                    {
                        ExcluirResiduos(objeto, residuo, connection);
                    }

                    IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_Cadri_d", ParametrosExcluir(objeto));
                    DaoUtil.ExecuteQuery(comm, DaoUtil.ETipoExecucao.Excluir);
                    
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

        public void ExcluirResiduos(CADRI objetoCADRI, Residuo objetoResiduo, IDbConnection connection)
        {
            using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_ResiduoCadri_d", ParametrosExcluirResiduos(objetoCADRI, objetoResiduo))) // Exclui Residuos do Cadri
            {
                DaoUtil.ExecuteQuery(comm, DaoUtil.ETipoExecucao.Excluir);
            }
        }

        public void ExcluirResiduosPeloCadri(CADRI objetoCADRI, IDbConnection connection)
        {
            using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_RemoveResiduosCadri_d", ParametrosExcluirResiduosPeloCadri(objetoCADRI))) // Exclui Residuos do Cadri
            {
                DaoUtil.ExecuteQuery(comm, DaoUtil.ETipoExecucao.Excluir);
            }
        }
        #endregion

        #region Carregar
        public void Carregar(int pId, CADRI objeto)
        {
            DaoUtil.Carregar("sp_CadriById_s", pId, "p_idCadri", objeto);
        }

        public void CarregarResiduos(CADRI objeto)
        {
            using (IDbConnection connection = DaoUtil.DataBase.GetConnectionObject())
            {
                try
                {
                    connection.Open();

                    IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_ResiduoCadri_s", ParametrosCarregarResiduos(objeto));
                    objeto.Residuos = DaoUtil.ListaBase<Residuo>(comm);
                }
                finally
                {
                    connection.Close();
                }
             }
         }
        #endregion

        #region Parametros
        private static List<IDataParameter> ParametrosLista(FiltroCADRI filtroCADRI)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_numero", DbType.String, filtroCADRI.Numero));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_destino", DbType.String, filtroCADRI.Destino));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_validade", DbType.DateTime, filtroCADRI.Validade));
            return parameters;
        }

        private static List<IDataParameter> ParametrosListaPorResiduo(Residuo residuo)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idResiduo", DbType.Int32, residuo.ID));
            return parameters;
        }

        private List<IDataParameter> ParametrosCarregarResiduos(CADRI objetoCADRI)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idCadri", DbType.Int32, objetoCADRI.ID));
            return parameters;
        }

        private List<IDataParameter> ParametrosIncluirResiduos(CADRI objetoCADRI, Residuo objetoResiduo)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idCadri", DbType.Int32, objetoCADRI.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idResiduo", DbType.Int32, objetoResiduo.ID));
            return parameters;
        }

        public List<IDataParameter> ParametrosIncluir(CADRI objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_numero", DbType.String, objeto.Numero));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_destino", DbType.String, objeto.Destino));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_OI", DbType.Int32, objeto.OI));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_quantidade", DbType.Double, objeto.Quantidade));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_validade", DbType.DateTime, objeto.Validade));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idUsuario", DbType.Int32, objeto.LoginUltimaAlteracao.ID));
            return parameters;
        }

        private List<IDataParameter> ParametrosExcluirResiduos(CADRI objetoCADRI, Residuo objetoResiduo)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idCadri", DbType.Int32, objetoCADRI.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idResiduo", DbType.Int32, objetoResiduo.ID));
            return parameters;
        }

        public List<IDataParameter> ParametrosExcluir(CADRI objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idCadri", DbType.Int32, objeto.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idUsuario", DbType.Int32, objeto.LoginUltimaAlteracao.ID));
            return parameters;
        }

        public List<IDataParameter> ParametrosAlterar(CADRI objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idCadri", DbType.Int32, objeto.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_numero", DbType.String, objeto.Numero));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_destino", DbType.String, objeto.Destino));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_OI", DbType.Int32, objeto.OI));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_quantidade", DbType.Double, objeto.Quantidade));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_validade", DbType.DateTime, objeto.Validade));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idUsuario", DbType.Int32, objeto.LoginUltimaAlteracao.ID));
            return parameters;
        }

        private List<IDataParameter> ParametrosExcluirResiduosPeloCadri(CADRI objetoCADRI)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idCadri", DbType.Int32, objetoCADRI.ID));
            return parameters;
        }
        #endregion

    }
}
