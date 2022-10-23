using MediatR;

namespace OrchestratorWebApi.Application.UseCases.GetTransactions;

public record GetTransactionsQuery : IRequest<ICollection<GetTransactionsQueryResponse>>
{
    public string UserIdentityId { get; init; }
    public DateOnly FromDate { get; init; }
    public DateOnly ToDate { get; init; }
}