using MundipaggApi.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MundipaggApi.Services
{
    public class OnlineDebtService : AbstractTransactionService
    {
        private readonly ITransactionDao dao;

        public OnlineDebtService() : base()
        {
            this.dao = new OnlineDebtDao();
        }

        public OnlineDebtService(
            ITransactionDao onlineDebtTransactionDao
            ) : base()
        {
            this.dao = onlineDebtTransactionDao;
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