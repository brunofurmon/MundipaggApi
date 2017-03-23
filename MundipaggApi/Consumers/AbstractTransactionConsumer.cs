using GatewayApiClient;
using GatewayApiClient.DataContracts;
using GatewayApiClient.Utility;
using MundipaggApi.Configuration;
using MundipaggApi.Dto;
using System;


namespace MundipaggApi.Consumers
{
    public abstract class AbstractMundipaggConsumer: ITransactionConsumer
    {
        // Host URI - defined in Web.config
        protected static string HOST_URI = AppConfig.GetHostUri();
        // Merchant Key - defined in Web.config
        protected static Guid MERCHANT_KEY = AppConfig.GetMerchantKey();

        // Gateway Client
        protected GatewayServiceClient serviceClient { get; set; }

        public AbstractMundipaggConsumer() : base()
        {
            this.serviceClient = new GatewayServiceClient(MERCHANT_KEY, new Uri(HOST_URI));
        }

        public abstract HttpResponse<CreateSaleResponse> Create(CreateTransactionForm form);
        public abstract HttpResponse<ManageSaleResponse> Capture(Guid orkerKey);
        public abstract HttpResponse<ManageSaleResponse> Cancel(Guid orderKey);
    }
}