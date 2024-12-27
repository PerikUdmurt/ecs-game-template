using System;
using System.Collections.Generic;
using Code.Progress.PlayerStorage;
using Newtonsoft.Json;

namespace Code.Progress.Data
{
    public class EntitySnapshot
    {
        [JsonProperty("c")] public List<IProgressComponent> components;
    }
}