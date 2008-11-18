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
using System.Collections.Generic;

public partial class Master_Controls_MenuLateral : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void CarregarMenu(int idRecursoPai)
    {
        List<Recurso> lista = null;
        if(Session["idPerfil"] != null)
        {
            lista = ((Perfil)Cache[Session["idPerfil"].ToString()]).RecursoPorPerfil(idRecursoPai);
        }
        else if(Session["admin"] != null)
        {
            Recurso recurso = new Recurso(idRecursoPai);
            lista = recurso.Filhos;
        }

        rptMenuLateral.DataSource = lista;
        rptMenuLateral.DataBind();
        
    }

    protected void item_Click(object sender, EventArgs e)
    {
        string argumento = ((LinkButton)sender).CommandArgument;
        string url = argumento.Split('|')[0];
        string id = argumento.Split('|')[1];
        Session["id"] = int.Parse(id);
        Response.Redirect(url);
    }

    protected void rptMenuLateral_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            LinkButton lnkMenu = (LinkButton)e.Item.FindControl("lnkMenu");
            Recurso recurso = (Recurso)e.Item.DataItem;
            lnkMenu.Text = recurso.Nome;
            lnkMenu.CommandArgument = recurso.IdComponente + "|" + recurso.ID.ToString();
            //lnkMenu.CssClass = "submenu";
        }
        
            
    }
}
