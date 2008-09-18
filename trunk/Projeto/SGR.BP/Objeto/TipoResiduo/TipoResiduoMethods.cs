using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Util;
using SGR.BP.Dao;
using SGR.BP.Objeto.Filtro;

namespace SGR.BP.Objeto
{
    public partial class TipoResiduo : ObjectBase
    {
        #region Lista
        public static List<TipoResiduo> Lista(FiltroTipoResiduo filtroTipoResiduo)
        {
            return DaoTipoResiduo.Lista(filtroTipoResiduo);
        }
        #endregion

        #region Data
        internal override void PreencheObjeto(System.Data.IDataReader reader)
        {
            this.ID = (int)reader["idTipoResiduo"];
            this.Descricao = reader["descricao"].ToString();
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
