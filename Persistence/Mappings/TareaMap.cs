using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings
{
    public class TareaMap : IEntityTypeConfiguration<Tarea>
    {
        public void Configure(EntityTypeBuilder<Tarea> builder)
        {
            //Se configuran los constraints de los campos de tarea
            builder.ToTable("Tarea", t => t.HasComment("Tabla de Tareas"))
                .HasIndex(t => t.Id)
                .IsUnique();

            //Se configura llave foranea con metas
            builder.HasOne(m => m.Meta)
                .WithMany(t => t.Tareas)
                .HasForeignKey(t => t.MetaId)
                .OnDelete(DeleteBehavior.ClientCascade); //Habilitar el borrado en casacada

            builder.Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(80)
                .HasComment("Nombre de la tarea");

            builder.Property(t => t.FechaCreacion)
                .IsRequired()
                .HasDefaultValue(DateTime.Now)
                .HasComment("Fecha de creación de la tarea");

            builder.Property(t => t.EsImportante)
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("Indicador de importancia de una tarea");

            //Este es un enum que se guarda como varchar
            builder.Property(b => b.Estado)
                .IsRequired()
                .HasMaxLength(100)
                .HasDefaultValue(EstadoTarea.Abierta)
                .HasComment("Estado de completado de la tarea") //Abierta o Activa
                .HasConversion<string>();
        }
    }
}
