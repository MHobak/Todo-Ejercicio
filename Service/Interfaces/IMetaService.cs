using Domain.DTOs;
using Infraestructure.Utils.Dto;

namespace Service.Interfaces
{
    public interface IMetaService
    {
        /// <summary>
        /// Definición de método para obtener un registro por su identificador
        /// </summary>
        /// <param name="_iId">Identificador de la meta</param>
        /// <returns>Objeto MetaDto en wrapper Respuesta</returns>
        Task<Response<MetaDto>> GetById(int _iId);

        /// <summary>
        /// Definición de método para insertar un registro
        /// </summary>
        /// <param name="_request"></param>
        /// <returns>Objeto MetaDto en wrapper Respuesta</returns>
        Task<Response<MetaDto>> Create(MetaDto _request);

        /// <summary>
        /// Definición de método para actualizar un registro
        /// </summary>
        /// <param name="_request"></param>
        /// <returns>Objeto MetaDto en wrapper Respuestas</returns>
        Task<Response<MetaDto>> Update(MetaDto _request);

        /// <summary>
        /// Definición de método para eliminar un registro por el identificador
        /// </summary>
        /// <param name="_iId">Identificador de la meta</param>
        /// <returns>bool en wrapper Respuesta</returns>
        public Task<Response<bool>> DeleteById(int _iId);
    }
}
