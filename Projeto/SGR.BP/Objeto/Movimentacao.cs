using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;

namespace SGR.BP.Objetos
{
    public class Movimentacao : ObjectBase
    {
        
        
        private static List<Transporte> _transportes = null;
        public List<Transporte> Transportes
        {
            get
            {
                return _transportes;   
            }
        }

        public override void Inserir()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void Alterar()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void Excluir()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        internal override void PreencheObjeto(System.Data.IDataReader reader)
        {
            
        }
    }
}
