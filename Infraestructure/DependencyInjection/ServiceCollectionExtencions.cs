using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace Infraestructure.DependencyInjection
{
    public static class ServiceCollectionExtencions
    {

        /// <summary>
        /// Metodo para confirarar el contexte de la base de datos de SQL Server
        /// </summary>
        /// <param name="services">Extencion de collección de servicios</param>
        /// <param name="connectionString">Cadena de conexion de la base de datos</param>
        /// <returns>Collecion de servicios</returns>
        public static IServiceCollection AddSqlServerDbContext(this IServiceCollection services, string connectionString)
        {
            //Configurar contexto de base de datos
            //Refactor later
            services.AddDbContext<TodoDbContext>(options =>
                    options.UseSqlServer(connectionString));

            return services;
        }
    }
} 