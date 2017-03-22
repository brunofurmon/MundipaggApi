using System;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GatewayApiClient.DataContracts.EnumTypes;
using GatewayApiClient.DataContracts;
using GatewayApiClient;
using System.Linq;
using GatewayApiClient.EnumTypes;
using System.Net;


namespace MundipaggApi.Tests.MundipaggTests
{
    [TestClass]
    public class CreditCardTransactionTests
    {
        [TestMethod]
        public void ShouldCreateTransaction()
        {
            // Cria a transação.
            var transaction = new CreditCardTransaction()
            {
                AmountInCents = 10000,
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
            var createSaleRequest = new CreateSaleRequest()
            {
                // Adiciona a transação na requisição.
                CreditCardTransactionCollection = new Collection<CreditCardTransaction>(
                    new CreditCardTransaction[] { transaction }
                ),
                Order = new Order()
                {
                    OrderReference = "NumeroDoPedido"
                }
            };

            // Coloque a sua MerchantKey aqui.
            Guid merchantKey = Guid.Parse("85328786-8BA6-420F-9948-5352F5A183EB");

            // Cria o client que enviará a transação.
            var serviceClient = new GatewayServiceClient(
                merchantKey, 
                new Uri("https://sandbox.mundipaggone.com")
            );

            // Autoriza a transação e recebe a resposta do gateway.
            var httpResponse = serviceClient.Sale.Create(createSaleRequest);

            Console.WriteLine("Código retorno: {0}", httpResponse.HttpStatusCode);
            Console.WriteLine("Chave do pedido: {0}", httpResponse.Response.OrderResult.OrderKey);
            if (httpResponse.Response.CreditCardTransactionResultCollection != null)
            {
                Console.WriteLine("Status transação: {0}",
                    httpResponse.Response.CreditCardTransactionResultCollection
                    .FirstOrDefault()
                    .CreditCardTransactionStatus);
            }
        }

        [TestMethod]
        public void ShouldCaptureTransaction()
        {
            Guid merchantKey = Guid.Parse("85328786-8BA6-420F-9948-5352F5A183EB");
            // Chave do pedido
            Guid orderKey = Guid.Parse("219d7581-78e2-4aa9-b708-b7c585780bfc");

            // Cria o cliente para capturar as transações.
            IGatewayServiceClient client = new GatewayServiceClient(
                merchantKey, 
                new Uri("https://sandbox.mundipaggone.com")
            );

            // Captura as transações de cartão de crédito do pedido.
            var httpResponse = client.Sale.Manage(ManageOperationEnum.Capture, orderKey);

            if (httpResponse.HttpStatusCode == HttpStatusCode.OK
                && httpResponse.Response.CreditCardTransactionResultCollection.Any()
                && httpResponse.Response.CreditCardTransactionResultCollection.All(p => p.Success == true))
            {
                Console.WriteLine("Transações capturadas.");
            }
        }

        [TestMethod]
        public void ShouldCancelTransaction()
        {
            Guid merchantKey = Guid.Parse("85328786-8BA6-420F-9948-5352F5A183EB");
            // Chave do pedido
            Guid orderKey = Guid.Parse("219d7581-78e2-4aa9-b708-b7c585780bfc");

            // Cria o cliente para cancelar as transações.
            IGatewayServiceClient client = new GatewayServiceClient(
                merchantKey, 
                new Uri("https://sandbox.mundipaggone.com")
            );

            // Cancela as transações de cartão de crédito do pedido.
            var httpResponse = client.Sale.Manage(ManageOperationEnum.Cancel, orderKey);

            if (httpResponse.HttpStatusCode == HttpStatusCode.OK
                && httpResponse.Response.CreditCardTransactionResultCollection.Any()
                && httpResponse.Response.CreditCardTransactionResultCollection.All(p => p.Success == true)) {
                Console.WriteLine("Transações canceladas.");
            }
        }
    }
}
