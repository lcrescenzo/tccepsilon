using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Objeto;
using SGR.BP.Bases;
using System.Data;

namespace SGR.BP.Dao
{
    internal class DaoUsuario : IDao<Usuario>
    {
        #region IDao<Usuario> Members

        public void Incluir(Usuario objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Alterar(Usuario objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Excluir(Usuario objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Carregar(int pId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosIncluir(Usuario objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosExcluir(Usuario objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosAlterar(Usuario objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
