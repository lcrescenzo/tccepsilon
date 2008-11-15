using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Objeto;
using SGR.BP.Bases;
using System.Data;
using SGR.BP.Util;

namespace SGR.BP.Dao
{
    internal class DaoRecurso : IDao<Recurso>
    {

        public int Incluir(Recurso objeto)
        {
            List<IDataParameter> returnParam = DaoUtil.Execute("proc_name", ParametrosIncluir(objeto), DaoUtil.ETipoExecucao.Incluir);
            return (int)returnParam[0].Value;
        }

        public void Alterar(Recurso objeto)
        {
            DaoUtil.Execute("proc_name", ParametrosAlterar(objeto), DaoUtil.ETipoExecucao.Alterar);
        }

        public void Excluir(Recurso objeto)
        {
            DaoUtil.Execute("proc_name", ParametrosExcluir(objeto), DaoUtil.ETipoExecucao.Excluir);
        }

        public void Carregar(int pId, Recurso objeto)
        {
            DaoUtil.Carregar("sp_RecursoById_s", pId, "p_idRecurso", objeto);
        }

        public List<Recurso> CarregarFilhos(int pId)
        {
            using(IDbConnection connection = DaoUtil.DataBase.GetConnectionObject())
            {
                try
                {
                    connection.Open();
                    using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_RecursoFilho_s", ParametrosCarregarFilhos(pId)))
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

        public List<Recurso> ListarPrincipaisRecursos()
        {
            using (IDbConnection connection = DaoUtil.DataBase.GetConnectionObject())
            {
                try
                {
                    connection.Open();
                    using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_RecursoPrincipal_s", ParametrosListarPrincipais()))
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

        private List<IDataParameter> ParametrosListarPrincipais()
        {
            return new List<IDataParameter>();
        }

        private List<IDataParameter> ParametrosCarregarFilhos(int pId)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idRecursoPai", DbType.Int32, pId));
            return parameters;
        }

        public List<IDataParameter> ParametrosIncluir(Recurso objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosExcluir(Recurso objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosAlterar(Recurso objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }



    }
}
