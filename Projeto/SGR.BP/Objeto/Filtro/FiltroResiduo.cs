using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;

namespace SGR.BP.Objeto.Filtro
{
    [Serializable]
    public class FiltroResiduo : IFiltro
    {
        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private int _tipoResiduo;

        public int TipoResiduo
        {
            get { return _tipoResiduo; }
            set { _tipoResiduo = value; }
        }

    }
}
