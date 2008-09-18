using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Objeto;
using SGR.Data.Interfaces;
using System.Data;
using SGR.BP.Util;
using SGR.BP.Objeto.Filtro;


namespace SGR.BP.Dao
{
    internal class DaoResiduo : IDao<Residuo>
    {
        public static List<Residuo> Lista(FiltroResiduo filtroResiduo)
        {
            IDbConnection connection = DaoUtil.DataBase.GetConnectionObject();

            List<IDataParameter> listParams = ParametrosLista(filtroResiduo);
            try
            {
                connection.Open();
                using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_Residuo_s", listParams))
                {
                    return DaoUtil.ListaBase<Residuo>(comm);
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
        
        public int Incluir(Residuo objeto)
        {
            List<IDataParameter> returnParam = DaoUtil.Execute("sp_Residuo_i", ParametrosIncluir(objeto), DaoUtil.ETipoExecucao.Incluir);
            return (int)returnParam[0].Value;
        }

        public void Alterar(Residuo objeto)
        {
            DaoUtil.Execute("sp_Residuo_u", ParametrosAlterar(objeto), DaoUtil.ETipoExecucao.Alterar);
        }

        public void Excluir(Residuo objeto)
        {
            DaoUtil.Execute("sp_Residuo_d", ParametrosExcluir(objeto), DaoUtil.ETipoExecucao.Excluir);
        }

        public List<IDataParameter> ParametrosIncluir(Residuo objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idTipoResiduo", DbType.Int32, objeto.TipoResiduo.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idClasse", DbType.Int32, objeto.Classe.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idGrupoResiduo", DbType.Int32, objeto.Grupo.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_nome", DbType.String, objeto.Nome));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_estFisico", DbType.String, objeto.EstadoFisico)); 
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_auditoria", DbType.Boolean, objeto.Auditoria));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_unidadeMedida", DbType.String, objeto.UnidadeMedida));
            return parameters;
        }

        public List<IDataParameter> ParametrosExcluir(Residuo objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idResiduo", DbType.Int32, objeto.ID));
            return parameters;
        }

        public List<IDataParameter> ParametrosAlterar(Residuo objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idResiduo", DbType.Int32, objeto.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idTipoResiduo", DbType.Int32, objeto.TipoResiduo.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idClasse", DbType.Int32, objeto.Classe.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idGrupoResiduo", DbType.Int32, objeto.Grupo.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_nome", DbType.String, objeto.Nome));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_estFisico", DbType.String, objeto.EstadoFisico)); 
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_auditoria", DbType.Boolean, objeto.Auditoria));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_unidadeMedida", DbType.String, objeto.UnidadeMedida));
            return parameters;
        }

        public static List<IDataParameter> ParametrosLista(FiltroResiduo filtroResiduo)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idTipoResiduo", DbType.Int32, filtroResiduo.TipoResiduo));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idClasse", DbType.Int32, null));//TODO: Carregar este filtro futuramente
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idGrupoResiduo", DbType.Int32, null));//TODO: Carregar este filtro futuramente
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_nome", DbType.String, filtroResiduo.Nome));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_estFisico", DbType.String, null));//TODO: Carregar este filtro futuramente
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_auditoria", DbType.Boolean, null));//TODO: Carregar este filtro futuramente
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_unidadeMedida", DbType.String, null));//TODO: Carregar este filtro futuramente
            return parameters;
        }

        public IDataReader Carregar(int pId, Residuo objeto)
        {
            return DaoUtil.Carregar("p_ResiduoById_s", pId, "p_idResiduo", objeto);   
        }

    }
}
