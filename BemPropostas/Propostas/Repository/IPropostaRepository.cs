namespace BemPropostas.Propostas.Repository;

public interface IPropostaRepository : IRepository
{
    void Add(Proposta proposta);
    Task<Proposta?> FindAsync(int id);
}
