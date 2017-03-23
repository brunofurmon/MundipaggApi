using MundipaggApi.Dto;
using System;
using System.Web.Http;


namespace MundipaggApi.Controllers
{
    public interface ITransactionController
    {
        IHttpActionResult Create(CreateTransactionForm form);
        IHttpActionResult Capture(Guid orderId);
        IHttpActionResult Cancel(Guid orderId);
    }
}