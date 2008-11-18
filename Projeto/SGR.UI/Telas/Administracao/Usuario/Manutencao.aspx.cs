using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using SGR.BP.Bases;
using SGR.BP.Objeto;
using SGR.BP.Objeto.Filtro;
using SGR.BP.Util;

public partial class Telas_Manutencao_Usuario_Manutencao : PageBaseManutencao<Usuario>
{
    

    #region Eventos
    protected void Page_Load(object sender, EventArgs e)
    {
        MenssagemOK1.OK += new MenssagemOK.OnOK(MenssagemOK1_OK);
    }

    void MenssagemOK1_OK()
    {
        Session["filtro"] = ViewState["filtro"];
        Response.Redirect("Consulta.aspx");
    }

    protected void btnGravar_Click(object sender, EventArgs e)
    {
        bool redirecionar = true;
        try
        {
            EnviarEmail(PreparaLogin());
        }
        catch(SGRException ex)
        {
            redirecionar = false;
            MenssagemOK1.Mostrar(ex.Message);
        }
        GravarUsuario();

        if (redirecionar)
        {
            Context.Items["filtro"] = ViewState["filtro"];
            Server.Transfer("Consulta.aspx");
        }
    }

    private void GravarUsuario()
    {
        switch (TipoManutencao)
        {
            case ETipoManutencao.Inclusao: Incluir(); break;
            case ETipoManutencao.Alteracao: Alterar(); break;
        }
       
    }

    private void Incluir()
    {
        Usuario obj = PreparaObjeto();
        obj.Inserir();
        Objeto = obj;
    }

    private void Alterar()
    {
        PreencherObjeto();
        ((ObjectBase)Objeto).Alterar();
    }

    private void EnviarEmail(Login login)
    {
        login.NovaSenha(Util.UrlUtil.ResolveServerUrl("~/Login/NovaSenha.aspx"), txtEmail.Text);// Envia Email ao usuario
    }
    
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Cancelar();
    }
    #endregion

    #region Metodos Sobrescritos

    protected override void LimparCampos()
    {
        txtEmail.Text = string.Empty;
    }

    private Login PreparaLogin()
    {
        Login login = new Login();
        login.Usuario = txtUsuario.Text;
        login.Senha = "846c81d2255f2922e3c5ad9bbaa70c2a";
        return login;
    }

    protected override Usuario PreparaObjeto()
    {
        Usuario usuario = new Usuario();
        usuario.Nome = txtNome.Text;
        usuario.EMail = txtEmail.Text;
        usuario.Endereco = txtEndereco.Text;
        usuario.CPF = string.Empty;
        usuario.Perfil = new Perfil(int.Parse(ddlPerfil.SelectedValue), false);
        usuario.Telefone = txtTelefone.Text;
        usuario.LoginUltimaAlteracao = base.UsuarioLogado;
        usuario.Login = new Login();
        usuario.Login.Usuario = txtUsuario.Text;
        return usuario;
    }

    protected override void PreencherObjeto()
    {
        Objeto.Nome = txtNome.Text;
        Objeto.EMail = txtEmail.Text;
        Objeto.Endereco = txtEndereco.Text;
        Objeto.LoginUltimaAlteracao = base.UsuarioLogado;
        Objeto.CPF = string.Empty;
        Objeto.Perfil = new Perfil(int.Parse(ddlPerfil.SelectedValue), false);
        Objeto.Telefone = txtTelefone.Text;
    }

    protected override void PreencherCampos()
    {
        txtNome.Text = Objeto.Nome;
        txtEmail.Text = Objeto.EMail; 
        txtEndereco.Text = Objeto.Endereco;
        ddlPerfil.SelectedValue = Objeto.Perfil.ID.ToString();
        txtTelefone.Text = Objeto.Telefone;
        txtUsuario.Text = new Login(Objeto.ID).Usuario;
        txtUsuario.Enabled = false;//O login não pode ser alterado
    }

    protected override Usuario CarregarObjeto(int id)
    {
        return new Usuario(id);
    }

    protected override void CarregarCampos()
    {
        CarregaPerfil();
    }

    private void CarregaPerfil()
    {
        ddlPerfil.DataSource = Perfil.Lista(new FiltroPerfil());
        ddlPerfil.DataTextField = "Nome";
        ddlPerfil.DataValueField = "ID";
        ddlPerfil.DataBind();
    }
    #endregion
}

