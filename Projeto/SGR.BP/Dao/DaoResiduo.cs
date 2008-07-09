using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Objetos;
using SGR.Data.Interfaces;
using System.Data;


namespace SGR.BP.Dao
{
    internal class DaoResiduo : DaoBase, IDao<Residuo>
    {

        public static List<Residuo> Lista()
        {
            return new List<Residuo>();
        }
        
        #region IDao<Residuo> Members

        public void Incluir(Residuo objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Alterar(Residuo objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Excluir(Residuo objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IDataParameterCollection ParametrosIncluir(Residuo objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IDataParameterCollection ParametrosExcluir(Residuo objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IDataParameterCollection ParametrosAlterar(Residuo objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
