using System.Text.Json;

namespace WiredBrainCoffee.StorageApp.Entities
{
    public static class EntityExtensions
    {
        public static T? Copy<T>(this T itemTocopy) where T : IEntity
        {
            var json = JsonSerializer.Serialize<T>(itemTocopy);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
