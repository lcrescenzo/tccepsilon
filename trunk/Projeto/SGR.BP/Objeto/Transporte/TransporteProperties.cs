using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Objeto;
using SGR.BP.Dao;

namespace SGR.BP.Objeto
{
    public partial class Transporte
    {
        #region Contrutores
        public Transporte()
        {
        }

        public Transporte(int pId)
        {
            this.ID = pId;
            Dao.Carregar(this.ID, this);
        }

        public Transporte(int pId, bool carregarTotal)
        {
            this.ID = pId;
            this.CarregarTotal = carregarTotal;
            if(CarregarTotal)
                Dao.Carregar(this.ID, this);
        }
        #endregion

        #region Atributos
        private DateTime _data;
        private double _quantidade;
        private Login _loginUltimaAlteracao;
        private Movimentacao _movimentacao;
        private string _transportadora;

        #region OnDemand
        private int _idLoginUltimaAlteracao = int.MinValue;
        private int _idMovimentacao = int.MinValue;
        #endregion

        #endregion

        #region Propriedades

        public DateTime Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public Login LoginUltimaAlteracao
        {
            get 
            {
                if (Util.General.IsNullOrDisposed(_loginUltimaAlteracao))
                    _loginUltimaAlteracao = new Login(_idLoginUltimaAlteracao);
                return _loginUltimaAlteracao; 
            }
            set 
            { 
                _loginUltimaAlteracao = value; 
            }
        }

        public Movimentacao Movimentacao
        {
            get 
            {
                if (Util.General.IsNullOrDisposed(_movimentacao))
                    _movimentacao = new Movimentacao(_idMovimentacao);

                return _movimentacao; 
            }
            set 
            { 
                _movimentacao = value; 
            }
        }

        public double Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }

        public string Transportadora
        {
            get 
            { 
                return _transportadora; 
            }
            set 
            { 
                _transportadora = value; 
            }
        }

        #endregion
        
        #region Data
        DaoTransporte Dao
        {
            get
            {
                if (_dao == null)
                    _dao = new DaoTransporte();

                return (DaoTransporte)_dao;
            }

        }
        #endregion
    }
}
