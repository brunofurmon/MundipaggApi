using GatewayApiClient.DataContracts;
using GatewayApiClient.Utility;
using MundipaggApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MundipaggApi.Services
{
    public abstract class AbstractTransactionService : ITransactionService
    {
        public abstract HttpResponse<CreateSaleResponse> Create(CreateTransactionForm form);
        public abstract HttpResponse<ManageSaleResponse> Capture(Guid orderKey);
        public abstract HttpResponse<ManageSaleResponse> Cancel(Guid orkerKey);
    }
}