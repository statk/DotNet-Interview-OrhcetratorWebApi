using MediatR;
using OrchestratorWebApi.Application.Adapters;
using OrchestratorWebApi.Application.Interfaces;

namespace OrchestratorWebApi.Application.UseCases.GetTransactions;

public class GetTransactionsQueryHandler: IRequestHandler<GetTransactionsQuery, ICollection<GetTransactionsQueryResponse>>
{
    private readonly IUserIdentityExternalService _userIdentityExternalService;
    private readonly ITenantConfigurationExternalService _tenantConfigurationExternalService;
    private readonly IPaymentExternalService _paymentExternalService;

    public GetTransactionsQueryHandler(IUserIdentityExternalService userIdentityExternalService,
        ITenantConfigurationExternalService tenantConfigurationExternalService, IPaymentExternalService paymentExternalService)
    {
        _userIdentityExternalService = userIdentityExternalService;
        _tenantConfigurationExternalService = tenantConfigurationExternalService;
        _paymentExternalService = paymentExternalService;
    }
    public async Task<ICollection<GetTransactionsQueryResponse>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
    {
        var userConfiguration =  await _userIdentityExternalService.GetUserIdAsync(request.UserIdentityId, cancellationToken);
        
        var transactions = await _paymentExternalService.GetTransactionsAsync(userConfiguration.UserId,
            request.FromDate, request.ToDate, cancellationToken);
       
        var tenantCurrency =
            await _tenantConfigurationExternalService.GetTenantCurrencyAsync(userConfiguration.UserTenantId, cancellationToken);
        
        var transactionsResponse = transactions.ToTransactionsQueryResponse();
        
        foreach (var transaction in transactionsResponse)
        {
            transaction.Currency = tenantCurrency;
        }

        return transactionsResponse;
    }
}