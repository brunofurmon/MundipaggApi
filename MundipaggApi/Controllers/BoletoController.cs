using MundipaggApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace MundipaggApi.Controllers
{
    [RoutePrefix("api/transaction/boleto")]
    public class BoletoController : AbstractTransactionController
    {
        private readonly ITransactionService transactionService;

        public BoletoController() : base()
        {
            this.transactionService = new BoletoService();
        }

        public BoletoController(ITransactionService transactionService) : base()
        {
            this.transactionService = transactionService;
        }
    }
}