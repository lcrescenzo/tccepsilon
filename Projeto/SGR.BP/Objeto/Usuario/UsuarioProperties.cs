using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Dao;

namespace SGR.BP.Objeto
{
    public partial class Usuario
    {
        #region Contrutores
        public Usuario()
        { 
        }

        public Usuario(int id)
        {
            this.ID = id;
            Dao.Carregar(id, this);
        }

        public Usuario(int id, bool carregarTotal)
        {
            this.ID = id;
            this.CarregarTotal = carregarTotal;
            if(this.CarregarTotal)
                Dao.Carregar(id, this);
        }
        #endregion

        #region Atributos
        private Perfil _perfil;
        private string _nome;
        private string _cpf;
        private string _email;
        private string _telefone;
        private string _endereco;
        private Login _login;

        #region OnDemand
        private int _idPerfil = int.MinValue;
        #endregion
        #endregion

        #region Propriedades

        public Perfil Perfil
        {
            get 
            {
                if (Util.General.IsNullOrDisposed(_perfil) && this.ID > 0)
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

        public Login Login
        {
            get 
            {
                if (Util.General.IsNullOrDisposed(_login) && (this.ID > 0))
                    _login = new Login(this.ID);
                    
                return _login; 
            }
            set 
            { 
                _login = value; 
            }
        }

        #endregion

        #region Data

        DaoUsuario Dao
        {
            get
            {
                if (_dao == null)
                    _dao = new DaoUsuario();

                return (DaoUsuario)_dao;
            }

        }
        
        #endregion
    }
}
