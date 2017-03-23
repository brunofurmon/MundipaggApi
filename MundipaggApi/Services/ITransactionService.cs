using MundipaggApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MundipaggApi.Services
{
    public interface ITransactionService
    {
        void Create(CreateTransactionForm form);
        void Capture(Guid orderKey);
        void Cancel(Guid orkerKey);
    }
}