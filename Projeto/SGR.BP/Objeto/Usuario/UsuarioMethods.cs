using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Objeto.Filtro;
using SGR.BP.Dao;

namespace SGR.BP.Objeto
{
    public partial class Usuario : ObjectBase
    {

       
        #region Data
        public static List<Usuario> Lista(FiltroUsuario filtroUsuario)
        {
            return DaoUsuario.Lista(filtroUsuario);
        }

        internal override void PreencheObjeto(System.Data.IDataReader reader)
        {
            this.ID = (int)reader["idUsuario"];
            this.Nome = reader["nome"].ToString();

            if (reader["idPerfil"] != DBNull.Value)
                this.Perfil = new Perfil((int)reader["idPerfil"], false);
		    
            this.EMail = reader["email"] .ToString();
		    this.Telefone = reader["telefone"].ToString(); 
		    this.Endereco = reader["endereco"].ToString();
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
