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

        public override void Cancel(Guid orkerKey)
        {
            throw new NotImplementedException();
        }

        public override void Capture(Guid orkerKey)
        {
            throw new NotImplementedException();
        }

        public override void Create(CreateTransactionForm form)
        {
            throw new NotImplementedException();
        }
    }
}