using Newtonsoft.Json;
using RockCandy.Web.Framework.Utilities.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Finary.Core.Utils
{
    public class CookieUtils
    {
        public void AddCookie(string name, string value, string applicationName, string securityKey, int mins = 10, HttpContextBase httpContext = null)
        {
            HttpCookie ViewContent = new HttpCookie(MD5Encryption.Encrypt(string.Format("{0}-{1}", applicationName, name), true, securityKey));
            ViewContent.Value = MD5Encryption.Encrypt(value, true,securityKey);
            ViewContent.Expires = DateTime.Now.AddMinutes(mins);
            if (httpContext == null)
            {
                HttpContext.Current.Response.SetCookie(ViewContent);
            }
            else
            {
                httpContext.Response.SetCookie(ViewContent);
            }

        }

        public void RemoveCookie(string name, string applicationName, string securityKey, HttpContextBase httpContext = null)
        {

            HttpCookie ViewContent = new HttpCookie(MD5Encryption.Decrypt(string.Format("{0}-{1}", applicationName, name), true, securityKey));
            ViewContent.Value = "";
            ViewContent.Expires = DateTime.Now.AddMinutes(-1);
            if (httpContext == null)
            {
                HttpContext.Current.Response.SetCookie(ViewContent);
            }
            else
            {
                httpContext.Response.SetCookie(ViewContent);
            }

        }

        public T GetCookieValue<T>(string name, string applicationName, string securityKey, HttpRequestBase request, bool JsonDeserialize = false)
        {
            try
            {
                if (JsonDeserialize)
                {
                    return JsonConvert.DeserializeObject<T>(MD5Encryption.Decrypt(request.Cookies[MD5Encryption.Encrypt(string.Format("{0}-{1}", applicationName, name), true, securityKey)].Value.ToString(), true, securityKey));
                }
                else
                {
                    return TConverter.ChangeType<T>(MD5Encryption.Decrypt(request.Cookies[MD5Encryption.Encrypt(string.Format("{0}-{1}", applicationName, name), true, securityKey)].Value.ToString(), true, securityKey));
                }

            }
            catch
            {
                if (typeof(T).IsValueType || typeof(T) == typeof(string))
                {
                    return default(T);
                }
                else
                {
                    return (T)Activator.CreateInstance(typeof(T));
                }
            }

        }
    }
}
