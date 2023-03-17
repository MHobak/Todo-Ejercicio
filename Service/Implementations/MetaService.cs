using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Persistence.Interfaces.Generic;
using Persistence.Interfaces.Repository;
using Service.Interfaces;
using Infraestructure.Exceptions;

namespace Service.Implementations
{
    public class MetaService : IMetaService
    {
        #region Variables
        private readonly IMapper mapper;
        private readonly IMetaRepository repository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        public MetaService(IMapper mapper, IMetaRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<IEnumerable<MetaDto>> GetAll()
        {
            var result = await repository.GetAsync();
            return mapper.Map<IEnumerable<MetaDto>>(result);
        }

        public async Task<MetaDto> GetById(int id)
        {
            var result = await repository.GetById(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return mapper.Map<MetaDto>(result);
        }

        public async Task<MetaDto> Create(MetaDto request)
        {
            unitOfWork.CreateTransaction();

            var meta = mapper.Map<Meta>(request);
            meta.FechaCreacion = DateTime.Now;
            repository.Insert(meta);
            await unitOfWork.SaveAsync();
            await unitOfWork.CommitAsync();

            return mapper.Map<MetaDto>(meta);
        }

        public async Task<MetaDto> Update(MetaDto request)
        {
            unitOfWork.CreateTransaction();

            if (!await repository.Any(x => x.Id == request.Id))
            {
                throw new NotFoundException();
            }

            var newMeta = mapper.Map<Meta>(request);
            repository.Update(newMeta);
            await unitOfWork.SaveAsync();
            await unitOfWork.CommitAsync();

            return mapper.Map<MetaDto>(newMeta);
        }

        public async Task<bool> DeleteById(int id)
        {
            unitOfWork.CreateTransaction();

            var meta = await repository.GetById(id);
            if (meta == null)
            {
                throw new NotFoundException();
            }
            
            repository.Delete(meta);
            await unitOfWork.SaveAsync();
            await unitOfWork.CommitAsync();

            return true;
        }
    }
}
