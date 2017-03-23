using GatewayApiClient.DataContracts;
using GatewayApiClient.DataContracts.EnumTypes;
using GatewayApiClient.Utility;
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
            // Validation Sample
            List<string> possibleCardBrands = Enum.GetNames(typeof(CreditCardBrandEnum)).ToList();
            if (!possibleCardBrands.Contains(form.CreditCardBrand))
            {
                string errorMessage = string.Format(
                    "O Bandeira de Cartão \"{0}\" não existe. Bandeiras possíveis: {1}",
                    form.CreditCardBrand,
                    string.Join(", ", possibleCardBrands));
                ModelState.AddModelError("invalidCreditCardBrand", errorMessage);
            }
            // Future: More Validation on the Model

            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }

            HttpResponse<CreateSaleResponse> transactionResponse = this.transactionService.Create(form);

            // Bypasses HttpStatusCode to client
            return Content(transactionResponse.HttpStatusCode, transactionResponse.Response);
        }

        [HttpPost]
        [Route("{orderId}/capture")]
        public IHttpActionResult Capture(Guid orderId)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }

            HttpResponse<ManageSaleResponse> transactionResponse = this.transactionService.Capture(orderId);

            // Bypasses HttpStatusCode to client
            return Content(transactionResponse.HttpStatusCode, transactionResponse.Response);
        }

        [HttpPost]
        [Route("{orderId}/cancel")]
        public IHttpActionResult Cancel(Guid orderId)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }

            HttpResponse<ManageSaleResponse> transactionResponse = this.transactionService.Cancel(orderId);

            // Bypasses HttpStatusCode to client
            return Content(transactionResponse.HttpStatusCode, transactionResponse.Response);
        }
    }
}