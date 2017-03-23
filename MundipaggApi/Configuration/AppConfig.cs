using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;


namespace MundipaggApi.Configuration
{
    public static class AppConfig
    {
        public static Guid GetMerchantKey()
        {
            string merchantKeystring = ConfigurationManager.AppSettings["GatewayService.MerchantKey"];
            Guid merchantKey = Guid.Parse(merchantKeystring);
            return merchantKey;
        }

        public static string GetHostUri()
        {
            string hostUri = ConfigurationManager.AppSettings["GatewayService.HostUri"];
            return hostUri;
        }
    }
}