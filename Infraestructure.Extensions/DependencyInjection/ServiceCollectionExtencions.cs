using AutoMapper;
using Domain.DTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Persistence.Implementations.Generic;
using Persistence.Implementations.Repository;
using Persistence.Interfaces.Generic;
using Persistence.Interfaces.Repository;
using Service.Implementations;
using Service.Interfaces;
using Service.Validators;

namespace Infraestructure.Extensions.DependencyInjection
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
            services.AddDbContext<TodoDbContext>(options =>
                    options.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddRepositoryDependency(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IMetaRepository, MetaRepository>();
            services.AddTransient<ITareaRepository, TareaRepository>();
            services.AddTransient<IMetaViewRepository, MetaViewRepository>();

            return services;
        }

        public static IServiceCollection AddServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<IMetaService, MetaService>();
            services.AddScoped<IMetaViewService, MetaViewService>();

            return services;
        }

        public static IServiceCollection AddValidatorsDependency(this IServiceCollection services)
        {
            services.AddTransient<IValidator<MetaDto>, MetaValidator>();

            return services;
        }

        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps("Infraestructure");
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);
            return services;
        }

        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                //Solo para el front
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            return services;
        }
    }
} 