using Entitas;
using NodeBasedSystem.Nodes;
using NodeBasedSystem.Nodes.Attributes;

namespace Code.NodeBasedSystem
{
    [NodeSystem] public class NextNodeRequestComponent : IComponent { public string Value; }
    [NodeSystem] public class NextNodeRequestGraphIdComponent : IComponent { public string Value; }
    
    [NodeComponent("Core. Event", "#75ff00"), NodeSystem]
    public class NodeEventComponent : INodeComponent { public string Value; }
}