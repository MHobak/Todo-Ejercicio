using Domain.DTOs;
using Infraestructure.Utils.Dto;

namespace Service.Interfaces
{
    public interface ITareaService
    {
        /// <summary>
        /// Definición de método para todos los registros
        /// </summary>
        /// <returns>Objeto TareaDto</returns>
        Task<IEnumerable<TareaDto>> GetAll();

        /// <summary>
        /// Definición de método para todos los registros
        /// </summary>
        /// <returns>Objeto TareaDto</returns>
        Task<ResponseWrapper<IEnumerable<TareaDto>>> GetAll(
            int metaId,
            int pageNumber, 
            int pageSize, 
            string sortColumn, 
            string sortOrder, 
            string SearchTerm,
            string fecha,
            string estado);

        /// <summary>
        /// Definición de método para obtener un registro por su identificador
        /// </summary>
        /// <param name="id">Identificador de la tarea</param>
        /// <returns>Objeto TareaDto</returns>
        Task<TareaDto> GetById(int id);

        /// <summary>
        /// Definición de método para insertar un registro
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Objeto TareaDto</returns>
        Task<TareaDto> Create(TareaDto request);

        /// <summary>
        /// Definición de método para actualizar un registro
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Objeto TareaDto</returns>
        Task<TareaDto> Update(TareaDto request);

        /// <summary>
        /// Definición de método para defifnir tareas como importantes
        /// </summary>
        /// <param name="id">Identificador de la tarea</param>
        Task<TareaDto> EstablecerComoImportante(int id);

        /// <summary>
        /// Definición de método para cambiar el estado de varias tareas como completada
        /// </summary>
        /// <param name="ids">Identificadores de las tareas</param>
        Task Completar(int[] ids);

        /// <summary>
        /// Definición de método para eliminar una tarea
        /// </summary>
        /// <param name="id">Identificador de la tarea</param>
        /// <returns>valor lógico que indica si se eliminó</returns>
        Task<bool> DeleteById(int id);

        /// <summary>
        /// Definición de método para eliminar varias tareas
        /// </summary>
        /// <param name="ids">Identificadores de las tareas</param>
        /// <returns>valor lógico que indica si se eliminó</returns>
        Task DeleteByIds(int[] ids);
    }
}