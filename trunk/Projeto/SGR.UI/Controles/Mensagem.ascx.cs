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
using SGR.BP.Util;

public partial class Mensagem : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void Mostrar(SGRException exception)
    {
        lblMensagem.Text = exception.Message;
        AlteraImagem(exception);
        Apresentar();
    }

    private void Apresentar()
    {
        mdpModal.PopupControlID = pnlMensagem.ID;
        mdpModal.BackgroundCssClass = "mensagem";
        pnlMensagem.Visible = true;
        mdpModal.Show();
    }

    private void AlteraImagem(SGRException exception)
    {
        if(exception is SGRInformacaoException)
            imgTipo.ImageUrl = "~/Images/Menssagens/informacao.gif"; 
        else if(exception is SGRErroException)
            imgTipo.ImageUrl = "~/Images/Menssagens/erro.gif"; 
        else if(exception is SGRAlertaException)
            imgTipo.ImageUrl = "~/Images/Menssagens/alerta.gif"; 
        else if(exception is SGRConfirmacaoException)
            imgTipo.ImageUrl = "~/Images/Menssagens/confirmacao.gif";

    }
}
