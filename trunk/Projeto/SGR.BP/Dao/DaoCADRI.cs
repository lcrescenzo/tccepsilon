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
        #region IDao<CADRI> Members

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

        private List<IDataParameter> ParametrosIncluirResiduos(CADRI objetoCADRI, Residuo objetoResiduo)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Alterar(CADRI objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Excluir(CADRI objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Carregar(int pId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosIncluir(CADRI objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosExcluir(CADRI objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosAlterar(CADRI objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        
        #endregion
    }
}
