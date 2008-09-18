using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Dao;

namespace SGR.BP.Objeto
{
    public partial class Recurso
    {
        #region Contrutores
        public Recurso()
        { 
        }

        public Recurso(int id)
        {
            this.ID = id;
            Dao.Carregar(id, this);
        }
        #endregion

        #region Atributos
        private Recurso _pai;
        private string _nome;
        private ETipoRecurso _tipoRecurso = ETipoRecurso.None;
        private string _idComponente;
        private List<Recurso> _filhos;

        #region OnDemand
        private int? _idPai;
        #endregion
        #endregion

        #region Propriedades

        public Recurso Pai
        {
            get 
            {
                if (Util.General.IsNullOrDisposed(_pai))
                    if(_idPai.HasValue)
                        _pai = new Recurso(_idPai.Value);

                return _pai; 
            }
            set 
            { 
                _pai = value; 
            }
        }
        
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public ETipoRecurso TipoRecurso
        {
            get 
            { 
                return _tipoRecurso; 
            }
            set 
            { 
                _tipoRecurso = value; 
            }
        }

        public string IdComponente
        {
            get { return _idComponente; }
            set { _idComponente = value; }
        }

	    public List<Recurso> Filhos
	    {
		    get { return _filhos;}
		    set { _filhos = value;}
	    }

        #endregion

        #region Data
        
        DaoRecurso Dao
        {
            get
            {
                if (_dao == null)
                    _dao = new DaoRecurso();

                return (DaoRecurso)_dao;
            }

        }
        #endregion
    }
}
