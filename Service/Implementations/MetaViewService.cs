using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Persistence.Implementations.Repository;
using Persistence.Interfaces.Generic;
using Persistence.Interfaces.Repository;
using Service.Interfaces;

namespace Service.Implementations
{
    public class MetaViewService : IMetaViewService
    {
        #region Variables
        private readonly IMapper mapper;
        private readonly IMetaViewRepository repository;

        public MetaViewService(IMapper mapper, IMetaViewRepository repository)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        #endregion

        public async Task<IEnumerable<MetaDto>> GetAll()
        {
            var result = await repository.GetAsync();
            return mapper.Map<IEnumerable<MetaDto>>(result);
        }
    }
}
