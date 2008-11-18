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
using SGR.BP.Util;

public partial class Telas_Manutencao_Residuos_Consulta : PageBaseConsulta
{
    #region Declaracoes
    public SGR.Web.Controls.Common.TextBox txtNome;
    public SGR.Web.Controls.Common.DropDownList ddlTipoResiduo;
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

    protected void imgExcluir_Command(object sender, CommandEventArgs e)
    {
        try
        {
            Residuo residuo = new Residuo(int.Parse(e.CommandArgument.ToString()), false);
            residuo.LoginUltimaAlteracao = base.UsuarioLogado;
            base.Remover(residuo);
        }
        catch (SGRException ex)
        {
            Mensagem1.Mostrar(ex);
        }
        
    }

    protected void imgEditar_Command(object sender, CommandEventArgs e)
    {
        base.Editar(int.Parse(e.CommandArgument.ToString()));
    }
    
    protected void gdvLista_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton imgEditar = (ImageButton)e.Row.FindControl("imgEditar");
            ImageButton imgExcluir = (ImageButton)e.Row.FindControl("imgExcluir");
            imgEditar.CommandArgument =
            imgExcluir.CommandArgument = ((Residuo)e.Row.DataItem).ID.ToString();
        }
    }
    #endregion

    #region Metodos Sobrescritos
    protected override void CapturaControles()
    {
        txtNome = (SGR.Web.Controls.Common.TextBox)Filtro1.FindControl("txtNome");
        ddlTipoResiduo = (SGR.Web.Controls.Common.DropDownList)Filtro1.FindControl("ddlTipoResiduo");
    }

    protected override IFiltro MontaFiltro()
    {
        FiltroResiduo filtroResiduo = new FiltroResiduo();
        filtroResiduo.Nome = txtNome.Text;
        if (ddlTipoResiduo.SelectedValue != string.Empty)
            filtroResiduo.TipoResiduo = int.Parse(ddlTipoResiduo.SelectedValue);
        return (IFiltro)filtroResiduo;
    }

    protected override void CarregaFiltro(SGR.BP.Bases.IFiltro filtro)
    {
        FiltroResiduo filtroResiduo = (FiltroResiduo)filtro;
        ddlTipoResiduo.SelectedValue = filtroResiduo.TipoResiduo.ToString();
        ddlTipoResiduo.SelectedValue = filtroResiduo.Nome;
    }

    protected override void CarregaControles()
    {
        CarregaTipoResiduo();
    }

    protected override WebControl BotaoNovo
    {
        get { return btnNovo; }
    }
    #endregion

    #region Metodos
    protected void CarregaTipoResiduo()
    {
        ddlTipoResiduo.DataSource = TipoResiduo.Lista(new FiltroTipoResiduo());
        ddlTipoResiduo.DataValueField = "ID";
        ddlTipoResiduo.DataTextField = "Descricao";
        ddlTipoResiduo.DataBind();
        Util.Telas.AdicionaItemBranco(ddlTipoResiduo);
    }

    protected override void CarregaLista(IFiltro filtro)
    {
        gdvLista.DataSource = Residuo.Lista((FiltroResiduo)filtro);
        gdvLista.DataBind();
    }
    #endregion

    protected override int GridCount
    {
        get { return gdvLista.Rows.Count; }
    }

}
