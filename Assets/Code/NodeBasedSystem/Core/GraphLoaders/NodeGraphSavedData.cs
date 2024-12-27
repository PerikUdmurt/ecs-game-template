using System.Collections.Generic;
using Newtonsoft.Json;

namespace Code.NodeBasedSystem.GraphLoaders
{
    public class NodeGraphSavedData
    {
        [JsonProperty("nodes")] public List<NodeEntitySnapshot> nodeSnapshots;

        public NodeGraphSavedData()
        {
            nodeSnapshots = new List<NodeEntitySnapshot>();
        }
    }
}