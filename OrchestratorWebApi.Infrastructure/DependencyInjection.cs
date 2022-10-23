using Microsoft.Extensions.DependencyInjection;
using OrchestratorWebApi.Application.Interfaces;
using OrchestratorWebApi.Infrastructure.ApiServices;
using OrchestratorWebApi.Infrastructure.ExternalServices;

namespace OrchestratorWebApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IUserIdentityExternalService, UserIdentityService>(
            _ =>
            new UserIdentityService(new UserIdentityApiClient()));
        services.AddTransient<ITenantConfigurationExternalService, TenantConfigurationExternalService>(
            _ =>
                new TenantConfigurationExternalService(new TenantApiClient()));
        services.AddTransient<ITenantConfigurationExternalService, TenantConfigurationExternalService>(
            _ =>
                new TenantConfigurationExternalService(new TenantApiClient()));
        services.AddTransient<IPaymentExternalService, PaymentExternalService>(
            _ =>
                new PaymentExternalService(new PaymentApiClient()));
        return services;
    }
}