using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Text;
using SGR.BP.Objeto;
using SGR.BP.Util;

public partial class Login_EsqueciMinhaSenha : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        CapturaInformacoes();
        if(!IsPostBack)
            GeraCriptografiaSenha();
    }
    private void GeraCriptografiaSenha()
    {
        btnConfirmar.Attributes.Add("onclick", "javascript:document.getElementById('" + txtSenha.ClientID + "').value = hex_md5(document.getElementById('" + txtSenha.ClientID + "').value);document.getElementById('" + txtConfirmacaoSenha.ClientID + "').value = hex_md5(document.getElementById('" + txtConfirmacaoSenha.ClientID + "').value)");
    }
    private void CapturaInformacoes()
    {
        if (Request.QueryString["u"] != null && Request.QueryString["h"] != null)
        {
            try
            {
                string usuario = Encoding.Unicode.GetString(Convert.FromBase64String(Request.QueryString["u"]));
                string senha = Request.QueryString["h"];
                Login login = new Login(usuario, senha);
                txtUsuario.Text = usuario;
                ViewState["idUsuario"] = login.ID;
            }
            catch (SGRException exception)
            {
                msg.Mostrar(exception);
            }
        }
    }

    protected void btnConfirmar_Click(object sender, EventArgs e)
    {
        if (txtSenha.Text == txtConfirmacaoSenha.Text)
        {
            Login login = new Login((int)ViewState["idUsuario"]);
            login.Senha = txtSenha.Text;
            login.Alterar();
            Response.Redirect("Login.aspx");
        }
        else
        {
            lblMensagem.Text = "A senha e a confirmação devem ser idênticas.";
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}
