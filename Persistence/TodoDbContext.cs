using Domain.Entities;
using Domain.Views;
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

        //Vista
        public DbSet<MetaView> MetaView { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Aplicar configuracion de la tabla de metas
            builder.ApplyConfiguration(new MetaMap());

            //Aplicar configuracion de la tabla de tareas
            builder.ApplyConfiguration(new TareaMap());

            ///Registrar la vista
            builder
            .Entity<MetaView>()
            .ToView(nameof(MetaView))
            .HasKey(t => t.Id);
        }
    }
}