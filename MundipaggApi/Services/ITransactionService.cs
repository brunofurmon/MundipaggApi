using GatewayApiClient.DataContracts;
using GatewayApiClient.Utility;
using MundipaggApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MundipaggApi.Services
{
    public interface ITransactionService
    {
        HttpResponse<CreateSaleResponse> Create(CreateTransactionForm form);
        HttpResponse<ManageSaleResponse> Capture(Guid orderKey);
        HttpResponse<ManageSaleResponse> Cancel(Guid orkerKey);
    }
}