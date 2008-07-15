using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Objetos;
using System.Data;
using SGR.BP.Util;

namespace SGR.BP.Dao
{
    class DaoMovimentacao : IDao<Movimentacao>
    {
        

        public void Incluir(Movimentacao objeto)
        {
            using (IDbConnection connection = DaoUtil.DataBase.GetConnectionObject())
            {
                IDbTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "proc_name", ParametrosIncluir(objeto)))
                    {

                        if (DaoUtil.IncluirBase(comm) > 0)
                        {
                            DaoTransporte dao = new DaoTransporte();
                            foreach (Transporte transporte in objeto.Transportes)
                            {
                                dao.Incluir(transporte, connection);
                            }
                        }
                    }

                }
                catch (Exception e)
                {
                    transaction.Rollback();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Alterar(Movimentacao objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Excluir(Movimentacao objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public System.Data.IDataParameterCollection ParametrosIncluir(Movimentacao objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public System.Data.IDataParameterCollection ParametrosExcluir(Movimentacao objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public System.Data.IDataParameterCollection ParametrosAlterar(Movimentacao objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Carregar(int pId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        
    }
}
