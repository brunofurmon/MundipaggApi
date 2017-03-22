using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MundipaggApi.Daos
{
    public abstract class AbstractTransactionDao: ITransactionDao
    {
        public AbstractTransactionDao() : base() { }

        public abstract void Create();
        public abstract void Capture();
        public abstract void Cancel();
    }
}