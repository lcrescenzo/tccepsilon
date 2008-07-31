using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Objeto;
using SGR.BP.Bases;
using System.Data;
using SGR.BP.Util;
using SGR.BP.Objetos;

namespace SGR.BP.Dao
{
    internal class DaoCADRI : IDao<CADRI>
    {
        #region Incluir
        public void Incluir(CADRI objeto)
        {
            using (IDbConnection connection = DaoUtil.DataBase.GetConnectionObject())
            {
                IDbTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();//Abre uma transação

                    using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "proc_name", ParametrosIncluir(objeto)))//
                    {

                        if (DaoUtil.IncluirBase(comm) > 0)
                        {
                            foreach (Residuo residuo in objeto.Residuos)
                            {
                                IncluirResiduos(objeto, residuo,  connection);
                            }
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

        public void IncluirResiduos(CADRI objetoCADRI, Residuo objetoResiduo, IDbConnection connection)
        {
            using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "proc_name", ParametrosIncluirResiduos(objetoCADRI, objetoResiduo)))//
            {
                DaoUtil.IncluirBase(comm);
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
                    connection.Open();
                    transaction = connection.BeginTransaction();//Abre uma transação

                    using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "proc_name", ParametrosAlterar(objeto)))
                    {

                        if (DaoUtil.AlterarBase(comm))
                        {
                            foreach (Residuo residuo in objeto.Residuos)
                            {
                                AlterarResiduos(objeto, residuo, connection);
                            }
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
            ExcluirResíduos(objetoCADRI, objetoResiduo, connection);

            IncluirResiduos(objetoCADRI, objetoResiduo, connection);
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
                    connection.Open();
                    transaction = connection.BeginTransaction();//Abre uma transação

                    foreach (Residuo residuo in objeto.Residuos)
                    {
                        ExcluirResíduos(objeto, residuo, connection);
                    }

                    IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "proc_name", ParametrosIncluir(objeto));
                    DaoUtil.ExcluirBase(comm);
                    
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

        public void ExcluirResíduos(CADRI objetoCADRI, Residuo objetoResiduo, IDbConnection connection)
        {
            using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "proc_name", ParametrosIncluirResiduos(objetoCADRI, objetoResiduo)))
            {
                DaoUtil.ExcluirBase(comm);
            }
        }
        #endregion

        #region Carregar
        public IDataReader Carregar(int pId)
        {
            return DaoUtil.Carregar("proc_name", pId, "parameter_name");
        }

        public void CarregarResiduos(CADRI objeto)
        {
            using (IDbConnection connection = DaoUtil.DataBase.GetConnectionObject())
            {
                try
                {
                    connection.Open();

                    IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "proc_name", ParametrosCarregarResiduos(objeto));
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
        

        private List<IDataParameter> ParametrosCarregarResiduos(CADRI objetoCADRI)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.Int32, objetoCADRI.ID));
            return parameters;
        }

        private List<IDataParameter> ParametrosIncluirResiduos(CADRI objetoCADRI, Residuo objetoResiduo)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.Int32, objetoCADRI.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.Int32, objetoResiduo.ID));
            return parameters;
        }

        public List<IDataParameter> ParametrosIncluir(CADRI objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.Int32, objeto.Numero));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.String, objeto.Destino));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.Int32, objeto.OI));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.Double, objeto.Quantidade));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.DateTime, objeto.Validade));
            parameters.Add(Util.DaoUtil.DataBase.NewOutputParameter("parameter_name", DbType.Int32, objeto.ID));
            return parameters;
        }

        private List<IDataParameter> ParametrosExcluirResiduos(CADRI objetoCADRI, Residuo objetoResiduo)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.Int32, objetoCADRI.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.Int32, objetoResiduo.ID));
            return parameters;
        }

        public List<IDataParameter> ParametrosExcluir(CADRI objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.Int32, objeto.ID));
            return parameters;
        }

        public List<IDataParameter> ParametrosAlterar(CADRI objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.Int32, objeto.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.Int32, objeto.Numero));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.String, objeto.Destino));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.Int32, objeto.OI));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.Double, objeto.Quantidade));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.DateTime, objeto.Validade));
            return parameters;
        }
        #endregion

    }
}
