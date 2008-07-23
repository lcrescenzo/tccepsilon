using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;


namespace Util
{
    internal class User
    {
        public static void Login(HttpResponse response, int userId)
        {
            //byte userIdEncrypted = System.Security.Cryptography.SHA1.Create().ComputeHash(Convert.ToByte(userId));
            //HttpCookie cookie = new HttpCookie(Constantes.UserLogin.userCookieKey,userIdEncrypted.ToString());
            //cookie.Expires = DateTime.Now.AddMinutes(Constantes.UserLogin.userCookieExpire);
            //response.Cookies.Add(cookie);
        }
    }
}
