using Microsoft.EntityFrameworkCore.Storage;
using Persistence.Interfaces.Generic;

namespace Persistence.Implementations.Generic
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public TodoDbContext Context { get; }

        private bool disposed = false;

        private IDbContextTransaction objTran;

        public UnitOfWork(TodoDbContext _context)
        {
            Context = _context ?? throw new ArgumentNullException(nameof(_context));
        }

        public void Commit()
        {
            objTran.Commit();
        }

        public async Task CommitAsync()
        {
            await objTran.CommitAsync();
        }

        public void CreateTransaction()
        {
            objTran = Context.Database.BeginTransaction();
        }

        public async Task CreateTransactionAsync()
        {
            objTran = await Context.Database.BeginTransactionAsync();
        }

        public void Rollback()
        {
            objTran.Rollback();
            objTran.Dispose();
        }

        public async Task RollbackAsync()
        {
            await objTran.RollbackAsync();
            await objTran.DisposeAsync();
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await this.Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool _disposing)
        {
            if (!this.disposed)
            {
                if (_disposing)
                {
                    this.Context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
