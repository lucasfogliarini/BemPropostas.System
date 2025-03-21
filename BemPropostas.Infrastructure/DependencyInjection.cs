using Microsoft.EntityFrameworkCore;
using BemPropostas.Infrastructure;
using BemPropostas.Propostas.Repository;
using BemPropostas.Infrastructure.Repositories;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext();
        services.AddRepositories();
    }
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPropostaRepository, PropostasRepository>();
    }
    public static void AddDbContext(this IServiceCollection services)
    {
        services.AddDbContext<BemPropostasDbContext>(options => options.UseInMemoryDatabase(nameof(BemPropostasDbContext)));
    }
}
