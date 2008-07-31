using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Dao;

namespace SGR.BP.Objeto
{
    public class Usuario : ObjectBase
    {
        #region Contrutores
        public Usuario()
        { 
        }

        public Usuario(int id)
        {
            this.ID = id;
            this.PreencheObjeto(Dao.Carregar(id));
        }
        #endregion

        #region Atributos
        private Perfil _perfil;
        private string _nome;
        private string _cpf;
        private string _email;
        private string _telefone;
        private string _endereco;

        #region OnDemand
        private int _idPerfil;
        #endregion
        #endregion

        #region Propriedades

        //HACK: Avaliar se o perfil pode ser multiplo
        public Perfil Perfil
        {
            get 
            {
                if (Util.General.IsNullOrDisposed(_perfil))
                    _perfil = new Perfil(_idPerfil);

                return _perfil; 
            }
            set 
            { 
                _perfil = value; 
            }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string CPF
        {
            get { return _cpf; }
            set { _cpf = value; }
        }

        public string EMail
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }

        public string Endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
        }

        #endregion

        #region Data

        internal override void PreencheObjeto(System.Data.IDataReader reader)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        DaoUsuario Dao
        {
            get
            {
                if (_dao == null)
                    _dao = (IDao<ObjectBase>)(new DaoUsuario());

                return (DaoUsuario)_dao;
            }

        }
        #endregion
    }
}
