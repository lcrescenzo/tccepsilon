using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Dao;

namespace SGR.BP.Objeto
{
    public partial class Login
    {
        #region Contrutores
        public Login()
        { 
        }

        public Login(int id)
        {
            Dao.Carregar(id, this);
        }

        public Login(int id, bool carregarTotal)
        {
            this.ID = id;
            this.CarregarTotal = carregarTotal;
            if(carregarTotal)
                Dao.Carregar(id, this);
        }

        public Login(string login, string senha)
        {
            this.Usuario = login;
            this.Senha = senha;
            Dao.Autenticar(login, senha, this);
        }

        #endregion

        #region Atributos
        private string _usuario;
        private string _senha;
        #endregion

        #region Propriedades
        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        public string Senha
        {
            get { return _senha; }
            set { _senha = value; }
        }

        #endregion

        #region Data
       
        private DaoLogin Dao
        {
            get
            {
                if (_dao == null)
                    _dao = new DaoLogin();

                return (DaoLogin)_dao;
            }
        }
        #endregion
    }
}
