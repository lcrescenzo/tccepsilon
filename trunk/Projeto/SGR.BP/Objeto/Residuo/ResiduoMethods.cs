using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Dao;
using SGR.BP.Objeto.Filtro;
using SGR.BP.Util;

namespace SGR.BP.Objeto
{
    public partial class Residuo : ObjectBase
    {

        public static List<Residuo> Lista(FiltroResiduo filtroResiduo)
        {
            return DaoResiduo.Lista(filtroResiduo);
        }

        public static List<Residuo> Lista(CADRI cadri)
        {
            return DaoResiduo.Lista(cadri);
        }

        #region Data

        private EEstadoFisico ConverteEstadoFisico(string estadoFisico)
        {
            EEstadoFisico retornoEstadoFisico = EEstadoFisico.Liquido;
            switch (estadoFisico)
            {
                case "G": retornoEstadoFisico = EEstadoFisico.Gasoso; break;
                case "L": retornoEstadoFisico = EEstadoFisico.Liquido; break;
                case "S": retornoEstadoFisico = EEstadoFisico.Solido; break;

                default:
                    break;
            }
            return retornoEstadoFisico;
        }

        internal override void PreencheObjeto(System.Data.IDataReader reader)
        {
            base.ID = Convert.ToInt32(reader["idResiduo"]);
            this.Auditoria = Convert.ToBoolean(reader["auditoria"]);
            this._idClasse = Convert.ToInt32(reader["idClasse"]);
            this.EstadoFisico = (ConverteEstadoFisico(reader["estFisico"].ToString()));
            this._idGrupoResiduo = Convert.ToInt32(reader["idGrupoResiduo"]);
            this.Nome = (string)reader["nome"];
            this._idTipoResiduo = Convert.ToInt32(reader["idTipoResiduo"]);
            this.UnidadeMedida = (string)reader["unidadeMedida"];
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
            foreach (CADRI cadri in CADRI.Lista(this))
            {
                Movimentacao movimentacao = Movimentacao.Carregar(cadri, this);
                if (movimentacao != null)
                {
                    possuimovimentacao = true;
                    break;
                }
            }
            if (!possuimovimentacao)
                Dao.Excluir(this);
            else
                throw new SGRErroException("Este Resíduo possui uma movimentação, não é permitido excluí-lo");
        }

        public Residuo Novo()
        {
            return new Residuo();
        }
        #endregion

        
    }
}
