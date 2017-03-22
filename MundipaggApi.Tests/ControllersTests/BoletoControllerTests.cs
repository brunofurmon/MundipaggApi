using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MundipaggApi.Controllers;
using MundipaggApi.Services;
using MundipaggApi.Tests.Mocks.Services;

namespace MundipaggApi.Tests.ControllersTests
{
    [TestClass]
    public class BoletoControllerTests
    {
        public static AbstractTransactionController controller;

        [ClassInitialize]
        public static void Initialize()
        {
            ITransactionService mockedService = new MockedBoletoService();
            controller = new BoletoController(mockedService);
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

        [TestMethod]
        public void ShouldCancelTransaction()
        {
            Assert.Fail();
        }
    }
}
