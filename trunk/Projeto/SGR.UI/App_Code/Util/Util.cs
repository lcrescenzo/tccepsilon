using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using SGR.Web.Controls.Common;

namespace Util
{
    public class User
    {
        public static void Login(HttpResponse response, int userId)
        {
            //byte userIdEncrypted = System.Security.Cryptography.SHA1.Create().ComputeHash(Convert.ToByte(userId));
            //HttpCookie cookie = new HttpCookie(Constantes.UserLogin.userCookieKey,userIdEncrypted.ToString());
            //cookie.Expires = DateTime.Now.AddMinutes(Constantes.UserLogin.userCookieExpire);
            //response.Cookies.Add(cookie);
        }
    }

    public class Telas
    {
        public static void AdicionaItemBranco(DropDownList dropdown)
        {
            dropdown.Items.Insert(0, new System.Web.UI.WebControls.ListItem(string.Empty, string.Empty));
        }
    }
}
