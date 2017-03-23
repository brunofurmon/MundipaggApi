using GatewayApiClient.DataContracts;
using GatewayApiClient.Utility;
using MundipaggApi.Dto;
using System;


namespace MundipaggApi.Consumers
{
    public interface ITransactionConsumer
    {
        HttpResponse<CreateSaleResponse> Create(CreateTransactionForm form);
        HttpResponse<ManageSaleResponse> Capture(Guid orkerKey);
        HttpResponse<ManageSaleResponse> Cancel(Guid orkerKey);
    }
}