namespace BemPropostas.Infrastructure
{
    public interface IDatabase
    {
        Task<int> CommitAsync();
    }
}
