using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;

namespace SGR.BP.Objeto.Filtro
{
    [Serializable]
    public class FiltroCADRI : IFiltro
    {
        private string _numero = null;

        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        private DateTime? _validade = null;

        public DateTime? Validade
        {
            get { return _validade; }
            set { _validade = value; }
        }

        private string _destino = null;

        public string Destino
        {
            get { return _destino; }
            set { _destino = value; }
        }

    }
}
