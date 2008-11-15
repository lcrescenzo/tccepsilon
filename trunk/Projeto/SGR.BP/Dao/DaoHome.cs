using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Objeto.Home.Entidade;
using SGR.BP.Util;
using System.Data;

namespace SGR.BP.Dao
{
    public class DaoHome
    {

        public static List<ResiduoGrafico> ResiduosGrafico(int meses, int quantidadeResiduos)
        {
            IDbConnection connection = DaoUtil.DataBase.GetConnectionObject();

            List<IDataParameter> listParams = ParametrosResiduosGrafico(meses, quantidadeResiduos);
            try
            {
                connection.Open();
                using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_ResiduoPercentual_s", listParams))
                {
                    return DaoUtil.ListaBase<ResiduoGrafico>(comm);
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

        public static List<MovimentacaoCritica> MovimentacoesCriticas(double percentualCritico)
        {
            IDbConnection connection = DaoUtil.DataBase.GetConnectionObject();

            List<IDataParameter> listParams = ParametrosMovimentacoesCriticas(percentualCritico);
            try
            {
                connection.Open();
                using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_MovimentacaoRiscoQuantidade_s", listParams))
                {
                    return DaoUtil.ListaBase<MovimentacaoCritica>(comm);
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

        public static List<CADRICritico> ListaCADRICriticos(int dias)
        {
            IDbConnection connection = DaoUtil.DataBase.GetConnectionObject();

            List<IDataParameter> listParams = ParametrosCriticosValidos(dias);
            try
            {
                connection.Open();
                using (IDbCommand comm = DaoUtil.DataBase.GetCommandProcObject(connection, "sp_CadriRiscoValidade_s", listParams))
                {
                    return DaoUtil.ListaBase<CADRICritico>(comm);
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


        private static List<IDataParameter> ParametrosResiduosGrafico(int meses, int quantidadeResiduos)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_qtdMeses", DbType.Int32, meses));
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_qtdResiduos", DbType.Int32, quantidadeResiduos));
            return parameters;
        }

        private static List<IDataParameter> ParametrosMovimentacoesCriticas(double percentualCritico)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_percentualCritico", DbType.Double, percentualCritico));
            return parameters;
        }

        private static List<IDataParameter> ParametrosCriticosValidos(int dias)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(Util.DaoUtil.DataBase.NewParameter("p_dias", DbType.Int32, dias));
            return parameters;
        }
    }
}
