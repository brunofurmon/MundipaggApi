using MundipaggApi.Daos;
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

        public override void Create()
        {
            this.dao.Create();
        }

        public override void Capture()
        {
            this.dao.Capture();
        }

        public override void Cancel()
        {
            this.dao.Cancel();
        }
    }
}