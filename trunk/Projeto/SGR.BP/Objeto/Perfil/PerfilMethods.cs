using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Objeto.Filtro;
using SGR.BP.Dao;

namespace SGR.BP.Objeto
{
    public partial class Perfil : ObjectBase
    {
        #region Lista
        public static List<Perfil> Lista(FiltroPerfil filtroPerfil)
        {
            return DaoPerfil.Lista(filtroPerfil);
        }

        public List<Recurso> RecursoPorPerfil(int idRecursoPai)
        {
            return Dao.CarregarMenu(this, idRecursoPai);
        }
        #endregion
        
        #region Data
        internal override void PreencheObjeto(System.Data.IDataReader reader)
        {
            this.ID = (int)reader["idPerfil"];
            this.Nome = reader["descricao"].ToString();
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
