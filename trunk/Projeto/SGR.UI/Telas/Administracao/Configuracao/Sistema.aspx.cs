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
using Telas.Administracao.Confuguracao.UserControl;
using System.Drawing;
using System.IO;


public partial class Telas_Administracao_Configuracao_Sistema : PageLogedBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregarTipoResiduo();
            CarregarClasse();
            CarregaConfiguracao();
            Cores();
        }
    }

    private void Cores()
    {
        tblCores.Attributes["onclick"] = "tblCores_onclick(event.srcElement.bgColor,'" + txtCor.ClientID + "');";
    }
        
    #region Metodos de Carga
    private void CarregarTipoResiduo()
    {
        tbdTipoResiduo.DataSource = TipoResiduo.Lista(new SGR.BP.Objeto.Filtro.FiltroTipoResiduo());
        tbdTipoResiduo.DataKeyNames = new string[] { "ID" };
        tbdTipoResiduo.DescricaoField = "Descricao";
        tbdTipoResiduo.DataBind();
    }

    private void CarregarClasse()
    {
        tbdClasse.DataSource = Classe.Lista(new SGR.BP.Objeto.Filtro.FiltroClasse());
        tbdClasse.DataKeyNames = new string[] { "ID" };
        tbdClasse.DescricaoField = "Descricao";
        tbdClasse.DataBind();
    }
    
    private void CarregaConfiguracao()
    {
        Configuracao configuracao = Configuracao.Carregar(null);//Configuracao genérica
        if (configuracao != null)
        {
            txtMovimentacoes.Text = ((double)(double.Parse(configuracao["Home.Movimentacao"]) * 100)).ToString(Util.Formatacao.Numero);
            txtCADRI.Text = configuracao["Home.CADRI"];
            ddlMesesGrafico.SelectedValue = configuracao["Home.GrafMeses"];
            ddlQtdResiduos.SelectedValue = configuracao["Home.GrafQtdResiduo"];
            txtCor.Value = configuracao["Apar.CorTopo"];
            txtCor.Style.Add(HtmlTextWriterStyle.BackgroundColor, configuracao["Apar.CorTopo"]);
            //configuracao["Apar.LogoNomeArq"];
            //configuracao["Apar.LogoTop"] = "10";
            //configuracao["Apar.LogoLeft"] = "10";
        }

    }
    
    private void GravarConfiguracoes()
    {
        Configuracao configuracao = new Configuracao();
        configuracao["Home.Movimentacao"] = ((double)(double.Parse(txtMovimentacoes.Text) / 100)).ToString(Util.Formatacao.Numero);
        configuracao["Home.CADRI"] = txtCADRI.Text;
        configuracao["Home.GrafMeses"] = ddlMesesGrafico.SelectedValue;
        configuracao["Home.GrafQtdResiduo"] = ddlQtdResiduos.SelectedValue;
        configuracao["Apar.CorTopo"] = txtCor.Value;
        string filename = GravarImagem();
        if (filename != string.Empty)
            configuracao["Apar.LogoNomeArq"] = filename;
        else
            configuracao["Apar.LogoNomeArq"] = Configuracao.ValorDe(null, "Apar.LogoNomeArq");
        configuracao["Apar.LogoTop"] = "10";
        configuracao["Apar.LogoLeft"] = "10";
        configuracao.Alterar();
        // Atualiza ambiente
        Application["ConfiguracaoSistema"] = configuracao;
    }

    private string GravarImagem()
    {
        string filename = string.Empty;
        if (fluLogo.HasFile)
        {
            filename = fluLogo.FileName;
            fluLogo.PostedFile.SaveAs(MapPath("~/Images/Logo/" + filename));
        }
        return filename;
    }
    #endregion

    #region Eventos de Ação
    protected void tbdTipoResiduo_Adicionar(string texto, EventArgs e)
    {
        TipoResiduo tipoResiduo = new TipoResiduo();
        tipoResiduo.Descricao = texto;
        tipoResiduo.Inserir();
        CarregarTipoResiduo();
    }
    protected void tbdTipoResiduo_Remover(int Key, EventArgs e)
    {
        TipoResiduo tipoResiduo = new TipoResiduo(Key);
        tipoResiduo.Excluir();
        CarregarTipoResiduo();
    }
    protected void tbdTipoResiduo_Editar(string Descricao, int Key, EventArgs e)
    {
        TipoResiduo tipoResiduo = new TipoResiduo(Key);
        tipoResiduo.Descricao = Descricao;
        tipoResiduo.Alterar();
        CarregarTipoResiduo();
    }

    protected void tbdClasse_Adicionar(string texto, EventArgs e)
    {
        Classe classe = new Classe();
        classe.Descricao = texto;
        classe.Inserir();
        CarregarClasse();
    }
    protected void tbdClasse_Remover(int Key, EventArgs e)
    {
        Classe classe = new Classe(Key);
        classe.Excluir();
        CarregarClasse();
    }
    protected void tbdClasse_Editar(string Descricao, int Key, EventArgs e)
    {
        Classe classe = new Classe(Key);
        classe.Descricao = Descricao;
        classe.Alterar();
        CarregarClasse();
    }
    
    protected void btnGravar_Click(object sender, EventArgs e)
    {
        GravarConfiguracoes();
    }

    #endregion

}
