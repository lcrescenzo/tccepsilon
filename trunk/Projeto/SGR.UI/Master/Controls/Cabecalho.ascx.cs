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

public partial class Master_Controls_Cabecalho : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            ConfiguraCabecalho();
        }
    }

    private void ConfiguraCabecalho()
    {
        Configuracao configuracao = ((PageLogedBase)Page).ConfiguracaoSistema;
        pnlCabecalho.Style[HtmlTextWriterStyle.BackgroundColor] = configuracao["Apar.CorTopo"];
        imgLogo.ImageUrl = "~/Images/Logo/" + configuracao["Apar.LogoNomeArq"];
        imgLogo.Style[HtmlTextWriterStyle.Top] = configuracao["Apar.LogoTop"] + "px";
        imgLogo.Style[HtmlTextWriterStyle.Left] = configuracao["Apar.LogoLeft"] + "px";
    }
}
