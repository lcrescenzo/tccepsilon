using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Objeto.Home.Entidade;
using SGR.BP.Dao;

namespace SGR.BP.Objeto.Home
{
    public class Home
    {
        public static List<CADRICritico> ListaCriticosValidos(int dias)
        {
            return DaoHome.ListaCADRICriticos(dias);
        }

        /// <summary>
        /// Movimentações Criticas com com transportes realizados com quase o total
        /// do que é permitido pelo cadri
        /// </summary>
        /// <param name="percentualCritico"></param>
        /// <returns></returns>
        public static List<MovimentacaoCritica> MovimentacoesCriticas(double percentualCritico)
        {
            return DaoHome.MovimentacoesCriticas(percentualCritico);
        }

        public static List<ResiduoGrafico> Residuos(int meses, int quantidadeResiduos)
        {
            return DaoHome.ResiduosGrafico(meses, quantidadeResiduos);
        }
    }
}
