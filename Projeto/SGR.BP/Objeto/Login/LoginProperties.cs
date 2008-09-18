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
        public Login(string login, string senha)
        {
            this.PreencheObjeto(Dao.Carregar(login, senha));
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
