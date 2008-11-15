using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Dao;
using SGR.BP.Util;

namespace SGR.BP.Objeto
{
    public partial class Login : ObjectBase
    {

        #region Data
        internal override void PreencheObjeto(System.Data.IDataReader reader)
        {
            this.ID = (int)reader["idUsuario"];
            this.Senha = reader["senha"].ToString();
            this.Usuario = reader["login"].ToString();
        }

        public void Inserir(int id)
        {
            this.ID = id;
            Dao.Incluir(this);
        }

        [Obsolete("Não utlizar este método usar o método 'Inserir(int)'", true)]
        public override void Inserir() { }

        public override void Alterar()
        {
            Dao.Alterar(this);
        }

        public override void Excluir()
        {
            Dao.Excluir(this);
        }

        #endregion

        public void NovaSenha(string urlBase, string email)
        {
            string corpo = string.Empty;
            string endereco = urlBase + "?h=" + this.Senha + "&u=" + Convert.ToBase64String(Encoding.Unicode.GetBytes(this.Usuario));
            
            corpo += "Sua senha foi apagada, para cadastrar uma nova senha <a href='" + endereco + "'>clique aqui</a>, </ br>";
            corpo += "caso o link não funcione, copie o endereço abaixo, cole na barra de endereços de seu navergador.</ br></ br>";

            corpo += endereco + "</ br></ br>";


            corpo += "Este e-mail foi enviado automaticamente pelo sistema SGR, não será possível respondê-lo.";

            Util.General.EnviarEmail("[SGR] - Senha", corpo, "nao-responda@sgr.com.br", email);
        }

        public static Login ValidarPorEmail(string login, string email)
        {
            Login retornoLogin = new Login();
            DaoLogin Dao = new DaoLogin();
            Dao.CarregarPorEmail(login, email, retornoLogin);
            return retornoLogin;
        }

    }
}
