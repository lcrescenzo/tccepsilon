using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Objeto;
using SGR.BP.Bases;
using System.Data;

namespace SGR.BP.Dao
{
    internal class DaoPerfil : IDao<Perfil>
    {
        #region IDao<Perfil> Members

        public void Incluir(Perfil objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Alterar(Perfil objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Excluir(Perfil objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IDataReader Carregar(int pId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosIncluir(Perfil objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosExcluir(Perfil objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosAlterar(Perfil objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
