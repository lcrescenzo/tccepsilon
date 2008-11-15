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


public partial class Telas_Administracao_Configuracao_Usuario : PageLogedBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            CarregarConfiguracao();
    }

    protected void btnGravar_Click(object sender, EventArgs e)
    {
        GravarConfiguracoes();
    }

    private void CarregarConfiguracao()
    {
        Configuracao configuracao = Configuracao.Carregar(base.UsuarioLogado.ID);
        if (configuracao != null)
        {
            txtMovimentacoes.Text = ((double)(double.Parse(configuracao["Home.Movimentacao"]) * 100)).ToString(Util.Formatacao.Numero);
            txtCADRI.Text = configuracao["Home.CADRI"];
            ddlMesesGrafico.SelectedValue = configuracao["Home.GrafMeses"];
            ddlQtdResiduos.SelectedValue = configuracao["Home.GrafQtdResiduo"];
        }
    }

    private void GravarConfiguracoes()
    {
        Configuracao configuracao = new Configuracao();
        configuracao.Login = base.UsuarioLogado;
        configuracao["Home.Movimentacao"] = ((double)(double.Parse(txtMovimentacoes.Text) / 100)).ToString(Util.Formatacao.Numero);
        configuracao["Home.CADRI"] = txtCADRI.Text;
        configuracao["Home.GrafMeses"] = ddlMesesGrafico.SelectedValue;
        configuracao["Home.GrafQtdResiduo"] = ddlQtdResiduos.SelectedValue;
        configuracao.Alterar();
    }
}
