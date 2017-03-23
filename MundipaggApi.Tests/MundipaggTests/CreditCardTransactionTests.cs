using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GatewayApiClient.DataContracts;
using GatewayApiClient;
using GatewayApiClient.EnumTypes;
using System.Net;
using MundipaggApi.Tests.Factories;


namespace MundipaggApi.Tests.MundipaggTests
{
    [TestClass]
    public class CreditCardTransactionTests
    {
        private static Guid merchantKey = Guid.Parse("85328786-8BA6-420F-9948-5352F5A183EB");
        private static string hostUri = @"https://sandbox.mundipaggone.com";
        private static GatewayServiceClient serviceClient;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            serviceClient = new GatewayServiceClient(
                merchantKey,
                new Uri(hostUri)
            );
        }

        [TestMethod]
        public void ShouldCreateExactlyOneTransaction()
        {
            CreateSaleRequest createSaleRequest = SaleRequestFactory.GenerateSaleRequest();

            var httpResponse = serviceClient.Sale.Create(createSaleRequest);

            Assert.AreEqual(HttpStatusCode.Created, httpResponse.HttpStatusCode);
            Assert.IsTrue(httpResponse.Response.CreditCardTransactionResultCollection.Count == 1);
        }

        [TestMethod]
        public void ShouldCaptureCreatedTransaction()
        {
            CreateSaleRequest createSaleRequest = SaleRequestFactory.GenerateSaleRequest();
            var creationResponse = serviceClient.Sale.Create(createSaleRequest);
            Guid orderKey = creationResponse.Response.OrderResult.OrderKey;

            var httpResponse = serviceClient.Sale.Manage(ManageOperationEnum.Capture, orderKey);

            Assert.AreEqual(HttpStatusCode.OK, httpResponse.HttpStatusCode);
            Assert.IsTrue(httpResponse.Response.CreditCardTransactionResultCollection.Count == 1);
        }

        [TestMethod]
        public void ShouldCancelCreatedTransaction()
        {
            CreateSaleRequest createSaleRequest = SaleRequestFactory.GenerateSaleRequest();
            var creationResponse = serviceClient.Sale.Create(createSaleRequest);
            Guid orderKey = creationResponse.Response.OrderResult.OrderKey;

            var httpResponse = serviceClient.Sale.Manage(ManageOperationEnum.Cancel, orderKey);

            Assert.AreEqual(HttpStatusCode.OK, httpResponse.HttpStatusCode);
            Assert.IsTrue(httpResponse.Response.CreditCardTransactionResultCollection.Count == 1);
        }
    }
}
