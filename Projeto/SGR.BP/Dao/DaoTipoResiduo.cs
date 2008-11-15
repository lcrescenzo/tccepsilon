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
    internal class DaoTipoResiduo : IDao<TipoResiduo>
    {

        public static List<TipoResiduo> Lista(FiltroTipoResiduo filtroTipoResiduo)
        {
            IDbConnection connection = DaoUtil.DataBase.GetConnectionObject();

            List<IDataParameter> listParams = ParametrosLista(filtroTipoResiduo);
            try
            {
                connection.Open();
                using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_TipoResiduo_s", listParams))
                {
                    return DaoUtil.ListaBase<TipoResiduo>(comm);
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

       

        public int Incluir(TipoResiduo objeto)
        {
            List<IDataParameter> returnParam = DaoUtil.Execute("sp_TipoResiduo_i", ParametrosIncluir(objeto), DaoUtil.ETipoExecucao.Incluir);
            return (int)returnParam[0].Value;
        }

        public void Alterar(TipoResiduo objeto)
        {
            DaoUtil.Execute("sp_TipoResiduo_u", ParametrosAlterar(objeto), DaoUtil.ETipoExecucao.Alterar);
        }

        public void Excluir(TipoResiduo objeto)
        {
            DaoUtil.Execute("sp_TipoResiduo_d", ParametrosExcluir(objeto), DaoUtil.ETipoExecucao.Excluir);
        }

        public void Carregar(int pId, TipoResiduo objeto)
        {
            DaoUtil.Carregar("sp_TipoResiduoById_s", pId, "p_idTipoResiduo", objeto);
        }

        private static List<IDataParameter> ParametrosLista(FiltroTipoResiduo filtroTipoResiduo)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idTipoResiduo", DbType.Int32, filtroTipoResiduo.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_descricao", DbType.String, filtroTipoResiduo.Descricao));
            return parameters;
        }

        public List<IDataParameter> ParametrosIncluir(TipoResiduo objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_descricao", objeto.Descricao));
            return parameters;
        }

        public List<IDataParameter> ParametrosExcluir(TipoResiduo objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idTipoResiduo", DbType.Int32, objeto.ID));
            return parameters;
        }

        public List<IDataParameter> ParametrosAlterar(TipoResiduo objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idTipoResiduo", DbType.Int32, objeto.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_descricao", DbType.String, objeto.Descricao));
            return parameters;
        }
    }
}
