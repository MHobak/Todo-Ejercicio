using System.Text.Json;

namespace Todo.Client.Utils
{
    public static class ObjectCloner
    {
        public static T? Clone<T>(T obj)
        {
            var jsonObj = JsonSerializer.Serialize(obj);
            var newObject = JsonSerializer.Deserialize<T>(jsonObj);
            return newObject;
        }
    }
}