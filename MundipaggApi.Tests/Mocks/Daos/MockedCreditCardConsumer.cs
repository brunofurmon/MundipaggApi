using GatewayApiClient.DataContracts;
using GatewayApiClient.Utility;
using MundipaggApi.Consumers;
using MundipaggApi.Dto;
using System;


namespace MundipaggApi.Daos
{
    public class MockedCreditCardConsumer : AbstractMundipaggConsumer
    {
        public MockedCreditCardConsumer() : base() { }

        public override HttpResponse<ManageSaleResponse> Cancel(Guid orkerKey)
        {
            throw new NotImplementedException();
        }

        public override HttpResponse<ManageSaleResponse> Capture(Guid orkerKey)
        {
            throw new NotImplementedException();
        }

        public override HttpResponse<CreateSaleResponse> Create(CreateTransactionForm form)
        {
            throw new NotImplementedException();
        }
    }
}