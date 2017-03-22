using MundipaggApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace MundipaggApi.Controllers
{
    [RoutePrefix("api/transaction/onlinedebt")]
    public class OnlineDebtController : AbstractTransactionController
    {
        private readonly ITransactionService transactionService;

        public OnlineDebtController() : base()
        {
            this.transactionService = new OnlineDebtService();
        }

        public OnlineDebtController(ITransactionService transactionService) : base()
        {
            this.transactionService = transactionService;
        }
    }
}