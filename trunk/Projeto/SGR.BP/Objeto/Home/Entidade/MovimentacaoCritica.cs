using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;

namespace SGR.BP.Objeto.Home.Entidade
{
    public class MovimentacaoCritica : ObjectBase
    {
        private ECriticidade _criticidade;

        public ECriticidade Criticidade
        {
            get { return _criticidade; }
            set { _criticidade = value; }
        }


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

        internal override void PreencheObjeto(System.Data.IDataReader reader)
        {
            this.ID = (int)reader["idMovimentacao"];
            this.CADRI = new CADRI((int)reader["idCadri"]);
            this.Residuo = new Residuo((int)reader["idResiduo"]);
            this.Permitido = Convert.ToDouble(reader["permitido"]);
            this.Transportado = Convert.ToDouble(reader["transportado"]);
            this.Criticidade = (ECriticidade)Convert.ToInt32(reader["criticidade"]);
        }


        #region Atributos
        private CADRI _cadri;
        private Residuo _residuo;
        private int _idCadri = -1;
        private int _idResiduo = -1;
        private double _permitido;
        private double _transportado;
        #endregion

        #region Propriedades
        
        public double Permitido
        {
            get 
            { 
                return _permitido; 
            }
            set 
            { 
                _permitido = value; 
            }
        }
        
        public double Transportado
        {
            get 
            { 
                return _transportado; 
            }
            set 
            { 
                _transportado = value; 
            }
        }

        public CADRI CADRI
        {
            get
            {
                if (Util.General.IsNullOrDisposed(_cadri))
                    _cadri = new CADRI(_idCadri);

                return _cadri;
            }
            set
            {
                _cadri = value;
            }
        }

        public Residuo Residuo
        {
            get
            {
                if (Util.General.IsNullOrDisposed(_residuo))
                    _residuo = new Residuo(_idResiduo);

                return _residuo;
            }
            set
            {
                _residuo = value;
            }
        }
        #endregion
    }
}
