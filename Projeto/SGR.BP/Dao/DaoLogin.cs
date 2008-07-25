using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Objeto;
using SGR.BP.Bases;
using System.Data;

namespace SGR.BP.Dao
{
    class DaoLogin : IDao<Login>
    {
        #region IDao<Login> Members

        public void Incluir(Login objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Alterar(Login objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Excluir(Login objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Carregar(int pId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosIncluir(Login objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosExcluir(Login objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosAlterar(Login objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
