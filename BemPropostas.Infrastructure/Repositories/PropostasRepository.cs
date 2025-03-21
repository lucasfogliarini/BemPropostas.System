using BemPropostas.Propostas.Repository;

namespace BemPropostas.Infrastructure.Repositories;

public class PropostasRepository(BemPropostasDbContext bemPropostasDbContext) : IPropostasRepository
{
    public IDatabase Database => bemPropostasDbContext;

    public void Add(Proposta proposta)
    {
        bemPropostasDbContext.Add(proposta);
    }
}
