﻿using GatewayApiClient;
using GatewayApiClient.DataContracts;
using GatewayApiClient.DataContracts.EnumTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;


namespace MundipaggApi.Daos
{
    public class CreditCardDao: AbstractTransactionDao
    {
        public CreditCardDao() : base() { }

        public override void Cancel()
        {
            throw new NotImplementedException();
        }

        public override void Capture()
        {
            throw new NotImplementedException();
        }

        public override void Create()
        {
            throw new NotImplementedException();
        }
    }
}