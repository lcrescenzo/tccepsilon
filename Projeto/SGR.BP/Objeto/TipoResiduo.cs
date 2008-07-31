using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Dao;

namespace SGR.BP.Objeto
{
    public class TipoResiduo : ObjectBase
    {

        #region Contrutores
        public TipoResiduo()
        {

        }

        public TipoResiduo(int id)
        {
            this.ID = id;
            this.PreencheObjeto(Dao.Carregar(id));
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
        internal override void PreencheObjeto(System.Data.IDataReader reader)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        DaoTipoResiduo Dao
        {
            get
            {
                if (_dao == null)
                    _dao = (IDao<ObjectBase>)(new DaoTipoResiduo());

                return (DaoTipoResiduo)_dao;
            }

        }
        #endregion
    }
}
