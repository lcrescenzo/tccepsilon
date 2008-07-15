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


        public void Carregar(int pId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IDataParameterCollection ParametrosIncluir(Transporte objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IDataParameterCollection ParametrosExcluir(Transporte objeto)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IDataParameterCollection ParametrosAlterar(Transporte objeto)
        {
            
            throw new Exception("The method or operation is not implemented.");
        }

     


    }
}
