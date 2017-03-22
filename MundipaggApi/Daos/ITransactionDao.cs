using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MundipaggApi.Daos
{
    public interface ITransactionDao
    {
        void Create();
        void Capture();
        void Cancel();
    }
}