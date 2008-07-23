using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;

namespace Constantes
{
    internal class UserLogin
    {
        public readonly static string userCookieKey = "userCookieID";
        public readonly static double userCookieExpire = 20;
    }
}
