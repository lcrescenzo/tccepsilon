using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using SGR.Web.Controls.Common;
using SGR.BP.Objeto;
using SGR.BP.Objeto.Home.Entidade;
using System.Drawing;
using SGR.BP.Objeto.Home;

public partial class Telas_Home : PageLogedBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Carregar();
    
    }

    private void Carregar()
    {
        if (!IsPostBack)
        {
            CarregarMovimentacao();
            CarregarCadri();
            AjustaGrafico();
            CarregarGrafico();
        }
    }

    private void AjustaGrafico()
    {
        ddlQuantidade.SelectedValue = base.ConfiguracaoUsuario["Home.GrafQtdResiduo"];
        ddlMeses.SelectedValue = base.ConfiguracaoUsuario["Home.GrafMeses"];
    }

    private void CarregarGrafico()
    {
        imgGrafico.ImageUrl = "~/Controles/Grafico.aspx?meses=" + ddlMeses.SelectedValue + "&qtd=" + ddlQuantidade.SelectedValue;
    }

    private void CarregarCadri()
    {
        rptCadri.DataSource = Home.ListaCriticosValidos(int.Parse(base.ConfiguracaoUsuario["Home.CADRI"]));// TODO: Carregar pelo Parametro;
        rptCadri.DataBind();
    }

    private void CarregarMovimentacao()
    {
      
               
                    
        rptMovimentacao.DataSource = Home.MovimentacoesCriticas(double.Parse(base.ConfiguracaoUsuario["Home.Movimentacao"],Util.Formatacao.Numero)); 
        rptMovimentacao.DataBind();
    }
  
    protected void rptMovimentacao_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == System.Web.UI.WebControls.ListItemType.AlternatingItem || e.Item.ItemType == System.Web.UI.WebControls.ListItemType.Item)
        {
            MovimentacaoCritica movimentacao = (MovimentacaoCritica)e.Item.DataItem;
            Panel pnlMovimentacao = (Panel)e.Item.FindControl("pnlMovimentacao");
            Label lblCadri = (Label)e.Item.FindControl("lblCadri");
            Label lblResiduo = (Label)e.Item.FindControl("lblResiduo");
            Label lblPermitido = (Label)e.Item.FindControl("lblPermitido");
            Label lblUtilizados = (Label)e.Item.FindControl("lblUtilizados");
            
            lblPermitido.Text = movimentacao.Permitido.ToString(Util.Formatacao.Numero);
            lblUtilizados.Text = movimentacao.Transportado.ToString(Util.Formatacao.Numero);
            lblCadri.Text = movimentacao.CADRI.Numero.ToString();
            lblResiduo.Text = movimentacao.Residuo.Nome;

            switch (movimentacao.Criticidade)
            {
                case ECriticidade.Alta: pnlMovimentacao.BackColor = Color.FromName("#FFAAAA"); break;
                case ECriticidade.Media: pnlMovimentacao.BackColor = Color.FromName("#EEEE77"); break;
            }
            //TODO: trocar para os parametros 

        }
    }
    protected void rptCadri_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == System.Web.UI.WebControls.ListItemType.AlternatingItem || e.Item.ItemType == System.Web.UI.WebControls.ListItemType.Item)
        {
            CADRICritico cadri = (CADRICritico)e.Item.DataItem;
            Panel pnlMovimentacao = (Panel)e.Item.FindControl("pnlMovimentacao");
            Label lblCadri = (Label)e.Item.FindControl("lblCadri");
            Label lblData = (Label)e.Item.FindControl("lblData");

            lblCadri.Text = cadri.Numero.ToString();
            lblData.Text = cadri.Validade.ToString(Util.Formatacao.Data.ShortDatePattern);


            switch (cadri.Criticidade)
            {
                case ECriticidade.Alta: pnlMovimentacao.BackColor = Color.Red; break;
                case ECriticidade.Media: pnlMovimentacao.BackColor = Color.Yellow; break;
            }
            //TODO: trocar para os parametros 

        }

    }
    protected void btnGerarGrafico_Click(object sender, EventArgs e)
    {
        CarregarGrafico();
    }
}
