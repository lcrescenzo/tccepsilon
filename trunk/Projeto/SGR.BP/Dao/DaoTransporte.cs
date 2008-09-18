using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Objeto;
using System.Data;
using SGR.BP.Util;

namespace SGR.BP.Dao
{
    internal class DaoTransporte : IDao<Transporte>, IListDao<Transporte>
    {

        public int Incluir(Transporte objeto)
        {
            List<IDataParameter> returnParam = DaoUtil.Execute("proc_name", ParametrosIncluir(objeto), DaoUtil.ETipoExecucao.Incluir);
            return (int)returnParam[0].Value;
        }

        public void Incluir(Transporte objeto, IDbConnection pConnection)
        {
            DaoUtil.ExecuteQuery(DaoUtil.DataBase.GetCommandProcObject(pConnection, "proc_name", ParametrosIncluir(objeto)), DaoUtil.ETipoExecucao.Incluir);
        }

        public void Alterar(Transporte objeto)
        {
            DaoUtil.Execute("proc_name", ParametrosAlterar(objeto), DaoUtil.ETipoExecucao.Alterar);
        }

        public void Alterar(Transporte objeto, IDbConnection pConnection)
        {
            DaoUtil.ExecuteQuery(DaoUtil.DataBase.GetCommandProcObject(pConnection, "proc_name", ParametrosAlterar(objeto)), DaoUtil.ETipoExecucao.Alterar);
        }

        public void Excluir(Transporte objeto)
        {
            DaoUtil.Execute("proc_name", ParametrosExcluir(objeto), DaoUtil.ETipoExecucao.Excluir);
        }

        public void Excluir(Transporte objeto, IDbConnection pConnection)
        {
            DaoUtil.ExecuteQuery(DaoUtil.DataBase.GetCommandProcObject(pConnection, "proc_name", ParametrosExcluir(objeto)), DaoUtil.ETipoExecucao.Excluir);
        }


        public IDataReader Carregar(int pId, Transporte objeto)
        {
            return DaoUtil.Carregar("proc_name", pId, "parameternameid", objeto);
        }

        public IDataReader Carregar(DateTime data)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosIncluir(Transporte objeto)
        {
            return null;
        }

        public List<IDataParameter> ParametrosExcluir(Transporte objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosAlterar(Transporte objeto)
        {
            
            throw new Exception("The method or operation is not implemented.");
        }

     


    }
}
