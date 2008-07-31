using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Objeto;
using SGR.BP.Bases;
using System.Data;

namespace SGR.BP.Dao
{
    internal class DaoTipoResiduo : IDao<TipoResiduo>
    {
        #region IDao<TipoResiduo> Members

        public void Incluir(TipoResiduo objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Alterar(TipoResiduo objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Excluir(TipoResiduo objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IDataReader Carregar(int pId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosIncluir(TipoResiduo objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosExcluir(TipoResiduo objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosAlterar(TipoResiduo objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
