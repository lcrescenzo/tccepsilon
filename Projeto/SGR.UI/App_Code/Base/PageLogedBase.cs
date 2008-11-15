using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using SGR.BP.Objeto;


public class PageLogedBase : PageBase
{
    public PageLogedBase()
    {

    }

    protected override void OnInit(EventArgs e)
    {
        if (!ValidateLogin())
        {
            Session.Add("url", Request.Url.AbsoluteUri);
            Response.Redirect("~/Login/login.aspx");
        }

        base.OnInit(e);
        
    }

    private bool ValidateLogin()
    {
        if (Request.Cookies[Constantes.UserLogin.userCookieKey] != null && Session[Constantes.UserLogin.userSessionKey] != null)
        {
            if (Request.Cookies[Constantes.UserLogin.userCookieKey].Value != Session[Constantes.UserLogin.userSessionKey].ToString())
                return false;
            else
                return true;
        }
        return false;

    }

    private string GetClientUserID()
    {
        return base.Request.Cookies[Constantes.UserLogin.userCookieKey].Value;
    }

    private Login _usuarioLogado;
    public Login UsuarioLogado
    {
        get 
        { 
            if(_usuarioLogado == null)
                _usuarioLogado = new Login((int)Session[Constantes.UserLogin.userSessionID]);

            return _usuarioLogado;
        }
    }
    
    public Configuracao ConfiguracaoSistema
    {
        get 
        {
            if (Application["ConfiguracaoSistema"] == null)
                Application["ConfiguracaoSistema"] = Configuracao.Carregar(null);

            return (Configuracao)Application["ConfiguracaoSistema"]; 
        }
        set 
        {
            Application["ConfiguracaoSistema"] = value; 
        }
    }

    Configuracao _configuracaoUsuario = null;
    public Configuracao ConfiguracaoUsuario
    {
        get
        {
            if (_configuracaoUsuario == null)
                _configuracaoUsuario = Configuracao.Carregar(UsuarioLogado.ID);

            return _configuracaoUsuario;
        }
        set
        {
            _configuracaoUsuario = value;
        }
    }
}
