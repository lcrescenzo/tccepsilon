using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Dao;
using SGR.BP.Objeto;

namespace SGR.BP.Objeto
{
    public partial class Movimentacao
    {
        #region Contrutores
        public Movimentacao()
        { 
        }

        public Movimentacao(int id)
        {
            this.ID = id;
            Dao.Carregar(id, this);
        }
        #endregion

        #region Atributos
        private static List<Transporte> _transportes = null;
        private CADRI _cadri;
        private Residuo _residuo;
        private Login _login;
        
        #region OnDemand
        private int _idCadri = -1;
        private int _idResiduo = -1;
        private int _idLogin = -1;
        #endregion
        #endregion

        #region Propriedades
        public List<Transporte> Transportes
        {
            get
            {
                if (Util.General.IsNullOrDisposed(_transportes))
                    Dao.CarregarTransportes(this);
                return _transportes;   
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

        public Login Login
        {
            get 
            {
                if (Util.General.IsNullOrDisposed(_login))
                    _login = new Login(_idLogin);
                return _login; 
            }
            set 
            { 
                _login = value; 
            }
        }

        #endregion

        #region Data
        DaoMovimentacao Dao
        {
            get
            {
                if (_dao == null)
                    _dao = new DaoMovimentacao();

                return (DaoMovimentacao)_dao;
            }

        }
        #endregion
    }
}
