using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;

namespace SGR.BP.Objeto
{
    public partial class Transporte : ObjectBase
    {
        internal override void PreencheObjeto(System.Data.IDataReader reader)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void Inserir()
        {
            Dao.Incluir(this);
        }

        public override void Alterar()
        {
            Dao.Alterar(this);
        }

        public override void Excluir()
        {
            Dao.Excluir(this);
        }

    }
}
