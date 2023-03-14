using AutoMapper;
using Domain.DTOs;
using Infraestructure.Utils.Dto;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ResponseWrapper<IEnumerable<MetaDto>>> GetAll()
        {
            var query = repository.GetTable();
            var response = new ResponseWrapper<IEnumerable<MetaDto>>();
            var result = await query
                .Skip((response.PageNumber - 1) * response.PageSize)
                .Take(response.PageSize).ToListAsync();

            response.Data = mapper.Map<IEnumerable<MetaDto>>(result);
            response.TotalItems = await query.CountAsync();

            return response;
        }

        public async Task<MetaDto> GetById(int id)
        {
            var result = await repository.GetById(id);
            if (result != null)
            {
                return mapper.Map<MetaDto>(result);
            }

            return null;
        }
    }
}
