using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using SGR.Web.Controls.Common;
using System.Security.Cryptography;
using System.Text;
using System.Globalization;

namespace Util
{
    public class User
    {
        public static string GeraMD5(string texto)
        {
            //Declarations
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(texto);
            encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' string
            return BitConverter.ToString(encodedBytes);
        }

        public static HttpCookie CriarCookie(string chave, string valor)
        {
            HttpCookie cookie = new HttpCookie(chave, valor);
            cookie.Expires.AddMinutes(Constantes.UserLogin.userCookieExpire);
            return cookie;
        }
    }

    public class Telas
    {
        public static void AdicionaItemBranco(DropDownList dropdown)
        {
            dropdown.Items.Insert(0, new System.Web.UI.WebControls.ListItem(string.Empty, string.Empty));
        }

    }

    public class UrlUtil
    {
        private static string ResolveUrl(string originalUrl)
        {
            if (originalUrl == null)
                return null;

            if (originalUrl.IndexOf("://") != -1)
                return originalUrl;

            if (originalUrl.StartsWith("~"))
            {
                string newUrl = "";
                if (HttpContext.Current != null)
                    newUrl = HttpContext.Current.Request.ApplicationPath + originalUrl.Substring(1).Replace("//", "/");
                else

                    throw new ArgumentException("Invalid URL: Relative URL not allowed.");

                return newUrl;
            }
            return originalUrl;
        }

        private static string ResolveServerUrl(string serverUrl, bool forceHttps)
        {
            if (serverUrl.IndexOf("://") > -1)
                return serverUrl;


            string newUrl = ResolveUrl(serverUrl);
            Uri originalUri = HttpContext.Current.Request.Url;
            newUrl = (forceHttps ? "https" : originalUri.Scheme) + "://" + originalUri.Authority + newUrl;
            return newUrl;
        }

        public static string ResolveServerUrl(string serverUrl)
        {
            return ResolveServerUrl(serverUrl, false);
        }
    }

    public class Formatacao
    {
        private static CultureInfo _culture = null;


        private static CultureInfo Culture
        {
            get
            {
                if (_culture == null)
                    _culture = new CultureInfo(ConfigurationManager.AppSettings["cultura"]);

                return _culture;
            }
        }

        public static NumberFormatInfo Numero
        {
            get
            {
                return Culture.NumberFormat;
            }
        }

        public static DateTimeFormatInfo Data
        {
            get
            {
                return Culture.DateTimeFormat;
            }
        }

    }
}
