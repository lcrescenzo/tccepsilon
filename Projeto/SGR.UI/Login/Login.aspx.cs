using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using SGR.BP.Objeto;
using SGR.BP.Util;
using System.Security;
using System.Security.Cryptography;

public partial class Login_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GeraCriptografiaSenha();
            CapturaLink();
        }
    }

    private void CapturaLink()
    {
        if (Session["url"] != null)
        {
            ViewState["url"] = Session["url"].ToString();
            Session.Remove("url");
        }
    }

    private void GeraCriptografiaSenha()
    {
        btnEntrar.Attributes.Add("onclick", "javascript:document.getElementById('" + txtSenha.ClientID + "').value = hex_md5(document.getElementById('" + txtSenha.ClientID + "').value)");
    }

    protected void btnEntrar_Click(object sender, EventArgs e)
    {
        try
        {
            Login login = new Login(txtUsuario.Text, txtSenha.Text);
            if (login.ID == -1)
                Session["admin"] = true;
            Session[Constantes.UserLogin.userSessionID] = login.ID;
            string hashUsuario = Util.User.GeraMD5(login.Usuario);
            Session[Constantes.UserLogin.userSessionKey] = hashUsuario;
            Response.Cookies.Add(Util.User.CriarCookie(Constantes.UserLogin.userCookieKey, hashUsuario));
            AdicionaPerfilCache(login);
            Redirecionar();
            
        }
        catch (SGRException exception)
        {
            msg.Mostrar(exception);
        }
    }

    private void Redirecionar()
    {
        if (ViewState["url"] != null)
        {
            Response.Redirect(ViewState["url"].ToString());
        }
        else
        {
            Response.Redirect("~/Telas/Home.aspx");
        }
    }

    private void AdicionaPerfilCache(Login login)
    {
        Usuario usuario = new Usuario(login.ID);
        if (usuario.Perfil != null)
        {
            if (Cache[usuario.Perfil.ID.ToString()] == null)
            {
                Cache[usuario.Perfil.ID.ToString()] = usuario.Perfil;
            }
            Session["idPerfil"] = usuario.Perfil.ID;
        }
        else
        {
            Session["idPerfil"] = null;
        }
    }
}
