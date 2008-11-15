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
    internal class DaoGrupoResiduo : IDao<GrupoResiduo>
    {

        public static List<GrupoResiduo> Lista(FiltroGrupoResiduo filtroGrpoResiduo)
        {
            IDbConnection connection = DaoUtil.DataBase.GetConnectionObject();

            List<IDataParameter> listParams = ParametrosLista(filtroGrpoResiduo);
            try
            {
                connection.Open();
                using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_GrupoResiduo_s", listParams))
                {
                    return DaoUtil.ListaBase<GrupoResiduo>(comm);
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

        public int Incluir(GrupoResiduo objeto)
        {
            List<IDataParameter> returnParam = DaoUtil.Execute("sp_GrupoResiduo_i", ParametrosIncluir(objeto), DaoUtil.ETipoExecucao.Incluir);
            return (int)returnParam[0].Value;
        }

        public void Alterar(GrupoResiduo objeto)
        {
            DaoUtil.Execute("sp_GrupoResiduo_u", ParametrosAlterar(objeto), DaoUtil.ETipoExecucao.Alterar);
        }

        public void Excluir(GrupoResiduo objeto)
        {
            DaoUtil.Execute("sp_GrupoResiduo_d", ParametrosExcluir(objeto), DaoUtil.ETipoExecucao.Excluir);
        }

        public void Carregar(int pId, GrupoResiduo objeto)
        {
            DaoUtil.Carregar("sp_GrupoResiduoById_s", pId, "p_idGrupoResiduo", objeto);
        }

        private static List<IDataParameter> ParametrosLista(FiltroGrupoResiduo filtroGrpoResiduo)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_nome", DbType.String, filtroGrpoResiduo.Nome)); 
            return parameters;
        }

        public List<IDataParameter> ParametrosIncluir(GrupoResiduo objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_nome", DbType.String, objeto.Nome));
            return parameters;
        }

        public List<IDataParameter> ParametrosExcluir(GrupoResiduo objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idGrupoResiduo", DbType.Int32, objeto.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_nome", DbType.String, objeto.Nome));
            return parameters;
        }

        public List<IDataParameter> ParametrosAlterar(GrupoResiduo objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idGrupoResiduo", DbType.Int32, objeto.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_nome", DbType.String, objeto.Nome));
            return parameters;        
        }
    }
}
