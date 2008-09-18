using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Objeto;
using SGR.BP.Bases;
using System.Data;
using SGR.BP.Util;

namespace SGR.BP.Dao
{
    public class DaoHistorico : IDao<Historico>
    {
        #region Incluir
        public int Incluir(Historico objeto)
        {
            List<IDataParameter> returnParam = DaoUtil.Execute("proc_name", ParametrosIncluir(objeto), DaoUtil.ETipoExecucao.Incluir);
            return (int)returnParam[0].Value;
        }
        #endregion

        #region Alterar
        public void Alterar(Historico objeto)
        {
            DaoUtil.Execute("proc_name", ParametrosAlterar(objeto), DaoUtil.ETipoExecucao.Excluir);
        }
        #endregion

        #region Excluir
        public void Excluir(Historico objeto)
        {
            DaoUtil.Execute("proc_name", ParametrosExcluir(objeto), DaoUtil.ETipoExecucao.Excluir);
        }
        #endregion

        #region Carregar
        public IDataReader Carregar(int pId, Historico objeto)
        {
            return DaoUtil.Carregar("proc_name", pId, "parameternameid", objeto);
        }
        #endregion

        #region Parametros
        public List<IDataParameter> ParametrosIncluir(Historico objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.DateTime, objeto.Data));
            parameters.Add(Util.DaoUtil.DataBase.NewOutputParameter("parameter_name", DbType.Int32, objeto.IdMantido));
            parameters.Add(Util.DaoUtil.DataBase.NewOutputParameter("parameter_name", DbType.String, objeto.Login.Usuario));

            return parameters;
        }

        public List<IDataParameter> ParametrosExcluir(Historico objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.Int32, objeto.ID));
            return parameters;
        }

        public List<IDataParameter> ParametrosAlterar(Historico objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.Int32, objeto.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.String, objeto.Login.Usuario));
            return parameters;
        }

        public List<IDataParameter> ParametrosCarregar(int pId)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.Int32, pId));
            return parameters;
        }

        #endregion

    }
}
