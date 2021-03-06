﻿using GatewayApiClient.DataContracts;
using GatewayApiClient.DataContracts.EnumTypes;
using GatewayApiClient.Utility;
using MundipaggApi.Dto;
using MundipaggApi.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Xml;

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
        public override IHttpActionResult Create(CreateTransactionForm form)
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
                return BadRequest(ModelState);
            }

            HttpResponse<CreateSaleResponse> transactionResponse = this.transactionService.Create(form);

            // Bypasses HttpStatusCode to client
            return Content(transactionResponse.HttpStatusCode, transactionResponse.Response);
        }

        [HttpPost]
        [Route("{orderId}/capture")]
        public override IHttpActionResult Capture(string orderId)
        {
            Guid orderIdGuid;
            bool guidIsParseable = Guid.TryParse(orderId, out orderIdGuid);
            if (!guidIsParseable)
            {
                string errorMessage = string.Format(
                    "O Guid\"{0}\" não é válido",
                    orderId);
                ModelState.AddModelError("invalidGuid", errorMessage);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            HttpResponse<ManageSaleResponse> transactionResponse = this.transactionService.Capture(orderIdGuid);

            // Bypasses HttpStatusCode to client
            return Content(transactionResponse.HttpStatusCode, transactionResponse.Response);
        }

        [HttpPost]
        [Route("{orderId}/cancel")]
        public override IHttpActionResult Cancel(string orderId)
        {
            Guid orderIdGuid;
            bool guidIsParseable = Guid.TryParse(orderId, out orderIdGuid);
            if (!guidIsParseable)
            {
                string errorMessage = string.Format(
                    "O Guid\"{0}\" não é válido",
                    orderId);
                ModelState.AddModelError("invalidGuid", errorMessage);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            HttpResponse<ManageSaleResponse> transactionResponse = this.transactionService.Cancel(orderIdGuid);

            // Bypasses HttpStatusCode to client
            return Content(transactionResponse.HttpStatusCode, transactionResponse.Response);
        }
    }
}