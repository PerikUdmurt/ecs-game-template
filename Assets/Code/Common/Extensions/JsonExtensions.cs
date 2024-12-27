using Newtonsoft.Json;

namespace Code.Common.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJson(this object self) =>
            JsonConvert.SerializeObject(self, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
            });

        public static T FromJson<T>(this string json) =>
            JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
            });
    }
}
