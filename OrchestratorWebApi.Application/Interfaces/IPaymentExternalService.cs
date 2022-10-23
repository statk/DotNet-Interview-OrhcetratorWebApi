using OrchestratorWebApi.Application.Models;

namespace OrchestratorWebApi.Application.Interfaces;

public interface IPaymentExternalService
{
    public Task<ICollection<TransactionModel>> GetTransactionsAsync(string userId, DateOnly fromDate, DateOnly toDate, 
        CancellationToken cancellationToken);
}