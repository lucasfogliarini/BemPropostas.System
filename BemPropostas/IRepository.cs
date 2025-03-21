namespace BemPropostas
{
    public interface IRepository
    {
        IDatabase Database { get; }
    }

    public interface IDatabase
    {
        Task<int> CommitAsync();
    }
}
