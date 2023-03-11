using Domain.Views;
using Persistence.Implementations.Generic;
using Persistence.Interfaces.Generic;
using Persistence.Interfaces.Repository;

namespace Persistence.Implementations.Repository
{
    public class MetaViewRepository : GenericRepository<MetaView, int>, IMetaViewRepository
    {
        #region Propiedades
        private readonly IUnitOfWork unitOfWork;
        #endregion

        public MetaViewRepository(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
            this.unitOfWork = _unitOfWork ?? throw new ArgumentException(nameof(_unitOfWork));
        }
    }
}
