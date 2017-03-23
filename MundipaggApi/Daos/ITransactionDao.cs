using GatewayApiClient.DataContracts;
using GatewayApiClient.Utility;
using MundipaggApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MundipaggApi.Daos
{
    public interface ITransactionDao
    {
        HttpResponse<CreateSaleResponse> Create(CreateTransactionForm form);
        HttpResponse<ManageSaleResponse> Capture(Guid orkerKey);
        HttpResponse<ManageSaleResponse> Cancel(Guid orkerKey);
    }
}