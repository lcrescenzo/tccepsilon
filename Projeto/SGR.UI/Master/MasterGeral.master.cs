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

public partial class MasterGeral : System.Web.UI.MasterPage
{
    public Mensagem Menssagem
    {
        get { return this.Mensagem1; }
    }
	

    protected void Page_Load(object sender, EventArgs e)
    {
        MenuTopo1.MenuAcionado += new Master_Controls_MenuTopo.OnMenuAcionado(MenuTopo1_MenuAcionado);
    
        if (MenuTopo1.MenuSelecionado != -1)
        {
            MenuLateral1.CarregarMenu(MenuTopo1.MenuSelecionado);
        }
    }


    void MenuTopo1_MenuAcionado(int id)
    {
        ViewState["idMenu"] = id;
        MenuLateral1.CarregarMenu(id);
    }
}
