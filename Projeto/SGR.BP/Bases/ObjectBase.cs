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
        
        public abstract void Inserir();
        public abstract void Alterar();
        public abstract void Excluir();
        internal abstract void PreencheObjeto(IDataReader reader);
        
        internal EStateObject Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        

    }


    
    
}
