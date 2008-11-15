using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;

namespace SGR.BP.Objeto.Filtro
{
    [Serializable]
    public class FiltroResiduo : IFiltro
    {
        #region Atributos
        private string _nome;

        private int? _tipoResiduo;
                
        private int? _classe;
        
        private string _estadoFisico;

        private bool? _auditoria;
        
        private string _unidadeMedida;
        
        private int? _grupo;
        #endregion

        #region Propriedades
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public int? TipoResiduo
        {
            get { return _tipoResiduo; }
            set { _tipoResiduo = value; }
        }
        
        public int? Classe
        {
            get
            {
                return _classe;
            }
            set
            {
                _classe = value;
            }
        }

        public int? Grupo
        {
            get
            {
                return _grupo;
            }
            set
            {
                _grupo = value;
            }
        }
        
        public string EstadoFisico
        {
            get
            {
                return _estadoFisico;
            }
            set
            {
                _estadoFisico = value;
            }
        }

        public bool? Auditoria
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
    }
}
