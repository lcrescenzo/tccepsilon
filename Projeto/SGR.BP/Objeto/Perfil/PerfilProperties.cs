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
        #endregion

        #region Atributos

        private string _nome;

        #endregion

        #region Propriedades
       
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
