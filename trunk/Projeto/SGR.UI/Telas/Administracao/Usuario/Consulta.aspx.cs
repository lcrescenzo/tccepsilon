using System; 
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using SGR.BP.Objeto;
using SGR.BP.Objeto.Filtro;
using Util;
using SGR.BP.Bases;
using SGR.Web.Controls.Common;
using SGR.BP.Util;

public partial class Telas_Administracao_Usuario_Consulta : PageBaseConsulta
{
    #region Declaracoes
    public SGR.Web.Controls.Common.TextBox txtNome;
    public SGR.Web.Controls.Common.TextBox txtEmail;
    public SGR.Web.Controls.Common.TextBox txtUsuario;
    public SGR.Web.Controls.Common.TextBox txtTelefone;
    public SGR.Web.Controls.Common.DropDownList ddlPerfil;
    #endregion

    #region Eventos
    protected void Page_Load(object sender, EventArgs e) { }

    protected void btnNovo_Click(object sender, EventArgs e)
    {
        base.Novo();
    }

    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        CarregaLista(MontaFiltro());
    }

    protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        {
            ImageButton imgEditar = (ImageButton)e.Row.FindControl("imgEditar");
            ImageButton imgExcluir = (ImageButton)e.Row.FindControl("imgExcluir");
            ImageButton imgApagar = (ImageButton)e.Row.FindControl("imgApagar");
            imgApagar.CommandArgument =
            imgEditar.CommandArgument =
            imgExcluir.CommandArgument = ((Usuario)e.Row.DataItem).ID.ToString();
        }
    }

    protected void imgApagar_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
    {
        Usuario usuario = new Usuario(int.Parse(e.CommandArgument.ToString()));
        try
        {
            usuario.Login.NovaSenha(Util.UrlUtil.ResolveServerUrl("~/Login/NovaSenha.aspx"), usuario.EMail);// Envia Email ao usuario

        }
        catch (SGRException ex)
        {
            Mensagem1.Mostrar(ex);
        }
    }

    protected void imgExcluir_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
    {
        Usuario usuario = new Usuario(int.Parse(e.CommandArgument.ToString()), false);
        usuario.LoginUltimaAlteracao = base.UsuarioLogado;
        base.Remover(usuario);
    }

    protected void imgEditar_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
    {
        base.Editar(int.Parse(e.CommandArgument.ToString()));
    }
    #endregion

    #region Metodos Sobrescritos
    protected override void CapturaControles()
    {
        txtNome = (SGR.Web.Controls.Common.TextBox)Filtro1.FindControl("txtNome");
        txtEmail = (SGR.Web.Controls.Common.TextBox)Filtro1.FindControl("txtEmail");
        txtUsuario = (SGR.Web.Controls.Common.TextBox)Filtro1.FindControl("txtUsuario");
        txtTelefone = (SGR.Web.Controls.Common.TextBox)Filtro1.FindControl("txtTelefone");
        ddlPerfil = (SGR.Web.Controls.Common.DropDownList)Filtro1.FindControl("ddlPerfil");
    }

    protected override void CarregaControles()
    {
        CarregaPerfil();
    }

    protected override IFiltro MontaFiltro()
    {
        FiltroUsuario filtroUsuario = new FiltroUsuario();
        filtroUsuario.Nome = txtNome.Text;
        filtroUsuario.EMail = txtEmail.Text;
        filtroUsuario.Perfil = (ddlPerfil.SelectedValue != string.Empty) ? (int?)int.Parse(ddlPerfil.SelectedValue) : null; 
        filtroUsuario.Telefone = txtTelefone.Text;
        filtroUsuario.Usuario = txtUsuario.Text;

        return (IFiltro)filtroUsuario;
    }

    protected override void CarregaFiltro(IFiltro filtro)
    {
        FiltroUsuario oFiltro = (FiltroUsuario)filtro;
        txtNome.Text = oFiltro.Nome;
        txtEmail.Text = oFiltro.EMail;
        ddlPerfil.SelectedValue = (oFiltro.Perfil.HasValue) ? oFiltro.Perfil.ToString() : string.Empty;
        txtTelefone.Text = oFiltro.Telefone;
        txtUsuario.Text = oFiltro.Usuario;
    }

    protected override System.Web.UI.WebControls.WebControl BotaoNovo
    {
        get { return btnNovo; }
    }

    #endregion

    #region Metodos
    private void CarregaPerfil()
    {
        ddlPerfil.DataSource = Perfil.Lista(new FiltroPerfil());
        ddlPerfil.DataTextField = "Nome";
        ddlPerfil.DataValueField = "ID";
        ddlPerfil.DataBind();
        Util.Telas.AdicionaItemBranco(ddlPerfil);
    }

    protected override void CarregaLista(IFiltro filtro)
    {
        gdvLista.DataSource = Usuario.Lista((FiltroUsuario)filtro);
        gdvLista.DataBind();
    }
    #endregion

    protected override int GridCount
    {
        get { return gdvLista.Rows.Count; }
    }

}
