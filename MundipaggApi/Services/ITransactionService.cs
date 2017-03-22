using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MundipaggApi.Services
{
    public interface ITransactionService
    {
        void Create();
        void Capture();
        void Cancel();
    }
}