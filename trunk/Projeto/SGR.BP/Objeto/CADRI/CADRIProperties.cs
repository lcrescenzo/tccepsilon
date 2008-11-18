using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Dao;

namespace SGR.BP.Objeto
{
    public partial class CADRI 
    {
        #region Construtores
        public CADRI()
        {
            //Todo CADRI tem validade de um ano, esta data pode ser alterada
            _validade = DateTime.Now.AddYears(1);
        }

        public CADRI(int id)
        {
            this.ID = id;
            Dao.Carregar(ID, this);
        }

        public CADRI(int id, bool carregaTotal)
        {
            this.ID = id;
            this.CarregarTotal = carregaTotal;
            if(CarregarTotal)
                Dao.Carregar(ID, this);
        }
        #endregion

        #region Atributos
        private List<Residuo> _residuos;
        private string _numero;
        private string _destino;
        private double _quantidade;
        private int _oi;
        private DateTime _validade;
        private Login _loginUltimaAlteracao;
        #endregion

        #region Propriedades
        
        public Login LoginUltimaAlteracao
        {
            get
            {
                return _loginUltimaAlteracao;
            }
            set
            {
                _loginUltimaAlteracao = value;
            }
        }
        public List<Residuo> Residuos
        {
            get 
            { 
                if(Util.General.IsNullOrDisposed(_residuos))
                    Dao.CarregarResiduos(this);

                return _residuos; 
            }
            set 
            { 
                _residuos = value; 
            }
        }

        public string Numero
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
        public string Destino
        {
            get 
            { 
                return _destino; 
            }
            set 
            { 
                _destino = value; 
            }
        }
        public double Quantidade
        {
            get 
            { 
                return _quantidade; 
            }
            set 
            { 
                _quantidade = value; 
            }
        }
        public int OI
        {
            get 
            { 
                return _oi; 
            }
            set 
            { 
                _oi = value; 
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

        #region Data

        DaoCADRI Dao
        {
            get
            {
                if (_dao == null)
                    _dao = new DaoCADRI();

                return (DaoCADRI)_dao;
            }
        }
        #endregion
    }
}
