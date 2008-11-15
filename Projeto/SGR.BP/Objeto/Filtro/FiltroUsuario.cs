using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;

namespace SGR.BP.Objeto.Filtro
{
    [Serializable]
    public class FiltroUsuario : IFiltro
    {
        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private int? _idPerfil;

        public int? Perfil
        {
            get { return _idPerfil; }
            set { _idPerfil = value; }
        }

        private string _usuario;

        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        private string _email;

        public string EMail
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _telefone;

        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }
    }
}
