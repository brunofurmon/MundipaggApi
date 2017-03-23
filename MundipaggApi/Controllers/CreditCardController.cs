using GatewayApiClient.DataContracts.EnumTypes;
using MundipaggApi.Dto;
using MundipaggApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

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
        public IHttpActionResult Create(CreateTransactionForm form)
        {
            // Goes to Validation from here
            List<string> possibleCardBrands = Enum.GetNames(typeof(CreditCardBrandEnum)).ToList();
            if (!possibleCardBrands.Contains(form.CreditCardBrand))
            {
                string errorMessage = string.Format(
                    "O cartão do tipo \"{0}\" não existe. Possíveis: {1}",
                    form.CreditCardBrand,
                    string.Join(", ", possibleCardBrands));
                ModelState.AddModelError("bandeiraInvalida", errorMessage);
            }
            // Validate more fields here

            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }

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