namespace OrchestratorWebApi.Application.Models;

public record UserModel
{
    public string UserId { get; init; }
    public string UserTenantId { get; init; }
}