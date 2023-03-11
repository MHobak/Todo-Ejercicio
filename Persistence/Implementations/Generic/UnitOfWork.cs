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

        public void CreateTransaction()
        {
            objTran = Context.Database.BeginTransaction();
        }

        public void Rollback()
        {
            objTran.Rollback();
            objTran.Dispose();
        }

        public void Save()
        {
            this.Context.SaveChanges();
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
