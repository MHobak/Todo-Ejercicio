using Domain.Entities;
using Persistence.Interfaces.Generic;

namespace Persistence.Interfaces.Repository
{
    public interface IMetaRepository : IGenericRepository<Meta, int>
    {
    }
}
