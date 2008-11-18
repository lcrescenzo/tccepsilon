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

public partial class MenssagemOK : System.Web.UI.UserControl
{


    public delegate void OnOK();
    public event OnOK OK;


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

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (OK != null)
        {
            pnlConfirm.Visible = false;
            mdpConfirm.Hide();
            OK();
        }
    }
}
