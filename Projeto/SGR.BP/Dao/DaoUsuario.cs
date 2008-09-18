using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Objeto;
using SGR.BP.Bases;
using System.Data;
using SGR.BP.Util;

namespace SGR.BP.Dao
{
    internal class DaoUsuario : IDao<Usuario>
    {
        public int Incluir(Usuario objeto)
        {
            List<IDataParameter> returnParam = DaoUtil.Execute("proc_name", ParametrosIncluir(objeto), DaoUtil.ETipoExecucao.Incluir);
            return (int)returnParam[0].Value;
        }

        public void Alterar(Usuario objeto)
        {
            DaoUtil.Execute("proc_name", ParametrosAlterar(objeto), DaoUtil.ETipoExecucao.Alterar);
        }

        public void Excluir(Usuario objeto)
        {
            DaoUtil.Execute("proc_name", ParametrosExcluir(objeto), DaoUtil.ETipoExecucao.Excluir);
        }

        public IDataReader Carregar(int pId, Usuario objeto)
        {
            return DaoUtil.Carregar("proc_name", pId, "parameternameid", objeto);
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
    }
}
