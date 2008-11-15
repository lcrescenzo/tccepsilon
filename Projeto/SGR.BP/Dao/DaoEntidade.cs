using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Objeto;
using SGR.BP.Bases;

namespace SGR.BP.Dao
{
    class DaoEntidade : IDao<Entidade>
    {
        public int Incluir(Entidade objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Alterar(Entidade objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Excluir(Entidade objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Carregar(int pId, Entidade objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<System.Data.IDataParameter> ParametrosIncluir(Entidade objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<System.Data.IDataParameter> ParametrosExcluir(Entidade objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<System.Data.IDataParameter> ParametrosAlterar(Entidade objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
