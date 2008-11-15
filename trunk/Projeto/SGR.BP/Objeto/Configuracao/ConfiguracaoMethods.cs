using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Dao;

namespace SGR.BP.Objeto
{
    public partial class Configuracao : Dictionary<string, string>
    {

        public Configuracao()
        { 
        }

        public Configuracao(int idUsuario)
        {
            _idLogin = idUsuario;
        }

        public static string ValorDe(int? idUsuario, string chave)
        {
            return DaoConfiguracao.ValorDe(idUsuario, chave);
        }

        public static Configuracao Carregar(int? idUsuario)
        {
            Configuracao configuracao = DaoConfiguracao.Carregar(idUsuario);
            if(configuracao != null)
                configuracao._idLogin = idUsuario;
            return configuracao;
        }

        public void Alterar()
        {
            DaoConfiguracao.Alterar(this);
        }

        public void Incluir()
        {
            DaoConfiguracao.Incluir(this);
        }

        public void Excluir()
        {
            DaoConfiguracao.Excluir(this);
        }
    }
}
