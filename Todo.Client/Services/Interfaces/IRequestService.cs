using Infraestructure.Utils.Dto;

namespace Todo.Client.Services.Interfaces
{
    public interface IRequestService<T>
    {
        /// <summary>
        /// Método para obtener registros
        /// </summary>
        /// <returns>Respuesta de la api</returns>
        Task<ResponseWrapper<List<T>>> Get(int pageNumber, int pageSize);

        /// <summary>
        /// Método para consultar un registro por id
        /// </summary>
        /// <param name="id">id del registro a consultar</param>
        /// <returns>Registro</returns>
        Task<T>GetById(int id);

        /// <summary>
        /// Método para crear un nuevo registro
        /// </summary>
        /// <param name="T">Registro a crear</param>
        /// <returns>Registro creado</returns>
        Task<T>Create(T value);

        /// <summary>
        /// Metodo para eliminar meta
        /// </summary>
        /// <param name="Id">Identificador de la meta</param>
        /// <returns>Task</returns>
        Task Delete(int Id);

        /// <summary>
        /// Método para editar un registro
        /// </summary>
        /// <param name="T">Registro a actualizar</param>
        /// <returns>Registro actualizado</returns>
        Task<T>Update(T value);
    }
}