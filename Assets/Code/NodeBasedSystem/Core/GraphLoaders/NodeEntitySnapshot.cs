using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NodeBasedSystem.Nodes;

namespace Code.NodeBasedSystem.GraphLoaders
{
    public class NodeEntitySnapshot 
    {
        [JsonProperty("c")] public List<INodeComponent> components;

        public NodeEntitySnapshot()
        {
            components = new List<INodeComponent>();
        }
    }

    public static class NodeGraphDataExtensions
    {
        public static TComponent FindComponent<TComponent>(this NodeEntitySnapshot entity)
            where TComponent : class, INodeComponent
        {
            return entity.components.FirstOrDefault(component => component is TComponent) as TComponent;
        }
        
        public static IEnumerable<TComponent> FindComponents<TComponent>(this NodeEntitySnapshot entity)
            where TComponent : class, INodeComponent
        {
            return entity.components
                .Where(component => component is TComponent)
                .Cast<TComponent>();
        }

        public static IEnumerable<NodeEntitySnapshot> GetNodesWithType(this NodeGraphSavedData data, ENodeType nodeType)
        {
            return data.nodeSnapshots
                .Where(c => 
                    c.FindComponent<Node>().Value == nodeType);
        }
    }
}
