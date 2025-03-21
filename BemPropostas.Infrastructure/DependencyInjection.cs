using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BemPropostas.Infrastructure;
using BemPropostas.Propostas.Repository;
using BemPropostas.Infrastructure.Repositories;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositories();
        services.AddDbContext();
        services.AddIntegrations(configuration);
        services.AddServices();
    }

    public static void AddServices(this IServiceCollection services)
    {
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPropostasRepository, PropostasRepository>();
    }

    public static void AddDbContext(this IServiceCollection services)
    {
        services.AddDbContext<BemPropostasDbContext>(options => options.UseInMemoryDatabase(nameof(BemPropostasDbContext)));
    }

    public static void AddIntegrations(this IServiceCollection services, IConfiguration configuration)
    {
    }
}
