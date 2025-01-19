using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using UnityEngine;

namespace Code.Common.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJson(this object self) =>
            JsonConvert.SerializeObject(self, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
                Error = HandleSerializationError
            });

        private static void HandleSerializationError(object sender, ErrorEventArgs e)
        {
            var currentError = e.ErrorContext.Error.Message;
            Debug.LogError($"[{nameof(HandleSerializationError)}] (De-)Serialization error: {currentError}");
            e.ErrorContext.Handled = true;
        }

        public static T FromJson<T>(this string json) =>
            JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
                Error = HandleSerializationError
            });
    }
}
