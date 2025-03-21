namespace BemPropostas.Propostas.Repository;

public interface IPropostasRepository : IRepository
{
    void Add(Proposta proposta);
    Task<Proposta?> FindAsync(int id);
}
