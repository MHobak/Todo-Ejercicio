using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Mappings;

namespace Persistence
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
        }

        public DbSet<Meta> Metas { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Aplicar configuracion de la tabla de metas
            builder.ApplyConfiguration(new MetaMap());

            //Aplicar configuracion de la tabla de tareas
            builder.ApplyConfiguration(new TareaMap());
        }
    }
}