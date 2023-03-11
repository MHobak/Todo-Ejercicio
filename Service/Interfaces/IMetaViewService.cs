using Domain.DTOs;

namespace Service.Interfaces
{
    public interface IMetaViewService
    {
        /// <summary>
        /// Definición de método para todos los registros
        /// </summary>
        /// <returns>Objeto MetaDto</returns>
        Task<IEnumerable<MetaDto>> GetAll();
    }
}
