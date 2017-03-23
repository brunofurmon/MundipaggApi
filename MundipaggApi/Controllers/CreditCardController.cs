using MundipaggApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace MundipaggApi.Controllers
{
    [RoutePrefix("api/transaction")]
    public class CreditCardController : AbstractTransactionController
    {
        private readonly ITransactionService transactionService;

        public CreditCardController() : base()
        {
            this.transactionService = new CreditCardService();
        }

        public CreditCardController(ITransactionService transactionService) : base()
        {
            this.transactionService = transactionService;
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create()
        {
            return Ok("Create");
        }

        [HttpPost]
        [Route("{orderId}/capture")]
        public IHttpActionResult Capture(string orderId)
        {
            return Ok(string.Format("Capture {0} order", orderId));
        }

        [HttpPost]
        [Route("{orderId}/cancel")]
        public IHttpActionResult Cancel(string orderId)
        {
            return Ok(string.Format("Cancel {0} order", orderId));
        }
    }
}