using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Persistence.Interfaces.Generic;
using Persistence.Interfaces.Repository;
using Service.Interfaces;

namespace Service.Implementations
{
    public class MetaService : IMetaService
    {
        #region Variables
        private readonly IMapper mapper;
        private readonly IMetaRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public MetaService(IMapper mapper, IMetaRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        #endregion

        public async Task<IEnumerable<MetaDto>> GetAll()
        {
            var result = await repository.GetAsync();
            return mapper.Map<IEnumerable<MetaDto>>(result);
        }

        public async Task<MetaDto> GetById(int id)
        {
            var result = await repository.GetById(id);
            return mapper.Map<MetaDto>(result);
        }

        public async Task<MetaDto> Create(MetaDto request)
        {
            unitOfWork.CreateTransaction();

            var meta = mapper.Map<Meta>(request);
            repository.Insert(meta);
            await unitOfWork.SaveAsync();
            await unitOfWork.CommitAsync();

            return mapper.Map<MetaDto>(meta);
        }

        public Task<MetaDto> Update(MetaDto request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
