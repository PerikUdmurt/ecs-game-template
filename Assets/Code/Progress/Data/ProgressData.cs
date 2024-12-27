using Newtonsoft.Json;

namespace Code.Progress.Data
{
    public class ProgressData
    {
        [JsonProperty("ed")] public EntityData data;

        public ProgressData()
        {
            data = new EntityData();
        }
    }
}