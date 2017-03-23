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

        public override void Cancel(Guid orderKey)
        {
            // Cancela as transações de cartão de crédito do pedido.
            HttpResponse<ManageSaleResponse> httpResponse = serviceClient.Sale.Manage(ManageOperationEnum.Cancel, orderKey);

            if (httpResponse.HttpStatusCode == HttpStatusCode.OK
                && httpResponse.Response.CreditCardTransactionResultCollection.Any()
                && httpResponse.Response.CreditCardTransactionResultCollection.All(p => p.Success == true))
            {
                Console.WriteLine("Transações canceladas.");
            }
        }

        public override void Capture(Guid orderKey)
        {
            // Captura as transações de cartão de crédito do pedido.
            HttpResponse<ManageSaleResponse> httpResponse = serviceClient.Sale.Manage(ManageOperationEnum.Capture, orderKey);

            if (httpResponse.HttpStatusCode == HttpStatusCode.OK
                && httpResponse.Response.CreditCardTransactionResultCollection.Any()
                && httpResponse.Response.CreditCardTransactionResultCollection.All(p => p.Success == true))
            {
                Console.WriteLine("Transações capturadas.");
            }
        }

        public override void Create(CreateTransactionForm form)
        {
            // Converts string into one of CreditCardBrandEnum options

            
            // Creates Transaction
            CreditCardTransaction transaction = new CreditCardTransaction()
            {
                AmountInCents = form.AmountInCents,
                CreditCard = new CreditCard()
                {
                    CreditCardBrand = CreditCardBrandEnum.Visa,
                    CreditCardNumber = "4111111111111111",
                    ExpMonth = 10,
                    ExpYear = 22,
                    HolderName = "LUKE SKYWALKER",
                    SecurityCode = "123"
                },
                InstallmentCount = 1
            };

            // Cria requisição.
            CreateSaleRequest createSaleRequest = new CreateSaleRequest()
            {
                // Adiciona a transação na requisição.
                CreditCardTransactionCollection = new Collection<CreditCardTransaction>(new CreditCardTransaction[] { transaction }),
                Order = new Order()
                {
                    OrderReference = "NumeroDoPedido"
                }
            };

            // Autoriza a transação e recebe a resposta do gateway.
            HttpResponse<CreateSaleResponse> httpResponse = serviceClient.Sale.Create(createSaleRequest);

            Console.WriteLine("Código retorno: {0}", httpResponse.HttpStatusCode);
            Console.WriteLine("Chave do pedido: {0}", httpResponse.Response.OrderResult.OrderKey);
            if (httpResponse.Response.CreditCardTransactionResultCollection != null)
            {
                Console.WriteLine("Status transação: {0}", httpResponse.Response.CreditCardTransactionResultCollection.FirstOrDefault().CreditCardTransactionStatus);
            }
        }
    }
}