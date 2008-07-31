using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Objeto;
using SGR.BP.Dao;

namespace SGR.BP.Objetos
{
    public class Transporte : ObjectBase
    {
        #region Contrutores
        public Transporte()
        {
        }

        public Transporte(DateTime data)
        {
            this.Data = data;
            this.PreencheObjeto(Dao.Carregar(data));
        }
        #endregion

        #region Atributos
        private DateTime _data;
        private double _quantidade;
        private Login _loginUltimaAlteracao;
        private Movimentacao _movimentacao;
        private string _transportadora;

        #region OnDemand
        private int _idLoginUltimaAlteracao;
        private int _idMovimentacao;
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
                return Transportadora; 
            }
            set 
            { 
                Transportadora = value; 
            }
        }

        #endregion
        
        #region Data
        internal override void PreencheObjeto(System.Data.IDataReader reader)
        {
            this.Quantidade = (int)reader["quantidade"];
        }

        DaoTransporte Dao
        {
            get
            {
                if (_dao == null)
                    _dao = (IDao<ObjectBase>)(new DaoTransporte());

                return (DaoTransporte)_dao;
            }

        }
        #endregion
    }
}
