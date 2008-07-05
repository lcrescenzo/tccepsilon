using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Dao;
using SGR.BP.Bases;

namespace SGR.BP.Objetos
{
    class Residuo : SGR.BP.Bases.ObjectBase, IDataObject<DaoResiduo>
    {
        #region Propriedades
        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        #endregion

        #region Netodos de Dados
        /// <summary>
        /// Faz a inclusão do Resíduo no Banco de Dados.
        /// </summary>
        public override void Inserir()
        {
            DaoResiduo dao = new DaoResiduo();
            dao.Incluir(this);
            
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// Faz alteração do Resíduo na Base de Dados.
        /// </summary>
        public override void Alterar()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// Exclui o Resíduo do banco de Dados
        /// </summary>
        public override void Excluir()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// Carrega as propriedades do objeto.
        /// </summary>
        /// <param name="reader">DataReader carregado</param>
        internal override void PreencheObjeto(System.Data.IDataReader reader)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion



        #region IDataObject<DaoResiduo> Members

        public DaoResiduo Dao
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion
    }
}
