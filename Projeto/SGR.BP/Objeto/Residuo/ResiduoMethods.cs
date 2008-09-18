using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Dao;
using SGR.BP.Objeto.Filtro;

namespace SGR.BP.Objeto
{
    public partial class Residuo : ObjectBase
    {

        public static List<Residuo> Lista(FiltroResiduo filtroResiduo)
        {
            return DaoResiduo.Lista(filtroResiduo);
        }


        #region Data

        internal override void PreencheObjeto(System.Data.IDataReader reader)
        {
            this.Auditoria = (bool)reader["auditoria"];
            this._idClasse = (int)reader["idClasse"];
            this.EstadoFisico = ((EEstadoFisico)((int)reader["estFisico"]));
            this._idGrupoResiduo = (int)reader["idGrupoResíduo"];
            this.Nome = (string)reader["nome"];
            this._idTipoResiduo = (int)reader["idTipoResiduo"];
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
            Dao.Excluir(this);
        }

        public Residuo Novo()
        {
            return new Residuo();
        }
        #endregion

        
    }
}
