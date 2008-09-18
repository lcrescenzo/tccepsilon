using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Dao;

namespace SGR.BP.Objeto
{
    public partial class GrupoResiduo
    {
        #region Construtores
        public GrupoResiduo()
        {
        }

        public GrupoResiduo(int id)
        {
            this.ID = id;
            Dao.Carregar(id, this);
        }

        public GrupoResiduo(int id, bool carregarTotal)
        {
            this.ID = id;
            CarregarTotal = carregarTotal;
            if(CarregarTotal)
                Dao.Carregar(id, this);
        }
        #endregion

        #region Atributos
        private string _nome;
        #endregion

        #region Propriedades
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        #endregion

        #region Data
        
        private DaoGrupoResiduo Dao
        {
            get
            {
                if (_dao == null)
                    _dao = new DaoGrupoResiduo();

                return (DaoGrupoResiduo)_dao;
            }
        }
        #endregion
    }
}
