using GatewayApiClient.DataContracts;
using GatewayApiClient.Utility;
using MundipaggApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MundipaggApi.Daos
{
    public class MockedCreditCardDao: AbstractTransactionDao
    {
        public MockedCreditCardDao() : base() { }

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