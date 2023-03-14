using Microsoft.EntityFrameworkCore;
using Persistence.Interfaces.Generic;
using System.Linq.Expressions;

namespace Persistence.Implementations.Generic
{
    public class GenericRepository<T, TKey> : IGenericRepository<T, TKey> where T : class
    {
        #region Propiedades        
        private readonly IUnitOfWork unitOfWork;
        internal DbSet<T> _dbSet;


        /// <summary>
        /// Implementación de métod que obtiene todos los registros
        /// de tipo T de la entidad de forma síncrona
        /// </summary>
        /// <returns>IQueryable de tipo T </returns>
        public IQueryable<T> GetTable()
        {
            var query = unitOfWork.Context.Set<T>().AsQueryable();
            return query;
        }

        #endregion

        /// <summary>
        /// Constructor de la clase, se inyecta UnitOfWork e inicializa para 
        /// ser asignado a la variable privada _unitOfWork
        /// 
        /// Se inicializa la variable _dbSet como un DbSet de tipo T en el Contexto.
        /// </summary>
        /// <param name="_unitOfWork"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public GenericRepository(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork ?? throw new ArgumentNullException(nameof(_unitOfWork));
            this._dbSet = this.unitOfWork.Context.Set<T>();
        }

        #region Implementación de métodos de IGenericRepository

        /// <summary>
        /// Implemetación de método que elimina un elemento 
        /// de tipo T de la entidad.
        /// </summary>
        /// <param name="obj">Objeto de tipo T que se eliminará</param>
        public void Delete(T obj)
        {
            _dbSet.Remove(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereCondition"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> whereCondition = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = unitOfWork.Context.Set<T>();

            if (whereCondition != null)
            {
                query = query.Where(whereCondition);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetById(int _id)//Probar el null 
        {
            //var entity = _dbSet.Find(id);
            //_unitOfWork.Context.Entry(_dbSet).State = EntityState.Detached;
            //return entity; 
            return await _dbSet.FindAsync(_id);
        }

        /// <summary>
        /// Implementación del método que inserta un registro
        /// de tipo T.
        /// </summary>
        /// <param name="obj">Objeto de tipo T que se insertará</param>
        public void Insert(T obj)
        {
            this._dbSet.Add(obj);
        }

        /// <summary>
        /// Implementación de método para insertar una colección de tipo T.
        /// </summary>
        /// <param name="_objs">Colección de objetos de tipo T que se insertará.</param>
        public void Insert(IEnumerable<T> _objs)
        {
            this._dbSet.AddRange(_objs);
        }

        /// <summary>
        /// Implementación de método que actualiza un registro 
        /// de tipo T.
        /// </summary>
        /// <param name="obj">Objeto de tipo T que se actualizará</param>
        public void Update(T _obj)
        {
            this._dbSet.Update(_obj);
        }

        /// <summary>
        /// Verificar si existe un registro en el repositorio
        /// </summary>
        /// <param name="whereCondition">Criterios de consulta del repositorio</param>
        /// <returns>Bandera que determina si existe o no datos en el repositorio</returns>
        public async Task<bool> Any(Expression<Func<T, bool>>? whereCondition = null) //, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = unitOfWork.Context.Set<T>();

            if (whereCondition != null)
            {
                return await query.AnyAsync(whereCondition);
            }

            return await query.AnyAsync();
        }
        #endregion

    }
}
