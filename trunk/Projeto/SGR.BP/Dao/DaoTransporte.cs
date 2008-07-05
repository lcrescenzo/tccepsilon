using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Objetos;

namespace SGR.BP.Dao
{
    class DaoTransporte : DaoBase, IDao<Transporte>
    {

        #region IDao<Transporte> Members

        public void Incluir(Transporte objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Alterar(Transporte objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Excluir(Transporte objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public System.Data.IDataParameterCollection ParametrosIncluir(Transporte objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public System.Data.IDataParameterCollection ParametrosExcluir(Transporte objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public System.Data.IDataParameterCollection ParametrosAlterar(Transporte objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
