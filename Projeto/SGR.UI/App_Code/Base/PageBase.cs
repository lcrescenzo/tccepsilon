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
        //string actualFile = Server.MapPath(AppRelativeVirtualPath);
        //string redirectFile = Server.MapPath(Context.Request.FilePath);
        //string baseSiteVirtualPath = HttpRuntime.AppDomainAppVirtualPath;

        //if (actualFile != redirectFile)
        //{
        //    System.Text.StringBuilder sbJS = new System.Text.StringBuilder();
        //    string actionUrl = string.Format("'{0}'", baseSiteVirtualPath + AppRelativeVirtualPath.Replace("~", String.Empty));
        //    sbJS.Append("Sys.Application.add_load(function(){");
        //    sbJS.Append(" var form = Sys.WebForms.PageRequestManager.getInstance()._form;");
        //    sbJS.Append(" form._initialAction = " + actionUrl + ";");
        //    sbJS.Append(" form.action = " + actionUrl + ";");
        //    sbJS.Append("});");
        //    ClientScript.RegisterStartupScript(this.GetType(), "CorrecaoAjax", sbJS.ToString(), true);
        //}   

        base.OnLoad(e);
    }

}
