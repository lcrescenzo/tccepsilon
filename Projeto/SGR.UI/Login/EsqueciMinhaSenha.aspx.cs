using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using SGR.BP.Objeto;
using SGR.BP.Util;

public partial class Login_EsqueciMinhaSenha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
    protected void btnEnviarEmail_Click(object sender, EventArgs e)
    {
        try
        {
            ValidaUsuario().NovaSenha(Util.UrlUtil.ResolveServerUrl("~/Login/NovaSenha.aspx"), txtEmail.Text);
        }
        catch (SGRException exception)
        {
            MenssagemOK1.Mostrar(exception.Message);
        }
    }

    private Login ValidaUsuario()
    {
        Login login = null;
        login = Login.ValidarPorEmail(txtUsuario.Text, txtEmail.Text);
        return login;
    }
}
