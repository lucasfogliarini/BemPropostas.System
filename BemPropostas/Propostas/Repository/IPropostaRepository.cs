namespace BemPropostas.Propostas.Repository;

public interface IPropostaRepository : IRepository
{
    Task<Proposta?> FindAsync(int id);
}
