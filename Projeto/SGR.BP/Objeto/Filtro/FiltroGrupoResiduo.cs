using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;

namespace SGR.BP.Objeto.Filtro
{
    [Serializable]
    public class FiltroGrupoResiduo : IFiltro
    {
        private int? _id;

        private string _nome;


        public int? ID
        {
            get { return _id; }
            set { _id = value; }
        }
        
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

    }
}
