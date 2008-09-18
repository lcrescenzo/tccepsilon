using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Objeto.Filtro;
using SGR.BP.Dao;

namespace SGR.BP.Objeto
{
    public partial class Classe : ObjectBase
    {
        #region Lista
        public static List<Classe> Lista(FiltroClasse filtroClasse)
        {
            return DaoClasse.Lista(filtroClasse);
        }
        #endregion

        #region Data
        internal override void PreencheObjeto(System.Data.IDataReader reader)
        {
            this.ID = (int)reader["idClasse"];
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
