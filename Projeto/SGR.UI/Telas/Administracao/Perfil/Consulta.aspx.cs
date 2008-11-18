using System; 
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SGR.BP.Objeto;
using SGR.BP.Objeto.Filtro;
using Util;
using SGR.BP.Bases;

public partial class Telas_Administracao_Perfil_Consulta : PageBaseConsulta
{
    #region Declaracoes
    public SGR.Web.Controls.Common.TextBox txtNome;
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

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton imgEditar = (ImageButton)e.Row.FindControl("imgEditar");
            ImageButton imgExcluir = (ImageButton)e.Row.FindControl("imgExcluir");
            imgEditar.CommandArgument =
            imgExcluir.CommandArgument = ((Perfil)e.Row.DataItem).ID.ToString();
        }
    }

    protected void imgExcluir_Command(object sender, CommandEventArgs e)
    {
        Perfil perfil = new Perfil(int.Parse(e.CommandArgument.ToString()), false);
        perfil.LoginUltimaAlteracao = base.UsuarioLogado;
        base.Remover(perfil);
    }

    protected void imgEditar_Command(object sender, CommandEventArgs e)
    {
        base.Editar(int.Parse(e.CommandArgument.ToString()));
    }
    #endregion

    #region Metodos Sobrescritos
    protected override void CapturaControles()
    {
        txtNome = (SGR.Web.Controls.Common.TextBox)Filtro1.FindControl("txtNome");
    }

    protected override void CarregaControles()
    {
    }

    protected override IFiltro MontaFiltro()
    {
        FiltroPerfil filtroPerfil = new FiltroPerfil();
        filtroPerfil.Nome = txtNome.Text;

        return (IFiltro)filtroPerfil;
    }

    protected override void CarregaFiltro(IFiltro filtro)
    {
        FiltroPerfil oFiltro = (FiltroPerfil)filtro;

        txtNome.Text = oFiltro.Nome;
    }

    protected override WebControl BotaoNovo
    {
        get { return btnNovo; }
    }
    #endregion

    #region Metodos
    protected override void CarregaLista(IFiltro filtro)
    {
        gdvLista.DataSource = Perfil.Lista((FiltroPerfil)filtro);
        gdvLista.DataBind();
    }

    #endregion

    protected override int GridCount
    {
        get { return gdvLista.Rows.Count; }
    }
}
