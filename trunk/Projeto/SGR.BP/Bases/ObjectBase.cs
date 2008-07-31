using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SGR.BP.Util;

namespace SGR.BP.Bases
{
    public abstract class ObjectBase
    {
        private EStateObject _estado;
        private int _id;

        public virtual void Inserir()
        {
            _dao.Incluir(this);
        }
        public virtual void Alterar()
        {
            _dao.Alterar(this);
        }
        public virtual void Excluir()
        {
            _dao.Excluir(this);
        }

        internal abstract void PreencheObjeto(IDataReader reader);

        public int ID
        {
            get
            {
                return _id;
            }
            internal set
            {
                _id = value;
            }
        }

        internal IDao<ObjectBase> _dao;

        internal EStateObject Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

    }
}
