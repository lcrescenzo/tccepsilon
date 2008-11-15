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

public partial class Telas_Manutencao_CADRI_Consulta : PageBaseConsulta
{
    #region Declaracoes
    public SGR.Web.Controls.Common.TextBox txtNumero;
    public SGR.Web.Controls.Ajax.Calendar cldValidade;
    public SGR.Web.Controls.Common.TextBox txtDestino;
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
            imgExcluir.CommandArgument = ((CADRI)e.Row.DataItem).ID.ToString();



        }
    }

    protected void imgExcluir_Command(object sender, CommandEventArgs e)
    {
        base.Remover(new CADRI(int.Parse(e.CommandArgument.ToString()), false));
    }

    protected void imgEditar_Command(object sender, CommandEventArgs e)
    {
        base.Editar(int.Parse(e.CommandArgument.ToString()));
    }
    #endregion

    #region Metodos Sobrescritos
    protected override void CapturaControles()
    {
        txtNumero = (SGR.Web.Controls.Common.TextBox)Filtro1.FindControl("txtNumero");
        cldValidade = (SGR.Web.Controls.Ajax.Calendar)Filtro1.FindControl("cldValidade");
        txtDestino = (SGR.Web.Controls.Common.TextBox)Filtro1.FindControl("txtDestino");
    }

    protected override void CarregaControles()
    {
    }

    protected override IFiltro MontaFiltro()
    {
        FiltroCADRI filtroCADRI = new FiltroCADRI();
        filtroCADRI.Numero = (txtNumero.Text != string.Empty) ? (int?)int.Parse(txtNumero.Text) : null;
        filtroCADRI.Destino = txtNumero.Text;
        filtroCADRI.Validade = cldValidade.SelectedDate;
        return (IFiltro)filtroCADRI;
    }

    protected override void CarregaFiltro(IFiltro filtro)
    {
        FiltroCADRI oFiltro = (FiltroCADRI)filtro;

        txtNumero.Text = oFiltro.Numero.ToString();
        txtDestino.Text = oFiltro.Destino;
        cldValidade.SelectedDate = oFiltro.Validade;
    }

    protected override WebControl BotaoNovo
    {
        get { return btnNovo; }
    }
    
    protected override void CarregaLista(IFiltro filtro)
    {
        gdvLista.DataSource = CADRI.Lista((FiltroCADRI)filtro);
        gdvLista.DataBind();
    }    
    #endregion

    #region Metodos
    
    #endregion
    protected void gdvLista_RowCreated(object sender, GridViewRowEventArgs e)
    {
        
    }
}
