namespace Persistence.Interfaces.Generic
{
    public interface IUnitOfWork : IDisposable
    {
        TodoDbContext Context { get; }

        void Commit();

        Task CommitAsync();

        void CreateTransaction();

        Task CreateTransactionAsync();

        void Rollback();

        Task RollbackAsync();

        void Save();

        Task SaveAsync();
    }
}
