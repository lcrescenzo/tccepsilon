using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Objeto;
using SGR.BP.Bases;
using System.Data;

namespace SGR.BP.Dao
{
    internal class DaoRecurso : IDao<Recurso>
    {
        #region IDao<Recurso> Members

        public void Incluir(Recurso objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Alterar(Recurso objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Excluir(Recurso objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IDataReader Carregar(int pId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosIncluir(Recurso objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosExcluir(Recurso objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosAlterar(Recurso objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
