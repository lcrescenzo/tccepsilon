using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;

public class PageBase : System.Web.UI.Page
{
	public PageBase()
	{
	}

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
    }

}
