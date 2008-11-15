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

public partial class Controles_Grafico : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["meses"] != null)
            GraficoPizza1.Meses = int.Parse(Request.QueryString["meses"]);

        if (Request.QueryString["qtd"] != null)
            GraficoPizza1.Quantidade = int.Parse(Request.QueryString["qtd"]);
        
    }
}
