using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Objetos;
using SGR.Data.Interfaces;
using System.Data;
using SGR.BP.Util;


namespace SGR.BP.Dao
{
    internal class DaoResiduo : IDao<Residuo>
    {

        public static List<Residuo> Lista()
        {
            return new List<Residuo>();
        }
        
        #region IDao<Residuo> Members

        public void Incluir(Residuo objeto)
        {
            IDbCommand comm = DaoUtil.DataBase.GetCommandObject();
            //DaoUtil.IncluirBase(comm, this.ParametrosIncluir(objeto));

        }

        public void Alterar(Residuo objeto)
        {
            IDbCommand comm = DaoUtil.DataBase.GetCommandObject();
            //DaoUtil.AlterarBase(comm, this.ParametrosAlterar(objeto));
        }

        public void Excluir(Residuo objeto)
        {
            IDbCommand comm = DaoUtil.DataBase.GetCommandObject();
            //DaoUtil.ExcluirBase(comm, this.ParametrosExcluir(objeto));
        }

        public List<IDataParameter> ParametrosIncluir(Residuo objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosExcluir(Residuo objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosAlterar(Residuo objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Carregar(int pId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
