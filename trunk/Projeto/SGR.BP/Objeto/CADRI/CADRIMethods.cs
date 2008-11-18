using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Dao;
using SGR.BP.Objeto.Filtro;
using SGR.BP.Objeto.Home.Entidade;
using SGR.BP.Util;

namespace SGR.BP.Objeto
{
    public partial class CADRI : ObjectBase
    {
        #region Lista
        public static List<CADRI> Lista(FiltroCADRI filtroCADRI)
        {
            return DaoCADRI.Lista(filtroCADRI);
        }

        public static List<CADRI> Lista(Residuo residuo)
        {
            return DaoCADRI.Lista(residuo);
        }

       
        #endregion

        #region Data
        internal override void PreencheObjeto(System.Data.IDataReader reader)
        {
            base.ID = Convert.ToInt32(reader["idCadri"]);
            this.Destino = reader["destino"].ToString();
            this.Numero = reader["numero"].ToString();
            this.OI = Convert.ToInt32(reader["OI"]);
            this.Quantidade = Convert.ToDouble(reader["quantidade"]);
            this.Validade = Convert.ToDateTime(reader["validade"]);
        }
        
        public override void Inserir()
        {
            Dao.Incluir(this);
        }

        public override void Alterar()
        {
            Dao.Alterar(this);
        }

        public override void Excluir()
        {
            bool possuimovimentacao = false;
            foreach(Residuo residuo in Residuos)
            {
                Movimentacao movimentacao = Movimentacao.Carregar(this, residuo);
                if(movimentacao != null)
                {
                    possuimovimentacao = true;
                    break;
                }
            }
            if (!possuimovimentacao)
                Dao.Excluir(this);
            else
                throw new SGRErroException("Este CADRI Possui uma movimentação, não é permitido excluí-lo");
        }
        #endregion

    }
}
