using MundipaggApi.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MundipaggApi.Services
{
    public class BoletoService : AbstractTransactionService
    {
        private readonly ITransactionDao dao;

        public BoletoService() : base()
        {
            this.dao = new BoletoDao();
        }

        public BoletoService(
            ITransactionDao boletoTransactionDao
            ) : base()
        {
            this.dao = boletoTransactionDao;
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