using OrchestratorWebApi.Application.Interfaces;
using OrchestratorWebApi.Application.Models;
using OrchestratorWebApi.Infrastructure.ApiServices;

namespace OrchestratorWebApi.Infrastructure.ExternalServices;

public class UserIdentityService : IUserIdentityExternalService
{
    private readonly UserIdentityApiClient _userIdentityApiClient;

    public UserIdentityService(UserIdentityApiClient userIdentityApiClient)
    {
        _userIdentityApiClient = userIdentityApiClient;
    }
    public async Task<UserModel> GetUserIdAsync(string userIdentityId, CancellationToken cancellationToken)
    {
        var userConfiguration =
            await _userIdentityApiClient.GetUserConfigurationAsync(userIdentityId, cancellationToken);
        if (userConfiguration != null)
        {
            throw new ArgumentException($"{nameof(userConfiguration)} cannot be null");
        }

        return userConfiguration!;
    }
}