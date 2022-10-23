using OrchestratorWebApi.Application.Models;

namespace OrchestratorWebApi.Infrastructure.ApiServices;

/// <summary>
/// Do not change this class it represents the call to the external API
/// </summary>
public class UserIdentityApiClient
{
    public async Task<UserModel?> GetUserConfigurationAsync(string userIdentityId, CancellationToken cancellationToken)
    {
        await Task.Delay(1000, cancellationToken);
        return new UserModel
        {
            UserId = Guid.NewGuid().ToString(),
            UserTenantId = Faker.Country.TwoLetterCode()
        };
    }
}