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

        /// <summary>
        /// Método para marcar una tarea como importante
        /// </summary>
        /// <param name="tareaId">Identificador de la tarea</param>
        /// <returns>Elemento modificado</returns>
        Task<TareaDto> EstablecerImportancia(int tareaId);

        /// <summary>
        /// Método para completar varios registros
        /// </summary>
        /// <param name="ids">Identificadores de registros</param>
        /// <returns>Task</returns>
        Task Completar(int[] ids);

        /// <summary>
        /// Método para eliminar varios registors
        /// </summary>
        /// <param name="ids">Identificadores de registros</param>
        /// <returns>Task</returns>
        Task Delete(int[] ids);
    }
}