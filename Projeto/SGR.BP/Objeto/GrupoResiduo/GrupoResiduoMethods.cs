using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Objeto.Filtro;
using SGR.BP.Dao;

namespace SGR.BP.Objeto
{
    public partial class GrupoResiduo : ObjectBase
    {
        #region Lista
        public static List<GrupoResiduo> Lista(FiltroGrupoResiduo filtroGrupoResiduo)
        {
            return DaoGrupoResiduo.Lista(filtroGrupoResiduo);
        }
        #endregion

        #region Data
        internal override void PreencheObjeto(System.Data.IDataReader reader)
        {
            this.ID = (int)reader["idGrupoResiduo"];
            this.Nome = reader["nome"].ToString();
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

        #endregion
    }
}
