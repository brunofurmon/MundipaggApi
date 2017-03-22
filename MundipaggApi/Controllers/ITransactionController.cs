using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace MundipaggApi.Controllers
{
    public interface ITransactionController
    {
        IHttpActionResult Create();
        IHttpActionResult Capture();
        IHttpActionResult Cancel();
    }
}