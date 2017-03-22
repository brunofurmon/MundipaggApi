using MundipaggApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MundipaggApi.Tests.Mocks.Services
{
    public class MockedBoletoService : AbstractTransactionService
    {
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
