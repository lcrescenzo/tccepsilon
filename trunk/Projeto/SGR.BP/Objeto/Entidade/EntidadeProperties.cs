using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Dao;

namespace SGR.BP.Objeto
{
    public partial class Entidade
    {
        #region Construtores
        public Entidade()
        {
        }

        public Entidade(int id)
        {

        }
        #endregion

        #region Atributes
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

        DaoEntidade Dao
        {
            get
            {
                if (_dao == null)
                    _dao = new DaoEntidade();

                return (DaoEntidade)_dao;
            }
        }
        #endregion
    }
}
