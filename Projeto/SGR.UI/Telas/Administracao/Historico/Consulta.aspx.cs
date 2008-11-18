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

public partial class Telas_Manutencao_Historico_Consulta : PageBaseConsulta
{
    #region Declaracoes
    public SGR.Web.Controls.Common.DropDownList ddlEntidade;
    public SGR.Web.Controls.Common.DropDownList ddlManutencao;
    public SGR.Web.Controls.Ajax.Calendar cldDe;
    public SGR.Web.Controls.Ajax.Calendar cldAte;
    public SGR.Web.Controls.Common.DropDownList ddlUsuario;
    public SGR.Web.Controls.Common.TextBox txtAte;
    public SGR.Web.Controls.Common.TextBox txtDe;
    #endregion

    #region Eventos
    protected void Page_Load(object sender, EventArgs e) 
    { 
    }

    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        CarregaLista(MontaFiltro());
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
       
        }
    }

    #endregion

    #region Metodos Sobrescritos
    protected override void CapturaControles()
    {
        ddlEntidade = (SGR.Web.Controls.Common.DropDownList)Filtro1.FindControl("ddlEntidade");
        ddlManutencao = (SGR.Web.Controls.Common.DropDownList)Filtro1.FindControl("ddlManutencao");
        cldDe = (SGR.Web.Controls.Ajax.Calendar)Filtro1.FindControl("cldDe");
        cldAte = (SGR.Web.Controls.Ajax.Calendar)Filtro1.FindControl("cldAte");
        ddlUsuario = (SGR.Web.Controls.Common.DropDownList)Filtro1.FindControl("ddlUsuario");
        txtDe = (SGR.Web.Controls.Common.TextBox)Filtro1.FindControl("txtDe");
        txtAte = (SGR.Web.Controls.Common.TextBox)Filtro1.FindControl("txtAte");
    }

    protected override void CarregaControles()
    {
        if (!IsPostBack)
        {
            cldAte.Format = Util.Formatacao.Data.ShortDatePattern;
            cldDe.Format = Util.Formatacao.Data.ShortDatePattern;
        }
    }

    protected override IFiltro MontaFiltro()
    {
        FiltroHistorico filtroHistorico = new FiltroHistorico();
        if (ddlUsuario.SelectedValue != string.Empty && ddlUsuario.SelectedValue != null)
            filtroHistorico.Usuario = int.Parse(ddlUsuario.SelectedValue);
        filtroHistorico.Entidade = int.Parse(ddlEntidade.SelectedValue);
        filtroHistorico.Manutencao = int.Parse(ddlManutencao.SelectedValue);
        
        if (txtDe.Text != string.Empty)
            filtroHistorico.DataInicio = DateTime.Parse(txtDe.Text, Util.Formatacao.Data);
        else
            filtroHistorico.DataInicio = null;

        if (txtAte.Text != string.Empty)
            filtroHistorico.DataFim = DateTime.Parse(txtAte.Text, Util.Formatacao.Data);
        else
            filtroHistorico.DataFim = null;

        return (IFiltro)filtroHistorico;
    }

    protected override void CarregaFiltro(IFiltro filtro)
    {
        FiltroHistorico oFiltro = (FiltroHistorico)filtro;
        if(oFiltro.DataInicio.HasValue)
            txtDe.Text = oFiltro.DataInicio.Value.ToString(Util.Formatacao.Data.ShortDatePattern);
        
        if(oFiltro.DataFim.HasValue)
            txtAte.Text = oFiltro.DataFim.Value.ToString(Util.Formatacao.Data.ShortDatePattern);
        
        cldDe.SelectedDate = oFiltro.DataInicio;
        cldAte.SelectedDate = oFiltro.DataFim;
        ddlUsuario.SelectedValue = oFiltro.Usuario.ToString();
        ddlEntidade.SelectedValue = oFiltro.Entidade.ToString();
        ddlManutencao.SelectedValue = oFiltro.Manutencao.ToString();
    }

    protected override WebControl BotaoNovo
    {
        get { return null; }
    }
    
    protected override void CarregaLista(IFiltro filtro)
    {
        gdvLista.DataSource = Historico.Lista((FiltroHistorico)filtro);
        gdvLista.DataBind();
    }    
    #endregion

    #region Metodos
    
    #endregion
    protected override int GridCount
    {
        get { return gdvLista.Rows.Count; }
    }

}
