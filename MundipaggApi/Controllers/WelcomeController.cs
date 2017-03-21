using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace MundipaggApi.Controllers
{
    [RoutePrefix("api/welcome")]
    public class WelcomeController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult Index()
        {
            string welcomeString = string.Format("Bem vindo a API de testes de Bruno Furtado. A data/hora local é {0}", DateTime.Now.ToLocalTime());
            return Ok(welcomeString);
        }
    }
}
