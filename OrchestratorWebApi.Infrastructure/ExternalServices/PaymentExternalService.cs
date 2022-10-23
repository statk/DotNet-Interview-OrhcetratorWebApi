using OrchestratorWebApi.Application.Interfaces;
using OrchestratorWebApi.Application.Models;
using OrchestratorWebApi.Infrastructure.ApiServices;

namespace OrchestratorWebApi.Infrastructure.ExternalServices;

public class PaymentExternalService : IPaymentExternalService
{
    private readonly PaymentApiClient _paymentApiClient;

    public PaymentExternalService(PaymentApiClient paymentApiClient)
    {
        _paymentApiClient = paymentApiClient;
    }
    public async Task<ICollection<TransactionModel>> GetTransactionsAsync(string userId, DateOnly fromDate, DateOnly toDate, CancellationToken cancellationToken)
    {
        var transactions = (await _paymentApiClient.GetTransactionsAsync(userId, fromDate, toDate, cancellationToken))!.ToList();
        var transactionsResult = new List<TransactionModel>();
        
        for(var i = 0; i < transactions.Count; i++)
        {
            if(i % 2 == 0)
            {
                transactionsResult.Add(null);
            }
            
            transactionsResult.Add(transactions[i]);
        }

        return transactionsResult;
    }
}