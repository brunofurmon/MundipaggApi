using MundipaggApi.Daos;
using MundipaggApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MundipaggApi.Services
{
    public class CreditCardService : AbstractTransactionService
    {
        private readonly ITransactionDao dao;

        public CreditCardService() : base()
        {
            this.dao = new CreditCardDao();
        }

        public CreditCardService(
            ITransactionDao creditCardTransactionDao
            ) : base()
        {
            this.dao = creditCardTransactionDao;
        }

        public override void Create(CreateTransactionForm form)
        {
            this.dao.Create(form);
        }

        public override void Capture(Guid orderKey)
        {
            this.dao.Capture(orderKey);
        }

        public override void Cancel(Guid orkerKey)
        {
            this.dao.Cancel(orkerKey);
        }
    }
}