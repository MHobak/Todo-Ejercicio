using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

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
            //Se configura la creación de tablas
            #region MetaEntity

            //Se configuran los constraints de los campos de tarea
            builder.Entity<Meta>().ToTable("Meta", t => t.HasComment("Tabla de Metas"))
               .HasIndex(m => m.Id)
               .IsUnique();

            builder.Entity<Meta>()
                .Property(m => m.Nombre)
                .IsRequired()
                .HasMaxLength(80)
                .HasComment("Nombre de la meta");

            builder.Entity<Meta>()
                .Property(m => m.FechaCreacion)
                .IsRequired()
                .HasDefaultValue(DateTime.Now)
                .HasComment("Fecha de creación de la meta");

            #endregion

            #region TareaEntity

            //Se configuran los constraints de los campos de tarea
            builder.Entity<Tarea>().ToTable("Tarea", t => t.HasComment("Tabla de Tareas"))
                .HasIndex(t => t.Id)
                .IsUnique();

            //Se configura llave foranea con metas
            builder.Entity<Tarea>()
                .HasOne(m => m.Meta)
                .WithMany(t => t.Tareas)
                .HasForeignKey(t => t.MetaId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Tarea>()
                .Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(80)
                .HasComment("Nombre de la tarea");

            builder.Entity<Tarea>()
                .Property(t => t.FechaCreacion)
                .IsRequired()
                .HasDefaultValue(DateTime.Now)
                .HasComment("Fecha de creación de la tarea");

            builder.Entity<Tarea>()
                .Property(t => t.EsImportante)
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("Indicador de importancia de una tarea");
            
            //Este es un enum que se guarda como varchar
            builder.Entity<Tarea>()
                .Property(b => b.Estado)
                .IsRequired()
                .HasMaxLength(100)
                .HasDefaultValue(EstadoTarea.Abierta)
                .HasComment("Estado de completado de la tarea") //Abierta o Activa
                .HasConversion<string>();

            #endregion
        }
    }
}