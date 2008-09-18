using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Dao;

namespace SGR.BP.Objeto
{
    public partial class Historico
    {
        #region Construtores

        public Historico()
        { 
        }

        #endregion

        #region Atributos
        private Entidade _entidade;

        private ETipoManutencao _tipoManutencao;

        private Login _login;

        private DateTime _data;

        private int _idMantido;
        #endregion

        #region Propriedades
        public Entidade Entidade
        {
            get { return _entidade; }
            set { _entidade = value; }
        }
        
        public ETipoManutencao Manutencao
        {
            get { return _tipoManutencao; }
            set { _tipoManutencao = value; }
        }
        
        public Login Login
        {
            get { return _login; }
            set { _login = value; }
        }
        
        public DateTime Data
        {
            get { return _data; }
            set { _data = value; }
        }
        
        public int IdMantido
        {
            get { return _idMantido; }
            set { _idMantido = value; }
        }
        #endregion

        #region Data
        private DaoHistorico Dao
        {
            get
            {
                if (_dao == null)
                    _dao = new DaoHistorico();

                return (DaoHistorico)_dao;
            }
        }
        #endregion

    }
}
