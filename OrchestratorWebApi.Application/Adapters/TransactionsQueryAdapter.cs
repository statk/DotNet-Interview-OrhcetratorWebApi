using OrchestratorWebApi.Application.Models;
using OrchestratorWebApi.Application.UseCases.GetTransactions;

namespace OrchestratorWebApi.Application.Adapters;

public static class TransactionsQueryAdapter
{
    public static ICollection<GetTransactionsQueryResponse> ToTransactionsQueryResponse(this ICollection<TransactionModel> transactions)
    {
        var transactionsResponse = new List<GetTransactionsQueryResponse>(transactions.Count);
        foreach (var transaction in transactions)
        {
            transactionsResponse.Add(transaction.ToTransactionsQueryResponse());
        }

        return transactionsResponse;
    }
    
    private static GetTransactionsQueryResponse ToTransactionsQueryResponse(this TransactionModel transactionModel)
    {
        return new GetTransactionsQueryResponse
        {
            TransactionId = transactionModel.TransactionId,
            BenefitName = transactionModel.BenefitName,
            Datetime = transactionModel.Datetime,
            Type = transactionModel.Type,
            Amount = transactionModel.Amount,
            Address = new Address
            {
                Country = transactionModel.Address.Country,
                City = transactionModel.Address.City,
                Street = transactionModel.Address.Street,
                PostCode = transactionModel.Address.PostCode
            }
        };
    }
}