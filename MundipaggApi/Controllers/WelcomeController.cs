using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace MundipaggApi.Controllers
{
    [RoutePrefix("")]
    public class WelcomeController : ApiController
    {
        [HttpGet]
        [Route("")]
        public HttpResponseMessage Index()
        {
            string pagePath = HttpContext.Current.Server.MapPath("/Static/index.html");
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StringContent(File.ReadAllText(pagePath));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }
    }
}
