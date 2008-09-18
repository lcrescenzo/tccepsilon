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

                    using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "proc_name", ParametrosIncluir(objeto)))
                    {
                        
                        id = (int)DaoUtil.ExecuteQuery(comm, DaoUtil.ETipoExecucao.Incluir); 
                            
                        DaoTransporte dao = new DaoTransporte();
                        foreach (Transporte transporte in objeto.Transportes)
                        {
                            dao.Incluir(transporte, connection);
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

        public void Alterar(Movimentacao objeto)
        {
            DaoUtil.Execute("proc_name", ParametrosAlterar(objeto), DaoUtil.ETipoExecucao.Alterar);
        }

        public void Excluir(Movimentacao objeto)
        {
            DaoUtil.Execute("proc_name", ParametrosExcluir(objeto), DaoUtil.ETipoExecucao.Excluir);
        }

        public List<IDataParameter> ParametrosIncluir(Movimentacao objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosExcluir(Movimentacao objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosAlterar(Movimentacao objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IDataReader Carregar(int pId, Movimentacao objeto)
        {
            return DaoUtil.Carregar("proc_name", pId, "parameternameid", objeto);
        }

        public void CarregarTransportes(Movimentacao objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }


    }
}
