using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Dao;
using SGR.BP.Bases;
using SGR.BP.Objeto;
using SGR.BP.Util;

namespace SGR.BP.Objeto
{
    public partial class Residuo 
    {
        #region Construtores
        public Residuo()
        {
            IniciarDao();
        }
        
        public Residuo(int id)
        {
            this.ID = id;
            Dao.Carregar(id, this);
        }

        public Residuo(int id, bool carregaTotal)
        {
            this.ID = id;
            this.CarregarTotal = carregaTotal;
            if(this.CarregarTotal)
                Dao.Carregar(id, this);

        }
        #endregion

        #region Atributos
        private string _nome;
        private TipoResiduo _tipoResiduo = null;
        private Classe _classe;
        private EEstadoFisico _estadoFisico;
        private bool _auditoria;
        private string _unidadeMedida;
        private GrupoResiduo _grupo;
        
        #region OnDemand
        private int _idTipoResiduo = -1;
        private int _idClasse = -1;
        private int _idGrupoResiduo;        
        #endregion
        
        #endregion

        #region Propriedades
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        
        public TipoResiduo TipoResiduo
        {
            get 
            {
                if (Util.General.IsNullOrDisposed(_tipoResiduo))
                    _tipoResiduo = new TipoResiduo(_idTipoResiduo);

                return _tipoResiduo; 
            }
            set 
            {
                _tipoResiduo = value; 
            }
        }

        public Classe Classe
        {
            get 
            {
                if(Util.General.IsNullOrDisposed(_classe))
                    _classe = new Classe(_idClasse);

                return _classe; 
            }
            set 
            { 
                _classe = value; 
            }
        }
                
        public GrupoResiduo Grupo
        {
            get 
            {
                if (Util.General.IsNullOrDisposed(_grupo))
                    _grupo = new GrupoResiduo(_idGrupoResiduo);

                return _grupo; 
            }
            set 
            { 
                _grupo = value; 
            }
        }


        public EEstadoFisico EstadoFisico
        {
            get 
            { 
                //HACK: Verificar Tipo de Estado fisico criado na base de dados
                return _estadoFisico; 
            }
            set 
            { 
                _estadoFisico = value; 
            }
        }

        public bool Auditoria
        {
            get { return _auditoria; }
            set { _auditoria = value; }
        }

        public string UnidadeMedida
        {
            get { return _unidadeMedida; }
            set { _unidadeMedida = value; }
        }

        #endregion

        #region Data

        DaoResiduo Dao
        {
            get
            {
                if(_dao == null)
                    _dao = new DaoResiduo();

                return (DaoResiduo)_dao;
            }
        }

        private void IniciarDao()
        {
            _dao = new DaoResiduo();
        }

        #endregion
    }
}
