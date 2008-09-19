using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;

namespace SGR.BP.Objeto
{
    public partial class Usuario : ObjectBase
    {

        #region Data

        internal override void PreencheObjeto(System.Data.IDataReader reader)
        {
            
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

        #endregion

    }
}