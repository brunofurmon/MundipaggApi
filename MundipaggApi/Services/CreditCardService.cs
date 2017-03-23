using GatewayApiClient.DataContracts;
using GatewayApiClient.Utility;
using MundipaggApi.Daos;
using MundipaggApi.Dto;
using System;


namespace MundipaggApi.Services
{
    public class CreditCardService : AbstractTransactionService
    {
        private readonly ITransactionDao dao;

        public CreditCardService() : base()
        {
            this.dao = new CreditCardDao();
        }

        public CreditCardService(
            ITransactionDao creditCardTransactionDao
            ) : base()
        {
            this.dao = creditCardTransactionDao;
        }

        public override HttpResponse<CreateSaleResponse> Create(CreateTransactionForm form)
        {
            return this.dao.Create(form);
        }

        public override HttpResponse<ManageSaleResponse> Capture(Guid orderKey)
        {
            return this.dao.Capture(orderKey);
        }

        public override HttpResponse<ManageSaleResponse> Cancel(Guid orkerKey)
        {
            return this.dao.Cancel(orkerKey);
        }
    }
}