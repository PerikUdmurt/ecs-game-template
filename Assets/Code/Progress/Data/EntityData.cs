using System.Collections.Generic;
using Newtonsoft.Json;

namespace Code.Progress.Data
{
    public class EntityData
    {
        [JsonProperty("es")] public List<EntitySnapshot> entitySnapshots;

        public EntityData()
        {
            this.entitySnapshots = new();
        }
    }
}