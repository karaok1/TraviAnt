using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace TraviAnt
{
    public class HTTP
    {
        public static CookieContainer cookie = new CookieContainer();
        public static WebProxy fiddlerProxy = new WebProxy("127.0.0.1:8888", false);

        public static bool PostRequest(string url, CookieCollection reqcookies, Dictionary<string, string> getParams,
            Dictionary<string, string> postParams, ref CookieCollection respcookies)
        {
            ServicePointManager.CheckCertificateRevocationList = false;
            ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Ssl3 | System.Net.SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            ServicePointManager.ServerCertificateValidationCallback += (senderj, cert, chain, sslPolicyErrors) => true;

            try
            {
                if (getParams != null)
                {
                    url += "?";
                    foreach (var pair in getParams)
                    {
                        url += pair.Key + "=" + pair.Value + "&";
                    }
                }
                url = url.Substring(0, url.Length - 1);

                var req = (HttpWebRequest)WebRequest.Create(url);
                req.CookieContainer = cookie;
                req.Method = "POST";
                req.ContentLength = 0;
                req.ContentType = "application/x-www-form-urlencoded";
                req.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.115 Safari/537.36";
                req.Accept = "*/*";
                req.Timeout = 15 * 1000;
                req.Proxy = fiddlerProxy;

                if (postParams != null)
                {
                    string post = "";
                    //post += "?";
                    foreach (var pair in postParams)
                    {
                        post += pair.Key + "=" + HttpUtility.UrlEncode(pair.Value) + "&";
                    }
                    post = post.Substring(0, post.Length - 1);
                    byte[] buffer = Encoding.ASCII.GetBytes(post);

                    req.ContentLength = buffer.Length;
                    var reqstream = req.GetRequestStream();
                    reqstream.Write(buffer, 0, buffer.Length);
                    reqstream.Close();
                }

                var resp = (HttpWebResponse)req.GetResponse();

                respcookies = resp.Cookies;
                cookie.Add(respcookies);

                var stream = resp.GetResponseStream();

                var reader = new StreamReader(stream);
                Info.ResponseBody = reader.ReadToEnd();

                reader.Close();
                stream.Close();
                resp.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool PostAjaxRequest(string url, string host, CookieCollection reqcookies, Dictionary<string, string> getParams,
            Dictionary<string, string> postParams, ref CookieCollection respcookies)
        {
            try
            {
                if (getParams != null)
                {
                    url += "?";
                    foreach (var pair in getParams)
                    {
                        url += pair.Key + "=" + pair.Value + "&";
                    }
                }
                url = url.Substring(0, url.Length - 1);

                var req = (HttpWebRequest)WebRequest.Create(url);
                req.ProtocolVersion = HttpVersion.Version11;
                req.CookieContainer = cookie;
                req.Method = "POST";
                req.KeepAlive = true;
                req.Host = host;
                req.Referer = "https://" + host + "/build.php";
                req.ContentLength = 0;
                req.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
                req.Accept = "text/javascript, text/html, application/xml, text/xml, */*";
                req.Headers.Add("Accept-Encoding: gzip, deflate");
                req.Headers.Add("X-Request: JSON");
                req.Headers.Add("Cache-Control: no-cache");
                req.Headers.Add("Accept-Language: en-US,en;q=0.7,tr;q=0.3");
                req.Headers.Add("X-Requested-With: XMLHttpRequest");
                req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";
                req.Proxy = fiddlerProxy;

                req.Timeout = 15 * 1000;

                if (postParams != null)
                {
                    string post = "";
                    //post += "?";
                    foreach (var pair in postParams)
                    {
                        post += pair.Key + "=" + pair.Value + "&";
                    }
                    req.KeepAlive = true;
                    post = post.Substring(0, post.Length - 1);
                    byte[] buffer = Encoding.ASCII.GetBytes(post);

                    req.ContentLength = buffer.Length;
                    var reqstream = req.GetRequestStream();
                    reqstream.Write(buffer, 0, buffer.Length);
                    reqstream.Close();
                }

                var resp = (HttpWebResponse)req.GetResponse();

                cookie.Add(resp.Cookies);

                var stream = resp.GetResponseStream();

                var reader = new StreamReader(stream);
                Info.ResponseBody = reader.ReadToEnd();

                reader.Close();
                stream.Close();
                resp.Close();

                if (Info.ResponseBody.Contains("[]"))
                {
                    Info.ResponseBody = Info.ResponseBody.Replace("[]", "null");
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool GetRequest(string url, Dictionary<string, string> getParams, string host, bool keepAlive)
        {
            try
            {
                if (getParams != null)
                {
                    url += "?";
                    foreach (var pair in getParams)
                    {
                        url += pair.Key + "=" + pair.Value + "&";
                    }
                }
                url = url.Substring(0, url.Length - 1);

                var req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "GET";
                req.AllowAutoRedirect = true; // redundant ...
                req.Host = host;
                req.KeepAlive = keepAlive;
                req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";
                req.Timeout = 15 * 1000;
                req.Accept = "text/html, application/xhtml+xml, image/jxr, */*";
                req.CookieContainer = cookie;
                req.Proxy = fiddlerProxy;

                var resp = (HttpWebResponse)req.GetResponse();
                var stream = resp.GetResponseStream();

                cookie.Add(resp.Cookies);
                var reader = new StreamReader(stream);
                Info.ResponseBody = reader.ReadToEnd();

                stream.Close();
                resp.Close();
                return true;
            }
            catch (WebException e)
            {
                if (e.Response != null)
                {
                    using (WebResponse response = e.Response)
                    {
                        HttpWebResponse httpResponse = (HttpWebResponse)response;
                        var responseStream = response.GetResponseStream();
                        using (Stream data = responseStream)
                        {
                            string text = new StreamReader(data).ReadToEnd();
                            Info.ResponseBody = text;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
