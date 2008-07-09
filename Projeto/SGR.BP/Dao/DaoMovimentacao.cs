using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Objetos;

namespace SGR.BP.Dao
{
    class DaoMovimentacao : DaoBase, IDao<Movimentacao>
    {
        #region IDao<Movimentacao> Members

        public void Incluir(Movimentacao objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Alterar(Movimentacao objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Excluir(Movimentacao objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public System.Data.IDataParameterCollection ParametrosIncluir(Movimentacao objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public System.Data.IDataParameterCollection ParametrosExcluir(Movimentacao objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public System.Data.IDataParameterCollection ParametrosAlterar(Movimentacao objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
