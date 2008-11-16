using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Objeto;
using System.Data;
using SGR.BP.Util;

namespace SGR.BP.Dao
{
    internal class DaoTransporte : IDao<Transporte>, IListDao<Transporte>
    {

        public int Incluir(Transporte objeto)
        {
            List<IDataParameter> returnParam = DaoUtil.Execute("sp_Transporte_i", ParametrosIncluir(objeto), DaoUtil.ETipoExecucao.Incluir);
            return (int)returnParam[0].Value;
        }

        public void Incluir(Transporte objeto, IDbConnection pConnection)
        {
            DaoUtil.ExecuteQuery(DaoUtil.DataBase.GetCommandProcObject(pConnection, "sp_Transporte_i", ParametrosIncluir(objeto)), DaoUtil.ETipoExecucao.Incluir);
        }

        public void Alterar(Transporte objeto)
        {
            DaoUtil.Execute("sp_Transporte_u", ParametrosAlterar(objeto), DaoUtil.ETipoExecucao.Alterar);
        }

        public void Alterar(Transporte objeto, IDbConnection pConnection)
        {
            DaoUtil.ExecuteQuery(DaoUtil.DataBase.GetCommandProcObject(pConnection, "sp_Transporte_u", ParametrosAlterar(objeto)), DaoUtil.ETipoExecucao.Alterar);
        }

        public void Excluir(Transporte objeto)
        {
            DaoUtil.Execute("sp_Transporte_d", ParametrosExcluir(objeto), DaoUtil.ETipoExecucao.Excluir);
        }

        public void Excluir(Transporte objeto, IDbConnection pConnection)
        {
            DaoUtil.ExecuteQuery(DaoUtil.DataBase.GetCommandProcObject(pConnection, "sp_Transporte_d", ParametrosExcluir(objeto)), DaoUtil.ETipoExecucao.Excluir);
        }

        public void Carregar(int pId, Transporte objeto)
        {
            DaoUtil.Carregar("sp_TransporteById_s", pId, "p_idTransporte", objeto);
        }

        public static List<Transporte> Carregar(Movimentacao movimentacao)
        {
            IDbConnection connection = DaoUtil.DataBase.GetConnectionObject();

            List<IDataParameter> listParams = ParametrosCarregar(movimentacao);
            try
            {
                connection.Open();
                using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_Transporte_s", listParams))
                {
                    return DaoUtil.ListaBase<Transporte>(comm);
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

        private static List<IDataParameter> ParametrosCarregar(Movimentacao movimentacao)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idTransporte", DbType.Int32, null));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_dataSaida", DbType.DateTime, null));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_qtdSaida", DbType.Decimal, null));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_transportadora", DbType.String, null));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idUsuario", DbType.Int32, null));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idMovimentacao", DbType.Int32, movimentacao.ID));
            return parameters;
        }

        public List<IDataParameter> ParametrosIncluir(Transporte objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_dataSaida", DbType.DateTime, objeto.Data));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_qtdSaida", DbType.Decimal, objeto.Quantidade));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_transportadora", DbType.String, objeto.Transportadora));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idUsuario", DbType.Int32, objeto.LoginUltimaAlteracao.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idMovimentacao", DbType.Int32, objeto.Movimentacao.ID));
            return parameters;
 
        }

        public List<IDataParameter> ParametrosExcluir(Transporte objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idTransporte", DbType.Int32, objeto.ID));
            return parameters;
        }

        public List<IDataParameter> ParametrosAlterar(Transporte objeto)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idTransporte", DbType.Int32, objeto.ID));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_qtdSaida", DbType.Decimal, objeto.Quantidade));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_transportadora", DbType.String, objeto.Transportadora));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_idUsuario", DbType.Int32, objeto.LoginUltimaAlteracao.ID));
            return parameters;
        }
    }
}
