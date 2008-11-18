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
    public class DaoHistorico : IDao<Historico>
    {
        public static List<Historico> Lista(FiltroHistorico filtro)
        {
            IDbConnection connection = DaoUtil.DataBase.GetConnectionObject();

            List<IDataParameter> listParams = ParametrosLista(filtro);
            try
            {
                connection.Open();
                using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_Historico_s", listParams))
                {
                    return DaoUtil.ListaBase<Historico>(comm);
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

        private static List<IDataParameter> ParametrosLista(FiltroHistorico filtro)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idUsuario", DbType.Int32, filtro.Usuario));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idEntidade", DbType.Int32, filtro.Entidade));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idManutencao", DbType.Int32, filtro.Manutencao));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_periodoInicio", DbType.DateTime, filtro.DataInicio));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_periodoFim", DbType.DateTime, filtro.DataFim));
            return parameters;
        }

        #region Incluir
        public int Incluir(Historico objeto)
        {
            //List<IDataParameter> returnParam = DaoUtil.Execute("proc_name", ParametrosIncluir(objeto), DaoUtil.ETipoExecucao.Incluir);
            //return (int)returnParam[0].Value;
            return int.MinValue;
        }
        #endregion

        #region Alterar
        public void Alterar(Historico objeto)
        {
            //DaoUtil.Execute("proc_name", ParametrosAlterar(objeto), DaoUtil.ETipoExecucao.Excluir);
        }
        #endregion

        #region Excluir
        public void Excluir(Historico objeto)
        {
            //DaoUtil.Execute("proc_name", ParametrosExcluir(objeto), DaoUtil.ETipoExecucao.Excluir);
        }
        #endregion

        #region Carregar
        public void Carregar(int pId, Historico objeto)
        {
            DaoUtil.Carregar("proc_name", pId, "parameternameid", objeto);
        }
        #endregion

        #region Parametros
        public List<IDataParameter> ParametrosIncluir(Historico objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            //parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.DateTime, objeto.Data));
            //parameters.Add(Util.DaoUtil.DataBase.NewOutputParameter("parameter_name", DbType.Int32, objeto.IdMantido));
            //parameters.Add(Util.DaoUtil.DataBase.NewOutputParameter("parameter_name", DbType.String, objeto.Login.Usuario));

            return parameters;
        }

        public List<IDataParameter> ParametrosExcluir(Historico objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            //parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.Int32, objeto.ID));
            return parameters;
        }

        public List<IDataParameter> ParametrosAlterar(Historico objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            //parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.Int32, objeto.ID));
            //parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.String, objeto.Login.Usuario));
            return parameters;
        }

        public List<IDataParameter> ParametrosCarregar(int pId)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            //parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.Int32, pId));
            return parameters;
        }

        #endregion

    }
}
