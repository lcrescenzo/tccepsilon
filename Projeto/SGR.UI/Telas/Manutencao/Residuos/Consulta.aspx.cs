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

public partial class Telas_Manutencao_Residuos_Consulta : PageBaseConsulta
{
    #region Declaracoes
    public SGR.Web.Controls.Common.TextBox txtNome;
    public SGR.Web.Controls.Common.DropDownList ddlTipoResiduo;
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
    #endregion

    #region Metodos Sobrescritos
    protected override void CapturaControles()
    {
        txtNome = (SGR.Web.Controls.Common.TextBox)Filtro1.FindControl("txtNome");
        ddlTipoResiduo = (SGR.Web.Controls.Common.DropDownList)Filtro1.FindControl("ddlTipoResiduo");
    }


    protected override void CarregaControles()
    {
        CarregaTipoResiduo();
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
        Residuo.Lista((FiltroResiduo)filtro);
    }
    #endregion


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
}
