using BemPropostas.Propostas.Repository;
using System.Threading.Tasks;

namespace BemPropostas.Infrastructure.Repositories;

public class PropostasRepository(BemPropostasDbContext bemPropostasDbContext) : IPropostaRepository
{
    public IDatabase Database => bemPropostasDbContext;

    public void Add(Proposta proposta)
    {
        bemPropostasDbContext.Add(proposta);
    }

    public async Task<Proposta?> FindAsync(int id)
    {
        return await bemPropostasDbContext.FindAsync<Proposta>(id);
    }
}
