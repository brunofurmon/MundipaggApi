using MundipaggApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MundipaggApi.Daos
{
    public interface ITransactionDao
    {
        void Create(CreateTransactionForm form);
        void Capture(Guid orkerKey);
        void Cancel(Guid orkerKey);
    }
}