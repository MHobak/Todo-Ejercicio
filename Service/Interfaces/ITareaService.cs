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
        Task<ResponseWrapper<IEnumerable<TareaDto>>> GetAll(int pageNumber, int pageSize);

        /// <summary>
        /// Definición de método para todos los registros
        /// </summary>
        /// <returns>Objeto TareaDto</returns>
        Task<ResponseWrapper<IEnumerable<TareaDto>>> GetAllFromMeta(int metaId,int pageNumber, int pageSize);

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
        /// Definición de método para eliminar un registro por el identificador
        /// </summary>
        /// <param name="id">Identificador de la tarea</param>
        /// <returns>valor lógico que indica si se eliminó</returns>
        public Task<bool> DeleteById(int id);
    }
}