using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Objeto;
using SGR.BP.Bases;
using System.Data;

namespace SGR.BP.Dao
{
    internal class DaoGrupoResiduo : IDao<GrupoResiduo>
    {
        #region IDao<GrupoResiduo> Members

        public void Incluir(GrupoResiduo objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Alterar(GrupoResiduo objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Excluir(GrupoResiduo objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Carregar(int pId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosIncluir(GrupoResiduo objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosExcluir(GrupoResiduo objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosAlterar(GrupoResiduo objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
