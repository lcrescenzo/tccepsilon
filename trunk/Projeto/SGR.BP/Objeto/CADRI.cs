using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Objetos;

namespace SGR.BP.Objeto
{
    public class CADRI : ObjectBase
    {
        #region Atributos
        private List<Residuo> residuos;
        #endregion

        #region Propriedades
        public List<Residuo> Residuos
        {
            get { return residuos; }
            set { residuos = value; }
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
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion
    }
}
