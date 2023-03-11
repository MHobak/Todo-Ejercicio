using System.Linq.Expressions;

namespace Persistence.Interfaces.Generic
{
    public interface IGenericRepository<T, TKey> where T : class
    {
        /// <summary>
        /// Definición de método para obtener 
        /// un elemento de tipo T por objeto identificador
        /// </summary>
        /// <param name="id">Identificador del registro de la entidad</param>
        /// <returns></returns>
        Task<T> GetById(int _Id);

        /// <summary>
        /// Definición de método para insertar un elemento de 
        /// tipo T
        /// </summary>
        /// <param name="obj">Objeto de tipo T que se insertará</param>
        void Insert(T _obj);

        /// <summary>
        /// Definición de método para registrar una colección de tipo T.
        /// </summary>
        /// <param name="objs">Colección de tipo T que se insertará.</param>
        void Insert(IEnumerable<T> objs);

        /// <summary>
        /// Definición de método para actualizar un elemento de
        /// tipo T
        /// </summary>
        /// <param name="obj">Objeto de tipo T que se actualizará</param>
        void Update(T obj);

        /// <summary>
        /// Definición de método para eliminar un elemento de
        /// tipo T
        /// </summary>
        /// <param name="obj">Objeto de tipo T que se eliminará</param>
        void Delete(T obj);

        /// <summary>
        /// Definición de método para consultar mediante una expresión o filtro
        /// </summary>
        /// <param name="whereCondition">Expresion para filtro</param>
        /// <param name="orderBy">Delegado para ordenamiento</param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> whereCondition = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        /// <summary>
        /// Definición de método para consultar la existencia de algun elemento
        /// </summary>
        /// <param name="whereCondition"></param>
        /// <returns></returns>
        Task<bool> Any(Expression<Func<T, bool>>? whereCondition = null);
    }
}
