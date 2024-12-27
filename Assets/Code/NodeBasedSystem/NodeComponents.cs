using System.Collections.Generic;
using Code.Common.UnityStructs;
using Code.NodeBasedSystem.Core.Conditions;
using NodeBasedSystem.Nodes.Attributes;

namespace NodeBasedSystem.Nodes
{
    [NodeSystem] public class NodeId : INodeComponent { public string Value; }
    [NodeSystem] public class Node : INodeComponent { public ENodeType Value; }
    [NodeSystem] public class NextNodes : INodeComponent { public List<ConditionedNode> Value; }
    [NodeSystem] public class NodePosition : INodeComponent { public Vector2Data Value; }
    [NodeSystem] public class PlayingComponent : INodeComponent { }
    [NodeSystem] public class PlayedComponent : INodeComponent { }
    [NodeSystem] public class GraphIDComponent : INodeComponent { public string Value; }

    [NodeSystem, NodeComponent("Стратовая нода", "#228B22")] 
    public class StartNodeComponent : INodeEventComponent { }

    [NodeSystem, NodeComponent("Таймер автоскипа", "#2F4F4F")] 
    public class SkipTimerNodeComponent : INodeEventComponent { public float Value; }
}