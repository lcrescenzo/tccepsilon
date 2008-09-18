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
        private bool _carregarTotal = true;

        public abstract void Inserir();
        public abstract void Alterar();
        public abstract void Excluir();
        
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
        
        internal bool CarregarTotal
        {
            get
            {
                return _carregarTotal;
            }
            set
            {
                _carregarTotal = value;
            }
        }


        internal object _dao;

        internal EStateObject Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

    }
}
