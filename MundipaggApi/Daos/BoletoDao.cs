using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MundipaggApi.Daos
{
    public class BoletoDao : AbstractTransactionDao
    {
        public BoletoDao() : base() { }

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