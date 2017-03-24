# MundipaggApi
### Api de integração para Mundipagg
Autor: Bruno Furtado

## Criando Transações

## POST /api/transaction

#### Body Params

**AmountInCents**


obrigatório / **integer**

Valor da transação em centavos. R$ 100,00 = 10000

**CreditCardCreditCardBrand**


obrigatório / **string**

Bandeira do cartão do cliente

**CreditCardCreditCardNumber**


obrigatório / **string**

Número do cartão do cliente. Informar apenas números.

**CreditCardExpMonth**


obrigatório / **integer**

Mês de expiração do cartão

**CreditCardExpYear**


obrigatório / **integer**

Ano de expiração do cartão

**CreditCardSecurityCode** **integer**

Código de segurança do cartão

**>CreditCardHolderName**


obrigatório / **string**

Nome do portador do cartão

**InstallmentCount** **integer**

Número de Parcelas

## Cancelamento

## POST /api/transaction/{orderKey}/cancel

#### Body Params

**orderKey**


obrigatório / **string**

Chave do pedido da MundiPagg

## Captura

## POST /api/transaction/{orderKey}/capture

#### Body Params

**orderKey:**


obrigatório / **string**

Chave do pedido da MundiPagg
