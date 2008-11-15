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

public enum RetornoConfirm
{
    Sim,
    Nao
}
public partial class Confirm : System.Web.UI.UserControl
{


    public delegate void OnAcao(RetornoConfirm retorno);
    public event OnAcao Acao;


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Mostrar(string pergunta)
    {
        lblPergunta.Text = pergunta;
        Apresentar();
    }

    private void Apresentar()
    {
        mdpConfirm.PopupControlID = pnlConfirm.ID;
        mdpConfirm.BackgroundCssClass = "mensagem";
        pnlConfirm.Visible = true;
        mdpConfirm.Show();
    }

    protected void btnSim_Click(object sender, EventArgs e)
    {
        if (Acao != null)
        {
            pnlConfirm.Visible = false;
            mdpConfirm.Hide();
            Acao(RetornoConfirm.Sim);
        }
    }
    protected void btnNao_Click(object sender, EventArgs e)
    {
        if (Acao != null)
        {
            pnlConfirm.Visible = false;
            mdpConfirm.Hide();
            Acao(RetornoConfirm.Nao);
        }
    }
}
