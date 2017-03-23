using Microsoft.VisualStudio.TestTools.UnitTesting;
using MundipaggApi.Controllers;
using MundipaggApi.Services;
using MundipaggApi.Tests.Mocks.Services;
using System.Web.Http;
using System.Web.Http.Results;
using MundipaggApi.Tests.Factories;
using MundipaggApi.Dto;


namespace MundipaggApi.Tests.ControllersTests
{
    [TestClass]
    public class CreditCardControllerTests
    {
        public static CreditCardController controller;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            ITransactionService mockedService = new MockedCreditCardService();
            controller = new CreditCardController(mockedService);
        }


        [TestMethod]
        public void ShouldInvalidateInvalidCardBrandType()
        {
            CreateTransactionForm form = ModelFactory.BuildCreateTransactionForm();
            string invalidBrand = "NotVisa";
            form.CreditCardBrand = invalidBrand;

            IHttpActionResult result = controller.Create(form);

            Assert.IsInstanceOfType(result, typeof(InvalidModelStateResult));
        }

        [TestMethod]
        public void ShouldInvalidateOrderIdOnCaptureTransaction()
        {
            // Test for ModelState
            string invalidGuid = "12390123sd";

            IHttpActionResult result = controller.Capture(invalidGuid);

            Assert.IsInstanceOfType(result, typeof(InvalidModelStateResult));
        }

        [TestMethod]
        public void ShouldInvalidateOrderIdOnCancelTransaction()
        {
            // Test for ModelState
            string invalidGuid = "12390123sd";

            IHttpActionResult result = controller.Cancel(invalidGuid);

            Assert.IsInstanceOfType(result, typeof(InvalidModelStateResult));
        }
    }
}
