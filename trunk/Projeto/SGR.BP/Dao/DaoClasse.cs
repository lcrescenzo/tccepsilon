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
    internal class DaoClasse : IDao<Classe>
    {
        #region Lista
        public static List<Classe> Lista(FiltroClasse filtroClasse)
        {
            IDbConnection connection = DaoUtil.DataBase.GetConnectionObject();

            List<IDataParameter> listParams = ParametrosLista(filtroClasse);
            try
            {
                connection.Open();
                using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_Classe_s", listParams))
                {
                    return DaoUtil.ListaBase<Classe>(comm);
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
        public int Incluir(Classe objeto)
        {
            List<IDataParameter> returnParam = DaoUtil.Execute("sp_Classe_i", ParametrosIncluir(objeto), DaoUtil.ETipoExecucao.Incluir);
            return (int)returnParam[0].Value;
        }
        #endregion

        #region Alterar
        public void Alterar(Classe objeto)
        {
            DaoUtil.Execute("sp_Classe_u", ParametrosAlterar(objeto), DaoUtil.ETipoExecucao.Excluir);
        }
        #endregion

        #region Excluir
        public void Excluir(Classe objeto)
        {
            DaoUtil.Execute("sp_Classe_d", ParametrosExcluir(objeto), DaoUtil.ETipoExecucao.Excluir);
        }
        #endregion

        #region Carregar
        public IDataReader Carregar(int pId, Classe objeto)
        {
            return DaoUtil.Carregar("sp_ClasseById_s", pId, "p_idClasse", objeto);
        }
        #endregion

        #region Parametros
        private static List<IDataParameter> ParametrosLista(FiltroClasse filtroClasse)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idClasse", DbType.Int32, filtroClasse.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_descricao", DbType.String, filtroClasse.Descricao));
            return parameters;
        }

        public List<IDataParameter> ParametrosIncluir(Classe objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_descricao", DbType.String, objeto.Descricao));
            return parameters;
        }

        public List<IDataParameter> ParametrosExcluir(Classe objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idClasse", DbType.Int32, objeto.ID));
            return parameters;
        }

        public List<IDataParameter> ParametrosAlterar(Classe objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idClasse", DbType.Int32, objeto.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_descricao", DbType.String, objeto.Descricao));
            return parameters;
        }

        public List<IDataParameter> ParametrosCarregar(int pId)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idClasse", DbType.Int32, pId));
            return parameters;
        }

        #endregion
    }
}
