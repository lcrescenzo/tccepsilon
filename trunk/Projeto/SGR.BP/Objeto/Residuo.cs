using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Dao;
using SGR.BP.Bases;

namespace SGR.BP.Objetos
{
    public class Residuo : SGR.BP.Bases.ObjectBase
    {
        #region Construtores
        public Residuo()
        { 
        }
        
        public Residuo(int pID)
        {

        }
        #endregion

        #region Propriedades
        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }


        #endregion

        #region Dados
        /// <summary>
        /// Faz a inclusão do Resíduo no Banco de Dados.
        /// </summary>
        public override void Inserir()
        {
            Dao.Incluir(this);
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
        
        private DaoResiduo _dao = null;
        DaoResiduo Dao
        {
            get
            {
                if(_dao == null)
                    _dao = new DaoResiduo();

                return _dao;
            }
            
        }

        #endregion
    }
}
