using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyPage.Domain.Entities;
using MyPage.Domain.Repositories;
using MyPage.Infrastructure.EF.Contexts;
using MyPage.Infrastructure.EF.Options;
using MyPage.Infrastructure.EF.Repositories;
using MyPage.Shared.Options;

namespace MyPage.Infrastructure.EF;

public static class Extensions {
    public static IServiceCollection AddEF(this IServiceCollection services, IConfiguration configuration) {
        services.AddScoped<IMyPageRepository<Post>, PostgresPostRepository>();
        services.AddScoped<IMyPageRepository<User>, PostgresUserRepository>();

        var options = configuration.GetOptions<PostgresOptions>("Postgres");

        services.AddDbContext<ApplicationDbContext>(ctx
                => ctx.UseNpgsql(options.ConnectionString));

        return services;
    }
}
