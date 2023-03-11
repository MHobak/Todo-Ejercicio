using Domain.Entities;
using Persistence.Implementations.Generic;
using Persistence.Interfaces.Generic;
using Persistence.Interfaces.Repository;

namespace Persistence.Implementations.Repository
{
    public class MetaRepository : GenericRepository<Meta, int>, IMetaRepository
    {
        #region Propiedades
        private readonly IUnitOfWork unitOfWork;
        #endregion

        public MetaRepository(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
            this.unitOfWork = _unitOfWork ?? throw new ArgumentException(nameof(_unitOfWork));
        }
    }
}
