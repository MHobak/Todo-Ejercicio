using AutoMapper;
using Domain.DTOs;
using Infraestructure.Utils.Dto;
using Persistence.Interfaces.Repository;
using Service.Interfaces;
using Persistence.Interfaces.Generic;
using Infraestructure.Exceptions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Service.Implementations
{
    public class TareaService : ITareaService
    {
        #region Variables
        private readonly IMapper mapper;
        private readonly ITareaRepository repository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        public TareaService(IMapper mapper, ITareaRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<IEnumerable<TareaDto>> GetAll()
        {
            var result = await repository.GetAsync();
            return mapper.Map<IEnumerable<TareaDto>>(result);
        }

        public async Task<ResponseWrapper<IEnumerable<TareaDto>>> GetAll(
            int metaId,
            int pageNumber, 
            int pageSize, 
            string sortColumn, 
            string sortOrder, 
            string searchTerm)
        {
            var query = repository.GetTable().Where(x => x.MetaId == metaId);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(x => 
                    x.Nombre.ToLower().Contains(searchTerm.ToLower())
                    // x.FechaCreacion.ToString().ToLower().Contains(searchTerm) ||
                    //x.Estado.ToString().ToLower().Contains(searchTerm.ToLower())
                );
            }
            
            if (!string.IsNullOrWhiteSpace(sortColumn))
            {
                if(sortOrder == "Descending")
                {
                    query = query.OrderByDescending(x => EF.Property<object>(x, sortColumn));
                }
                else
                {
                    query = query.OrderBy(x => EF.Property<object>(x, sortColumn));
                }
            }

            var response = new ResponseWrapper<IEnumerable<TareaDto>>();
            if(pageSize > 0 ) response.PageSize = pageSize;
            if(pageNumber > 0 ) response.PageNumber = pageNumber;

            var result = await query
                .Skip((response.PageNumber - 1) * response.PageSize)
                .Take(response.PageSize).ToListAsync();

            response.Data = mapper.Map<IEnumerable<TareaDto>>(result);
            response.TotalItems = await query.CountAsync();

            return response;
        }

        public async Task<TareaDto> GetById(int id)
        {
            var result = await repository.GetById(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return mapper.Map<TareaDto>(result);
        }

        public async Task<TareaDto> Create(TareaDto request)
        {
            unitOfWork.CreateTransaction();

            var tarea = mapper.Map<Tarea>(request);
            tarea.FechaCreacion = DateTime.Now;
            repository.Insert(tarea);
            await unitOfWork.SaveAsync();
            await unitOfWork.CommitAsync();

            return mapper.Map<TareaDto>(tarea);
        }

        public async Task<TareaDto> Update(TareaDto request)
        {
            unitOfWork.CreateTransaction();

            if (!await repository.Any(x => x.Id == request.Id))
            {
                throw new NotFoundException();
            }

            var newTarea = mapper.Map<Tarea>(request);
            repository.Update(newTarea);
            await unitOfWork.SaveAsync();
            await unitOfWork.CommitAsync();

            return mapper.Map<TareaDto>(newTarea);
        }

        public async Task<bool> DeleteById(int id)
        {
            unitOfWork.CreateTransaction();

            var tarea = await repository.GetById(id);
            if (tarea == null)
            {
                throw new NotFoundException();
            }
            
            repository.Delete(tarea);
            await unitOfWork.SaveAsync();
            await unitOfWork.CommitAsync();

            return true;
        }
    }
}