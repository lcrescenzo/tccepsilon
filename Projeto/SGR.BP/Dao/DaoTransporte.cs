using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Objetos;
using System.Data;
using SGR.BP.Util;

namespace SGR.BP.Dao
{
    class DaoTransporte : IDao<Transporte>, IListDao<Transporte>
    {

        public void Incluir(Transporte objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Incluir(Transporte objeto, IDbConnection pConnection)
        {
            DaoUtil.IncluirBase(DaoUtil.DataBase.GetCommandProcObject(pConnection, "proc_name", ParametrosIncluir(objeto)));
        }
      
        public void Alterar(Transporte objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Alterar(Transporte objeto, IDbConnection pConnection)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Excluir(Transporte objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Excluir(Transporte objeto, IDbConnection pConnection)
        {
            throw new Exception("The method or operation is not implemented.");
        }


        public IDataReader Carregar(int pId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IDataReader Carregar(DateTime data)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<IDataParameter> ParametrosIncluir(Transporte objeto)
        {
            throw new Exception("The method or operation is not implemented.");
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
