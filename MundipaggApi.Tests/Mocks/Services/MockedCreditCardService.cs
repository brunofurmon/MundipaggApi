using GatewayApiClient.DataContracts;
using GatewayApiClient.Utility;
using MundipaggApi.Services;
using System;
using MundipaggApi.Dto;


namespace MundipaggApi.Tests.Mocks.Services
{
    public class MockedCreditCardService : AbstractTransactionService
    {
        public override HttpResponse<ManageSaleResponse> Cancel(Guid orkerKey)
        {
            throw new NotImplementedException();
        }

        public override HttpResponse<ManageSaleResponse> Capture(Guid orderKey)
        {
            throw new NotImplementedException();
        }

        public override HttpResponse<CreateSaleResponse> Create(CreateTransactionForm form)
        {
            throw new NotImplementedException();
        }
    }
}
