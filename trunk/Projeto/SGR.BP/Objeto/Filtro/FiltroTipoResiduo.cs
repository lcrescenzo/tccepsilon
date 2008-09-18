using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;

namespace SGR.BP.Objeto.Filtro
{
    [Serializable]
    public class FiltroTipoResiduo : IFiltro
    {
        private int? _id;

        public int? ID
        {
            get { return _id; }
            set { _id = value; }
        }


        private string _descricao;

        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

    }
}
