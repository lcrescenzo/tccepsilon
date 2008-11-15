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

public partial class Master_Controls_MenuTopo : System.Web.UI.UserControl
{

    public event OnMenuAcionado MenuAcionado;

    public delegate void OnMenuAcionado(int id);

    public int MenuSelecionado
    {
        get 
        {
            if (Session["MenuSelecionado"] == null)
                return -1;
            return (int)Session["MenuSelecionado"];
        }
        set 
        { 
            Session["MenuSelecionado"] = value; 
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        CarregarMenu();
    }

    public void CarregarMenu()
    {
        List<Recurso> lista = null;
        if (Session["idPerfil"] != null)
        {
            lista = ((Perfil)Cache[Session["idPerfil"].ToString()]).Menu;
        }
        else if(Session["admin"] != null)
        {
            lista = Recurso.ListaPrincipaisRecursos();
        }
        rptMenuTopo.DataSource = lista;
        rptMenuTopo.DataBind();
    }



    protected void item_Click(object sender, EventArgs e)
    {
        string argumento = ((LinkButton)sender).CommandArgument;

        if (((LinkButton)sender).CommandName == "url")
        {
            string url = argumento.Split('|')[0];
            string id = argumento.Split('|')[1];
            Context.Items.Add("id", int.Parse(id));
            Server.Transfer(url);
        }
        else if (((LinkButton)sender).CommandName == "menu")
        {
            if (MenuAcionado != null)
                MenuAcionado(int.Parse(argumento));
            MenuSelecionado = int.Parse(argumento);
        }
    }

    private void CriaItemPagina(LinkButton item, Recurso recurso)
    {
        item.Text = recurso.Nome;
        item.CommandName = "url";
        item.CommandArgument = recurso.IdComponente + "|" + recurso.ID.ToString();
    }

    private void CriaItemMenu(LinkButton item, Recurso recurso)
    {
        item.Text = recurso.Nome;
        item.CommandName = "menu";
        item.CommandArgument = recurso.ID.ToString();
    }

    protected void rptMenuTopo_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            LinkButton lnkMenu = (LinkButton)e.Item.FindControl("lnkMenu");
            lnkMenu.CssClass = "menu";
            Recurso recurso = (Recurso)e.Item.DataItem;
            if (recurso.TipoRecurso == ETipoRecurso.ItemMenu)
            {
                CriaItemMenu(lnkMenu, recurso);
            }
            else
            {
                CriaItemPagina(lnkMenu, recurso);
            }
        }
    }
}
