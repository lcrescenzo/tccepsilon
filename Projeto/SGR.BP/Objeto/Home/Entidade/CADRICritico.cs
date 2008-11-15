using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;

namespace SGR.BP.Objeto.Home.Entidade
{
    public class CADRICritico : ObjectBase
    {
        #region Atributos
        private ECriticidade _criticidade;
        private int _numero;
        private DateTime _validade;
        #endregion

        #region Propriedades
        
        public ECriticidade Criticidade
        {
            get { return _criticidade; }
            set { _criticidade = value; }
        }
        public int Numero
        {
            get
            {
                return _numero;
            }
            set
            {
                _numero = value;
            }
        }
        public DateTime Validade
        {
            get
            {
                return _validade;
            }
            set
            {
                _validade = value;
            }
        }

        #endregion

        #region Obsoletos
        [Obsolete("Não implementado, não usar", false)]
        public override void Inserir()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        [Obsolete("Não implementado, não usar", false)]
        public override void Alterar()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        [Obsolete("Não implementado, não usar", false)]
        public override void Excluir()
        {
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion

        internal override void PreencheObjeto(System.Data.IDataReader reader)
        {
            this.ID = (int)reader["idCadri"]; 
			this.Numero = (int)reader["numero"]; 
			this.Validade = Convert.ToDateTime(reader["validade"]);
            this.Criticidade = (ECriticidade)Convert.ToInt32(reader["criticidade"]);
        }
    }
}
