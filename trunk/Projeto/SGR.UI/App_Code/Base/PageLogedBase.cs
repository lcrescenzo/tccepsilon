using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;


public class PageLogedBase : PageBase
{
	public PageLogedBase()
	{
		
	}

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    private bool ValidateLogin()
    {
        return true;
    }

    private string GetClientUserID()
    {
        return base.Request.Cookies[Constantes.UserLogin.userCookieKey].Value;
    }
}
