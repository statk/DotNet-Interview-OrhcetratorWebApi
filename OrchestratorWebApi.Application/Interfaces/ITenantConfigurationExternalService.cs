namespace OrchestratorWebApi.Application.Interfaces;

public interface ITenantConfigurationExternalService
{
    Task<string> GetTenantCurrencyAsync(string userTenant, CancellationToken cancellationToken);
}