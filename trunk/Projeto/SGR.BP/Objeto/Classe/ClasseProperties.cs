using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Dao;

namespace SGR.BP.Objeto
{
    public partial class Classe 
    {
        #region Construtor
        public Classe()
        { 
        }

        public Classe(int id)
        {
            this.ID = id;
            Dao.Carregar(id, this);
        }

        public Classe(int id, bool carregarTotal)
        {
            CarregarTotal = carregarTotal;
            this.ID = id;
        }
        #endregion

        #region Atributos
        private string _descricao;
        #endregion

        #region Propriedades
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
        #endregion

        #region Data

        private DaoClasse Dao
        {
            get
            {
                if (_dao == null)
                    _dao = new DaoClasse();

                return (DaoClasse)_dao;
            }
        }
        #endregion
    }
}
