using MundipaggApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MundipaggApi.Services
{
    public abstract class AbstractTransactionService : ITransactionService
    {
        public abstract void Create(CreateTransactionForm form);
        public abstract void Capture(Guid orderKey);
        public abstract void Cancel(Guid orkerKey);
    }
}