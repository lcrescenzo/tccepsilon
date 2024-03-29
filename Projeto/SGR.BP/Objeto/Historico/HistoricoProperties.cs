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
        private string _entidade;

        private string _tipoManutencao;

        private string _login;

        private DateTime _data;

        private int _idMantido;
        #endregion

        #region Propriedades
        public string Entidade
        {
            get { return _entidade; }
            set { _entidade = value; }
        }
        
        public string Manutencao
        {
            get { return _tipoManutencao; }
            set { _tipoManutencao = value; }
        }
        
        public string Login
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
