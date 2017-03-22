using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MundipaggApi.Services
{
    public abstract class AbstractTransactionService : ITransactionService
    {
        public abstract void Create();
        public abstract void Capture();
        public abstract void Cancel();
    }
}