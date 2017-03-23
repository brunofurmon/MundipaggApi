using GatewayApiClient;
using GatewayApiClient.DataContracts;
using GatewayApiClient.DataContracts.EnumTypes;
using GatewayApiClient.EnumTypes;
using GatewayApiClient.Utility;
using MundipaggApi.Configuration;
using MundipaggApi.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Web;


namespace MundipaggApi.Daos
{
    public class CreditCardDao: AbstractTransactionDao
    {
        // Host URI - defined in Web.config
        private static string HOST_URI = AppConfig.GetHostUri();
        // Merchant Key - defined in Web.config
        private static Guid MERCHANT_KEY = AppConfig.GetMerchantKey();

        // Gateway Client
        private readonly GatewayServiceClient serviceClient;

        public CreditCardDao() : base()
        {
            this.serviceClient = new GatewayServiceClient(MERCHANT_KEY, new Uri(HOST_URI));
        }

        public override HttpResponse<ManageSaleResponse> Cancel(Guid orderKey)
        {
            // Cancela as transações de cartão de crédito do pedido.
            HttpResponse<ManageSaleResponse> httpResponse = serviceClient.Sale.Manage(ManageOperationEnum.Cancel, orderKey);

            return httpResponse;
        }

        public override HttpResponse<ManageSaleResponse> Capture(Guid orderKey)
        {
            // Captura as transações de cartão de crédito do pedido.
            HttpResponse<ManageSaleResponse> httpResponse = serviceClient.Sale.Manage(ManageOperationEnum.Capture, orderKey);

            return httpResponse;
        }

        public override HttpResponse<CreateSaleResponse> Create(CreateTransactionForm form)
        {
            // Converts string into one of CreditCardBrandEnum options
            CreditCardBrandEnum card = (CreditCardBrandEnum) Enum.Parse(typeof(CreditCardBrandEnum), form.CreditCardBrand);
            
            // Creates Transaction
            CreditCardTransaction transaction = new CreditCardTransaction()
            {
                AmountInCents = form.AmountInCents,
                CreditCard = new CreditCard()
                {
                    CreditCardBrand = card,
                    CreditCardNumber = form.CreditCardNumber,
                    ExpMonth = form.ExpMonth,
                    ExpYear = form.ExpYear,
                    HolderName = form.HolderName,
                    SecurityCode = form.SecurityCode.ToString()
                },
                InstallmentCount = form.InstallmentCount
            };

            // Cria requisição.
            CreateSaleRequest createSaleRequest = new CreateSaleRequest()
            {
                // Adiciona a transação na requisição.
                CreditCardTransactionCollection = new Collection<CreditCardTransaction>
                (
                    new CreditCardTransaction[] { transaction }
                ),
                Order = new Order()
                {
                    OrderReference = "NumeroDoPedido"
                }
            };

            // Autoriza a transação e recebe a resposta do gateway.
            HttpResponse<CreateSaleResponse> httpResponse = serviceClient.Sale.Create(createSaleRequest);

            return httpResponse;
        }
    }
}