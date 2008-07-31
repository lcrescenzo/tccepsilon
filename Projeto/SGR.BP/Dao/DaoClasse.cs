using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Objeto;
using SGR.BP.Bases;
using System.Data;

namespace SGR.BP.Dao
{
    internal class DaoClasse : IDao<Classe>
    {
        #region Incluir
        public void Incluir(Classe objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion

        #region Alterar
        public void Alterar(Classe objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion

        #region Excluir
        public void Excluir(Classe objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion

        #region Carregar
        public IDataReader Carregar(int pId)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion

        #region Parametros
        public List<IDataParameter> ParametrosIncluir(Classe objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.String, objeto.Descricao));
            parameters.Add(Util.DaoUtil.DataBase.NewOutputParameter("parameter_name", DbType.Int32, objeto.ID));
            return parameters;
        }

        public List<IDataParameter> ParametrosExcluir(Classe objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.Int32, objeto.ID));
            return parameters;
        }

        public List<IDataParameter> ParametrosAlterar(Classe objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.Int32, objeto.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("parameter_name", DbType.String, objeto.Descricao));
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
