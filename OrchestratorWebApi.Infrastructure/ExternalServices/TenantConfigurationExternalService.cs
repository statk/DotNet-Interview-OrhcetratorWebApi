using OrchestratorWebApi.Application.Interfaces;
using OrchestratorWebApi.Infrastructure.ApiServices;

namespace OrchestratorWebApi.Infrastructure.ExternalServices;

public class TenantConfigurationExternalService : ITenantConfigurationExternalService
{
    private readonly TenantApiClient _tenantApiClient;

    public TenantConfigurationExternalService(TenantApiClient tenantApiClient)
    {
        _tenantApiClient = tenantApiClient;
    }
    public async Task<string> GetTenantCurrencyAsync(string userTenant, CancellationToken cancellationToken)
    {
        var tenantCurrency = await _tenantApiClient.GetTenantCurrencyAsync(userTenant, cancellationToken);
        if (tenantCurrency == null)
        {
            throw new ArgumentException($"{nameof(tenantCurrency)} cannot be null");
        }

        return tenantCurrency;
    }
}