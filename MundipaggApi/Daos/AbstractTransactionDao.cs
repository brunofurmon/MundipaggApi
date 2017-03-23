using GatewayApiClient.DataContracts;
using GatewayApiClient.Utility;
using MundipaggApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MundipaggApi.Daos
{
    public abstract class AbstractTransactionDao: ITransactionDao
    {
        public AbstractTransactionDao() : base() { }

        public abstract HttpResponse<CreateSaleResponse> Create(CreateTransactionForm form);
        public abstract HttpResponse<ManageSaleResponse> Capture(Guid orkerKey);
        public abstract HttpResponse<ManageSaleResponse> Cancel(Guid orderKey);
    }
}