using OrchestratorWebApi.Application.Models;

namespace OrchestratorWebApi.Application.Interfaces;

public interface IUserIdentityExternalService
{
    public Task<UserModel> GetUserIdAsync(string userIdentityId, CancellationToken cancellationToken);
}