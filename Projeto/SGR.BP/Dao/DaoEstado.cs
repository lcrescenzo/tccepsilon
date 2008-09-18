using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Objeto;
using SGR.BP.Bases;
using System.Data;
using SGR.BP.Util;

namespace SGR.BP.Dao
{
    internal class DaoEstado : IDao<Estado>
    {

        public int Incluir(Estado objeto)
        {
            List<IDataParameter> returnParam = DaoUtil.Execute("proc_name", ParametrosIncluir(objeto), DaoUtil.ETipoExecucao.Incluir);
            return (int)returnParam[0].Value;
        }

        public void Alterar(Estado objeto)
        {
            DaoUtil.Execute("proc_name", ParametrosAlterar(objeto), DaoUtil.ETipoExecucao.Alterar);
        }

        public void Excluir(Estado objeto)
        {
            DaoUtil.Execute("proc_name", ParametrosExcluir(objeto), DaoUtil.ETipoExecucao.Excluir);
        }

        public IDataReader Carregar(int pId, Estado objeto)
        {
            return DaoUtil.Carregar("proc_name", pId, "parameternameid", objeto);
        }

        public List<IDataParameter> ParametrosIncluir(Estado objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosExcluir(Estado objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosAlterar(Estado objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }


    }
}
