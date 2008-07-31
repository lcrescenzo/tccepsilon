using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Dao;

namespace SGR.BP.Objeto
{
    public class GrupoResiduo : ObjectBase
    {
        #region Construtores
        public GrupoResiduo()
        {
        }

        public GrupoResiduo(int id)
        {
            this.ID = id;
            this.PreencheObjeto(Dao.Carregar(id));
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
        internal override void PreencheObjeto(System.Data.IDataReader reader)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private DaoGrupoResiduo Dao
        {
            get
            {
                if (_dao == null)
                    _dao = (IDao<ObjectBase>)(new DaoGrupoResiduo());

                return (DaoGrupoResiduo)_dao;
            }
        }
        #endregion
    }
}
