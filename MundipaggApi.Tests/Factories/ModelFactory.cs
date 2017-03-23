using GatewayApiClient.DataContracts;
using GatewayApiClient.DataContracts.EnumTypes;
using MundipaggApi.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MundipaggApi.Tests.Factories
{
    public static class ModelFactory
    {
        public static CreateTransactionForm BuildCreateTransactionForm()
        {
            CreateTransactionForm createTransactionForm = new CreateTransactionForm
            {
                AmountInCents = 10000,
                CreditCardBrand = "Visa",
                CreditCardNumber = "4111111111111111",
                ExpMonth = 10,
                ExpYear = 22,
                SecurityCode = 123,
                HolderName = "LUKE SKYWALKER",
                InstallmentCount = 1
            };
            return createTransactionForm;
        }

        public static CreditCard GenerateCreditCard()
        {
            CreditCard card = new CreditCard()
            {
                CreditCardBrand = CreditCardBrandEnum.Visa,
                CreditCardNumber = "4111111111111111",
                ExpMonth = 10,
                ExpYear = 22,
                HolderName = "LUKE SKYWALKER",
                SecurityCode = "123"
            };
            return card;
        }

        public static CreateSaleRequest GenerateSaleRequest()
        {
            CreditCard card = GenerateCreditCard();
            // Cria a transação.
            var transaction = new CreditCardTransaction()
            {
                AmountInCents = 10000,
                CreditCard = card,
                InstallmentCount = 1
            };

            // Cria requisição.
            var createSaleRequest = new CreateSaleRequest()
            {
                // Adiciona a transação na requisição.
                CreditCardTransactionCollection = new Collection<CreditCardTransaction>(
                    new CreditCardTransaction[] { transaction }
                ),
                Order = new Order()
                {
                    OrderReference = "NumeroDoPedido"
                }
            };
            return createSaleRequest;
        }
    }
}
