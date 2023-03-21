namespace Todo.Client.Utils
{
    public class ApiRoutes
    {
        public const string MetaRoute = "Meta";     
        public const string TareaRoute = "Tarea";     
        public const string MarcarTareaComoImportante = $"{TareaRoute}/EstablecerImportancia";
        public const string CompletarTareas = $"{TareaRoute}/Completar";
        public const string EliminarTareas = $"{TareaRoute}/DeleteMany";
    }
}