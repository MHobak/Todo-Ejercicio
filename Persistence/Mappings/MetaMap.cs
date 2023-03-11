using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings
{
    public class MetaMap : IEntityTypeConfiguration<Meta>
    {
        public void Configure(EntityTypeBuilder<Meta> builder)
        {
            //Se configura la creación de tablas
            builder.ToTable("Meta", t => t.HasComment("Tabla de Metas"))
               .HasIndex(m => m.Id)
               .IsUnique();

            //Se configuran los constraints de los campos de tarea
            builder.Property(m => m.Nombre)
                .IsRequired()
                .HasMaxLength(80)
                .HasComment("Nombre de la meta");

            builder.Property(m => m.FechaCreacion)
                .IsRequired()
                .HasComment("Fecha de creación de la meta");
        }
    }
}