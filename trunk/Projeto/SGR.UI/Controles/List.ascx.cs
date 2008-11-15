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
using SGR.BP.Bases;
using System.Collections.Generic;

public partial class Controles_List : System.Web.UI.UserControl
{
    [Serializable]
    class Item
    {
        public Item(string texto, int id)
        {
            this._id = id;
            this._texto = texto;
        }

        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _texto;

        public string Texto
        {
            get { return _texto; }
            set { _texto = value; }
        }

    }

    public event Delete OnDelete;

    public delegate void Delete(string texto, int id); 

    List<Item> DataSource
    {
        get 
        {
            if (ViewState["dataSource"] == null)
                ViewState["dataSource"] = new List<Item>();

            return (List<Item>)ViewState["dataSource"];
        }
        set
        {
            ViewState["dataSource"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Adicionar(string texto, int id) 
    {
        List<Item> list = DataSource;
        list.Add(new Item(texto, id));
        dtlItems.DataSource = list;
        dtlItems.DataBind();
        DataSource = list;
    }

    protected void imbExcluir_Command(object sender, CommandEventArgs e)
    {
        Item removido = null;
        List<Item> list = DataSource;
        int id = int.Parse(e.CommandArgument.ToString());
        list.RemoveAll(delegate(Item item) 
            {
                if (item.ID == id)
                    removido = item;
                return (item.ID == id);
            } );
        dtlItems.DataSource = list;
        dtlItems.DataBind();
        DataSource = list;
        if (OnDelete != null)
            OnDelete(removido.Texto, removido.ID);
    }
    
    protected void dtlItems_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Item item = (Item)e.Item.DataItem;
            SGR.Web.Controls.Common.Label lblTexto = (SGR.Web.Controls.Common.Label)e.Item.FindControl("lblTexto");
            SGR.Web.Controls.Common.ImageButton imbExcluir = (SGR.Web.Controls.Common.ImageButton)e.Item.FindControl("imbExcluir");
            lblTexto.Text = item.Texto;
            imbExcluir.CommandArgument = item.ID.ToString();
        }
    }

    public List<int> IDs
    {
        get
        {
            List<int> list = new List<int>();
            foreach(DataListItem item in dtlItems.Items)
            {
                SGR.Web.Controls.Common.ImageButton imbExcluir = (SGR.Web.Controls.Common.ImageButton)item.FindControl("imbExcluir");
                list.Add(int.Parse(imbExcluir.CommandArgument));
            }

            return list;
        }
    }
}
