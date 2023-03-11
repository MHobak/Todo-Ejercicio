namespace Persistence.Interfaces.Generic
{
    public interface IUnitOfWork : IDisposable
    {
        TodoDbContext Context { get; }

        void Commit();

        void CreateTransaction();

        void Rollback();

        void Save();
    }
}
