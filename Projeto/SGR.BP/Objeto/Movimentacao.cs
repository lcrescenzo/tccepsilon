using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;

namespace SGR.BP.Objetos
{
    public class Movimentacao : ObjectBase
    {
        #region Data
        private static List<Transporte> _transportes = null;
        #endregion

        #region Propriedades
        public List<Transporte> Transportes
        {
            get
            {
                return _transportes;   
            }
        }
        #endregion

        #region Data
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
        #endregion
    }
}
