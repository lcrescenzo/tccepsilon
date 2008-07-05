using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;

namespace SGR.BP.Objetos
{
    class Transporte : ObjectBase
    {
        private int _quantidade;

        public int Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
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
            throw new Exception("The method or operation is not implemented.");
        }

       
    }
}
