using GatewayApiClient.DataContracts;
using GatewayApiClient.Utility;
using MundipaggApi.Consumers;
using MundipaggApi.Dto;
using System;


namespace MundipaggApi.Services
{
    public class CreditCardService : AbstractTransactionService
    {
        private readonly ITransactionConsumer consumer;

        public CreditCardService() : base()
        {
            this.consumer = new CreditCardConsumer();
        }

        public CreditCardService(
            ITransactionConsumer creditCardTransactionDao
            ) : base()
        {
            this.consumer = creditCardTransactionDao;
        }

        public override HttpResponse<CreateSaleResponse> Create(CreateTransactionForm form)
        {
            return this.consumer.Create(form);
        }

        public override HttpResponse<ManageSaleResponse> Capture(Guid orderKey)
        {
            return this.consumer.Capture(orderKey);
        }

        public override HttpResponse<ManageSaleResponse> Cancel(Guid orkerKey)
        {
            return this.consumer.Cancel(orkerKey);
        }
    }
}