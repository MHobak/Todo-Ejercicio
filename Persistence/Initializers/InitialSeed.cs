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
                    Tareas = {
                            new Tarea{ Nombre = "Tarea 1", Estado = Domain.Enums.EstadoTarea.Completada },
                            new Tarea{ Nombre = "Tarea 2", Estado = Domain.Enums.EstadoTarea.Completada, EsImportante = true },
                            new Tarea{ Nombre = "Tarea 3", EsImportante = true },
                            new Tarea{ Nombre = "Tarea 4" }
                        }
                },
                new Meta
                {
                    Nombre = "Meta 2",
                    Tareas = {
                        new Tarea { Nombre = "Tarea 1"},
                        new Tarea { Nombre = "Tarea 2" ,EsImportante = true},
                        new Tarea { Nombre = "Tarea 3"}
                    }
                },
                new Meta
                {
                    Nombre = "Meta 3",
                    Tareas = {
                        new Tarea(){ Nombre = "Tarea 1", Estado = Domain.Enums.EstadoTarea.Abierta },
                        new Tarea(){ Nombre = "Tarea 2", Estado = Domain.Enums.EstadoTarea.Abierta },
                        new Tarea(){ Nombre = "Tarea 3", Estado = Domain.Enums.EstadoTarea.Completada }
                    }
                },
                new Meta
                {
                    Nombre = "Meta 4"
                },
                new Meta
                {
                    Nombre = "Meta 5",
                    Tareas = {
                        new Tarea { Nombre = "Tarea 1", Estado = Domain.Enums.EstadoTarea.Completada, EsImportante = true },
                        new Tarea { Nombre = "Tarea 1", Estado = Domain.Enums.EstadoTarea.Completada }
                    }
                }};

            context.Metas.AddRange(metas);

            context.SaveChanges();
        }
    }
}
