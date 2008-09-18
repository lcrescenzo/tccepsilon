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

public partial class Telas_Manutencao_GrupoResiduos_Consulta : PageBaseConsulta
{
    #region Declaracoes
    public SGR.Web.Controls.Common.TextBox txtNome;
    #endregion

    #region Eventos
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

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
            imgExcluir.CommandArgument = ((GrupoResiduo)e.Row.DataItem).ID.ToString();
        }
    }

    protected void imgExcluir_Command(object sender, CommandEventArgs e)
    {
        base.Remover(new GrupoResiduo(int.Parse(e.CommandArgument.ToString()), false));
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
        FiltroGrupoResiduo filtroGrupoResiduo = new FiltroGrupoResiduo();
        filtroGrupoResiduo.Nome = txtNome.Text;

        return (IFiltro)filtroGrupoResiduo;
    }

    protected override void CarregaFiltro(IFiltro filtro)
    {
        FiltroGrupoResiduo oFiltro = (FiltroGrupoResiduo)filtro;

        txtNome.Text = oFiltro.Nome;
    }

    #endregion

    #region Metodos


    protected override void CarregaLista(IFiltro filtro)
    {
        gdvLista.DataSource = GrupoResiduo.Lista((FiltroGrupoResiduo)filtro);
        gdvLista.DataBind();
    }
    #endregion
}
