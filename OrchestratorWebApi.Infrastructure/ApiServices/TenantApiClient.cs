namespace OrchestratorWebApi.Infrastructure.ApiServices;

/// <summary>
/// Do not change this class it represents the call to the external API
/// </summary>
public class TenantApiClient
{
    public async Task<string?> GetTenantCurrencyAsync(string tenantId, CancellationToken cancellationToken)
    {
        await Task.Delay(20000, cancellationToken);
        return Faker.Currency.ThreeLetterCode();
    }
}