using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Dao;

namespace SGR.BP.Objeto
{
    public partial class Recurso : ObjectBase
    {
        public static List<Recurso> ListaPrincipaisRecursos()
        {
            DaoRecurso dao = new DaoRecurso();
            return dao.ListarPrincipaisRecursos();
        }

        #region Data
        internal override void PreencheObjeto(System.Data.IDataReader reader)
        {
            this.ID = (int)reader["idRecurso"];
		    this._idPai = (reader["idRecursoPai"] != DBNull.Value) ? (int)reader["idRecursoPai"] : int.MinValue;
		    this.TipoRecurso = ConverteTipoRecurso(reader["idTipoRecurso"].ToString());
	 	    this.IdComponente = reader["componente"].ToString();
            this.Nome = reader["nome"].ToString();
        }

        private ETipoRecurso ConverteTipoRecurso(string idTipoRecurso)
        {
            switch (idTipoRecurso)
            {
                case "": return ETipoRecurso.None;
                case "P" : return ETipoRecurso.Pagina;
                case "M" : return ETipoRecurso.ItemMenu;
                case "B" : return ETipoRecurso.Botao;
                case "A" : return ETipoRecurso.Acao;
                default: break;
            }

            return ETipoRecurso.Outros;
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
