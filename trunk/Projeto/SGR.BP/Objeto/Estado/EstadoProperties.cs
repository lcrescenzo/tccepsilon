using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Dao;

namespace SGR.BP.Objeto
{
    public partial class Estado
    {
        #region Construtores
        public Estado()
        {
        }

        public Estado(int id)
        {
            this.ID = id;
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
        private DaoEstado Dao
        {
            get
            {
                if (_dao == null)
                    _dao = (IDao<ObjectBase>)(new DaoEstado());

                return (DaoEstado)_dao;
            }
        }
        #endregion
    }
}
