using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Dao;

namespace SGR.BP.Objeto
{
    public partial class Perfil 
    {
        #region Contrutores
        public Perfil()
        {

        }

        public Perfil(int id)
        {
            this.ID = id;
            Dao.Carregar(id, this);
        }

        public Perfil(int id, bool carregarTotal)
        {
            this.ID = id;
            this.CarregarTotal = carregarTotal;
            if(CarregarTotal)
                Dao.Carregar(id, this);
        }
        #endregion

        #region Atributos

        private string _nome;
        private Login _loginUltimaAlteracao;
        private List<Recurso> _menu;
        #endregion

        #region Propriedades

        
        public Login LoginUltimaAlteracao
        {
            get
            {
                return _loginUltimaAlteracao;
            }
            set
            {
                _loginUltimaAlteracao = value;
            }
        }

        public string Nome
        {
            get 
            { 
                return _nome; 
            }
            set 
            { 
                _nome = value; 
            }
        }

        public List<Recurso> Menu
        {
            get
            {
                if (Util.General.IsNullOrDisposed(_menu))
                    _menu = Dao.CarregarMenu(this, null);

                return _menu;
            }

        }

        private List<Recurso> _recursos = null;

        public List<Recurso> Recursos
        {
            get 
            {
                if(Util.General.IsNullOrDisposed(_recursos))
                    _recursos = Dao.Recursos(this);

                return _recursos; 
            }
            set 
            { 
                _recursos = value; 
            }
        }

        #endregion

        #region Data

        DaoPerfil Dao
        {
            get
            {
                if (_dao == null)
                    _dao = new DaoPerfil();

                return (DaoPerfil)_dao;
            }

        }

        #endregion
    }
}
