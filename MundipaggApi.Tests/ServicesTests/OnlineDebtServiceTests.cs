using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MundipaggApi.Services;
using MundipaggApi.Daos;

namespace MundipaggApi.Tests.ServicesTests
{
    [TestClass]
    public class OnlineDebtServiceTests
    {
        public static AbstractTransactionService service;

        [ClassInitialize]
        public static void Initialize()
        {
            ITransactionDao mockedDao = new MockedOnlineDebtDao();
            service = new OnlineDebtService(mockedDao);
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
