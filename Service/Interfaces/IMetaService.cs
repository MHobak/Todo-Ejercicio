using Domain.DTOs;

namespace Service.Interfaces
{
    public interface IMetaService
    {
        /// <summary>
        /// Definición de método para todos los registros
        /// </summary>
        /// <returns>Objeto MetaDto</returns>
        Task<IEnumerable<MetaDto>> GetAll();

        /// <summary>
        /// Definición de método para obtener un registro por su identificador
        /// </summary>
        /// <param name="id">Identificador de la meta</param>
        /// <returns>Objeto MetaDto</returns>
        Task<MetaDto> GetById(int id);

        /// <summary>
        /// Definición de método para insertar un registro
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Objeto MetaDto</returns>
        Task<MetaDto> Create(MetaDto request);

        /// <summary>
        /// Definición de método para actualizar un registro
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Objeto MetaDto</returns>
        Task<MetaDto> Update(MetaDto request);

        /// <summary>
        /// Definición de método para eliminar un registro por el identificador
        /// </summary>
        /// <param name="id">Identificador de la meta</param>
        /// <returns>valor lógico que indica si se eliminó</returns>
        public Task<bool> DeleteById(int id);
    }
}
