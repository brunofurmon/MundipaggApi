using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MundipaggApi.Services;
using MundipaggApi.Daos;

namespace MundipaggApi.Tests.ServicesTests
{
    [TestClass]
    public class CreditCardServiceTests
    {
        public static AbstractTransactionService service;

        [ClassInitialize]
        public static void Initialize()
        {
            ITransactionDao mockedDao = new MockedCreditCardDao();
            service = new CreditCardService(mockedDao);
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
