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
        return await _paymentApiClient.GetTransactionsAsync(userId, fromDate, toDate, cancellationToken);
    }
}