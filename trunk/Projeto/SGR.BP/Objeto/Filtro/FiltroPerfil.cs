using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;

namespace SGR.BP.Objeto.Filtro
{
    [Serializable]
    public class FiltroPerfil : IFiltro
    {
        private string _nome;

        public string Nome
        {
            get 
            { 
                return _nome; 
            }
            set 
            { 
                _nome = value; 
            }
        }

    }
}
