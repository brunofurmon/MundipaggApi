using MundipaggApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MundipaggApi.Daos
{
    public abstract class AbstractTransactionDao: ITransactionDao
    {
        public AbstractTransactionDao() : base() { }

        public abstract void Create(CreateTransactionForm form);
        public abstract void Capture(Guid orkerKey);
        public abstract void Cancel(Guid orderKey);
    }
}