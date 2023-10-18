using Microsoft.Extensions.DependencyInjection;
using MyPage.Shared.Commands;
using MyPage.Shared.Queries;

namespace MyPage.Application;
public static class Extensions {
    public static IServiceCollection AddApplication(this IServiceCollection services) {

        services.AddCommands();
        services.AddQueries();

        return services;
    }
}