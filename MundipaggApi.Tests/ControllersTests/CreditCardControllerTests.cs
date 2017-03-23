using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MundipaggApi.Controllers;
using MundipaggApi.Services;
using MundipaggApi.Tests.Mocks.Services;
using GatewayApiClient.Utility;
using System.Net.Http;
using System.Web.Http;
using System.Net;

namespace MundipaggApi.Tests.ControllersTests
{
    [TestClass]
    public class CreditCardControllerTests
    {
        public static CreditCardController controller;

        [ClassInitialize]
        public static void Initialize()
        {
            ITransactionService mockedService = new MockedCreditCardService();
            controller = new CreditCardController(mockedService);
        }

        [TestMethod]
        public void ShouldCreateTransaction()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldCaptureTransaction()
        {
            Assert.Fail();
        }
    }
}
