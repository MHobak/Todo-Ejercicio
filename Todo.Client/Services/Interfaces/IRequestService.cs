namespace Todo.Client.Services.Interfaces
{
    public interface IRequestService<T>
    {
        /// <summary>
        /// Método para obtener registros
        /// </summary>
        /// <param name="route">Ruta de la api</param>
        /// <returns>Respuesta de la api</returns>
        Task<List<T>> Get();

        /// <summary>
        /// Método para crear un nuevo registro
        /// </summary>
        /// <param name="TValue">Registro a crear</param>
        /// <param name="route">Ruta del método de la api</param>
        /// <returns>Registro creado</returns>
        Task<T>Create(T value);
    }
}