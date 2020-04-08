using CefSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraviAnt
{
    public static class HttpRequest
    {
        public static void Navigate(this IWebBrowser browser, string url, byte[] postDataBytes, string contentType)
        {
            IFrame frame = browser.GetMainFrame();
            IRequest request = frame.CreateRequest();

            request.Url = url;
            request.Method = "POST";

            request.InitializePostData();
            var element = request.PostData.CreatePostDataElement();
            element.Bytes = postDataBytes;
            request.PostData.AddElement(element);

            NameValueCollection headers = new NameValueCollection();
            headers.Add("Content-Type", contentType);
            request.Headers = headers;

            frame.LoadRequest(request);
        }
    }
}
