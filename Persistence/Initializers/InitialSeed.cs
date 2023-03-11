using Domain.Entities;

namespace Persistence.Initializers
{
    public static class InitialSeed
    {
        public static void seed(TodoDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Metas.Any()) return;

            ///Se inserta datos para pruebas
            var metas = new List<Meta> {
                new Meta
                {
                    Nombre = "Meta 1",
                    FechaCreacion = DateTime.Now,
                    Tareas = {
                            new Tarea{ Nombre = "Tarea 1", Estado = Domain.Enums.EstadoTarea.Completada, FechaCreacion = DateTime.Now, },
                            new Tarea{ Nombre = "Tarea 2", Estado = Domain.Enums.EstadoTarea.Completada, FechaCreacion = DateTime.Now, EsImportante = true },
                            new Tarea{ Nombre = "Tarea 3", EsImportante = true, FechaCreacion = DateTime.Now, },
                            new Tarea{ Nombre = "Tarea 4", FechaCreacion = DateTime.Now, }
                        }
                },
                new Meta
                {
                    Nombre = "Meta 2",
                    FechaCreacion = DateTime.Now,
                    Tareas = {
                        new Tarea { Nombre = "Tarea 1", FechaCreacion = DateTime.Now },
                        new Tarea { Nombre = "Tarea 2" ,EsImportante = true, FechaCreacion = DateTime.Now },
                        new Tarea { Nombre = "Tarea 3", FechaCreacion = DateTime.Now }
                    }
                },
                new Meta
                {
                    Nombre = "Meta 3",
                    FechaCreacion = DateTime.Now,
                    Tareas = {
                        new Tarea(){ Nombre = "Tarea 1", Estado = Domain.Enums.EstadoTarea.Abierta, FechaCreacion = DateTime.Now },
                        new Tarea(){ Nombre = "Tarea 2", Estado = Domain.Enums.EstadoTarea.Abierta, FechaCreacion = DateTime.Now },
                        new Tarea(){ Nombre = "Tarea 3", Estado = Domain.Enums.EstadoTarea.Completada, FechaCreacion = DateTime.Now }
                    }
                },
                new Meta
                {
                    Nombre = "Meta 4",
                    FechaCreacion = DateTime.Now
                },
                new Meta
                {
                    Nombre = "Meta 5",
                    Tareas = {
                        new Tarea { Nombre = "Tarea 1", Estado = Domain.Enums.EstadoTarea.Completada, EsImportante = true, FechaCreacion = DateTime.Now },
                        new Tarea { Nombre = "Tarea 1", Estado = Domain.Enums.EstadoTarea.Completada, FechaCreacion = DateTime.Now }
                    }
                }};

            context.Metas.AddRange(metas);

            context.SaveChanges();
        }
    }
}
