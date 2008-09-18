using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Dao;
using System.Data;

namespace SGR.BP.Objeto
{
    public partial class TipoResiduo
    {

        #region Contrutores
        public TipoResiduo()
        {

        }

        public TipoResiduo(int id)
        {
            this.ID = id;
            Dao.Carregar(id, this);
        }

        public TipoResiduo(int id, bool carregarTotal)
        {
            CarregarTotal = carregarTotal;
            this.ID = id;
            if(CarregarTotal)
                Dao.Carregar(id, this);
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
        
        DaoTipoResiduo Dao
        {
            get
            {
                if (_dao == null)
                    _dao = new DaoTipoResiduo();

                return (DaoTipoResiduo)_dao;
            }

        }
        #endregion
    }
}
