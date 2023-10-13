using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MyPage.Infrastructure.EF.Contexts;
using MyPage.Infrastructure.EF.Options;

namespace MyPage.Infrastructure.EF;

public static class Extensions {
    public static IServiceCollection AddEF(this IServiceCollection services, IConfiguration configuration) {
        services.AddScoped<IMyPageRepository, PostgresPackingListRepository>();
        var options = configuration.GetOptions<PostgresOptions>("Postgres");

        services.AddDbContext<ApplicationDbContext>(ctx
                => ctx.UseNpgsql(options.ConnectionString));

        return services;
    }
}
