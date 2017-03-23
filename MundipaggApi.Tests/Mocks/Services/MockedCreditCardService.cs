using GatewayApiClient.DataContracts;
using GatewayApiClient.Utility;
using MundipaggApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
