using Domain.DTOs;
using Infraestructure.Utils.Dto;

namespace Service.Interfaces
{
    public interface IMetaViewService
    {
        /// <summary>
        /// Definición de método para todos los registros
        /// </summary>
        /// <returns>Objeto MetaDto</returns>
        Task<ResponseWrapper<IEnumerable<MetaDto>>> GetAll();

        /// <summary>
        /// Definición de método para obtener un registro por su identificador
        /// </summary>
        /// <param name="id">Identificador de la meta</param>
        /// <returns>Objeto MetaDto</returns>
        Task<MetaDto> GetById(int id);
    }
}
