using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BemPropostas.Infrastructure;

public class BemPropostasDbContext(DbContextOptions options) : DbContext(options), IDatabase
{
    public async Task<int> CommitAsync()
    {
        return await SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var thisAssembly = Assembly.GetExecutingAssembly();
        modelBuilder.ApplyConfigurationsFromAssembly(thisAssembly);
    }
}
