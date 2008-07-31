using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Objeto;
using SGR.BP.Bases;
using System.Data;

namespace SGR.BP.Dao
{
    internal class DaoEstado : IDao<Estado>
    {
        #region IDao<Estado> Members

        public void Incluir(Estado objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Alterar(Estado objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Excluir(Estado objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IDataReader Carregar(int pId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosIncluir(Estado objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosExcluir(Estado objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosAlterar(Estado objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
