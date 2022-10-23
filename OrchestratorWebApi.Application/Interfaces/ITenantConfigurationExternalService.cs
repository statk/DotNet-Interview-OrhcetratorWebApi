namespace OrchestratorWebApi.Application.Interfaces;

public interface ITenantConfigurationExternalService
{
    Task<string> GetTenantCurrencyAsync(string userTenant, CancellationToken cancellationToken);
    Task PrepareTenantAsync(string userTenant, CancellationToken cancellationToken);
}