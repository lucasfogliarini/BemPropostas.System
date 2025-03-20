using BemPropostas.Infrastructure;
using BemPropostas.Repository;
using BemPropostas;

namespace Bem.Infrastructure.Repositories;

public class PropostasRepository(BemPropostasDbContext bemPropostasDbContext) : IPropostasRepository
{
    public IDatabase Database => bemPropostasDbContext;

    public void Add(Proposta proposta)
    {
        bemPropostasDbContext.Add(proposta);
    }
}
