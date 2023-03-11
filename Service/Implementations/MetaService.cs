using Domain.DTOs;
using Infraestructure.Utils.Dto;
using Persistence.Interfaces.Generic;
using Persistence.Interfaces.Repository;
using Service.Interfaces;

namespace Service.Implementations
{
    public class MetaService : IMetaService
    {
        #region Variables
        //private readonly IMapper mapper;
        private readonly IMetaRepository repository;
        private readonly IUnitOfWork unitOfWork;

        #endregion

        public Task<Response<MetaDto>> Create(MetaDto _request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> DeleteById(int _iId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<MetaDto>> GetById(int _iId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<MetaDto>> Update(MetaDto _request)
        {
            throw new NotImplementedException();
        }
    }
}
