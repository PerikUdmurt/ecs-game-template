using System.Collections.Generic;
using Code.Common.UnityStructs;
using Code.NodeBasedSystem.Core.Conditions;
using Code.NodeBasedSystem.Core.NodeGraphPlayer;
using Code.NodeBasedSystem.GraphPlayer;
using NodeBasedSystem.Nodes.Attributes;

namespace NodeBasedSystem.Nodes
{
    [NodeSystem] public class NodeId : INodeComponent { public string Value; }
    [NodeSystem] public class Node : INodeComponent { public ENodeType Value; }
    [NodeSystem] public class NextNodes : INodeComponent { public List<ConditionNodeLink> Value; }
    [NodeSystem] public class NextChoices : INodeComponent { public List<ChoiceNodeLink> Value; }
    [NodeSystem] public class NodePosition : INodeComponent { public Vector2Data Value; }
    [NodeSystem] public class PlayingComponent : INodeComponent { }
    [NodeSystem] public class PlayedComponent : INodeComponent { }
    [NodeSystem] public class GraphIDComponent : INodeComponent { public string Value; }
    [NodeSystem] public class GraphPlayerComponent : INodeComponent { public NodeGraphPlayer Value; }

    [NodeSystem, NodeComponent("Core. StartNode", "#228B22")]
    public class StartNodeComponent : INodeEventComponent { }

    [NodeSystem, NodeComponent("Core. AutoskipTimer", "#2F4F4F")] 
    public class SkipTimerNodeComponent : INodeEventComponent { public float Value; }
    
    [NodeSystem, NodeComponent("Core. Play Graph", "#FF2D00")] 
    public class PlayNextGraphComponent : INodeEventComponent { public string Value; }
}