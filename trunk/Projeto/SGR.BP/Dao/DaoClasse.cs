using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Objeto;
using SGR.BP.Bases;
using System.Data;

namespace SGR.BP.Dao
{
    internal class DaoClasse : IDao<Classe>
    {
        #region IDao<Classe> Members

        public void Incluir(Classe objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Alterar(Classe objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Excluir(Classe objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Carregar(int pId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosIncluir(Classe objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosExcluir(Classe objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosAlterar(Classe objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
