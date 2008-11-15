using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;

namespace SGR.BP.Objeto.Home.Entidade
{
    public class ResiduoGrafico : ObjectBase
    {

        #region Atributos
        private double _percentual;
        private string _nome;
        #endregion

        #region Propriedades
        public double Percentual
        {
            get { return _percentual; }
            set { _percentual = value; }
        }
        
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
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
            this.Nome = reader["nome"].ToString();
            this.Percentual = Convert.ToDouble(reader["percentual"]);
        }
    }
}
