using Domain.DTOs;
using Infraestructure.Utils.Dto;

namespace Todo.Client.Services.Interfaces
{
    public interface ITareaService : IRequestService<TareaDto>
    {
        /// <summary>
        /// Método para obtener tareas de una meta
        /// </summary>
        /// <returns>Respuesta de la api</returns>
        Task<ResponseWrapper<List<TareaDto>>> Get(
            int metaId,
            int pageNumber, 
            int pageSize , 
            string sortColumn,
            string sortOrder,
            string searchTerm,
            string fecha,
            string estado);

        Task<TareaDto> EstablecerImportancia(int tareaId);
    }
}