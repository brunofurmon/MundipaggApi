using MundipaggApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace MundipaggApi.Controllers
{
    [RoutePrefix("api/transaction/creditcard")]
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
    }
}