using System;
using System.Web.Http;
using MundipaggApi.Dto;


namespace MundipaggApi.Controllers
{
    public abstract class AbstractTransactionController : ApiController, ITransactionController
    {
        public AbstractTransactionController() : base() { }

        public abstract IHttpActionResult Cancel(string orderId);
        public abstract IHttpActionResult Capture(string orderId);
        public abstract IHttpActionResult Create(CreateTransactionForm form);
    }
}