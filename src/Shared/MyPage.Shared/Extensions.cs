using Microsoft.Extensions.DependencyInjection;
using MyPage.Shared.Services;

namespace MyPage.Shared;

public static class Extensions {
    public static IServiceCollection AddShared(this IServiceCollection services) {
        services.AddHostedService<AppInitializer>();

        return services;
    }
}