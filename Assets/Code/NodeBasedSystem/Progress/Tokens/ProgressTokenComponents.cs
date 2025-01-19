using Code.NodeBasedSystem.Progress.Datas;
using Newtonsoft.Json;
using NodeBasedSystem.Nodes;
using NodeBasedSystem.Nodes.Attributes;
using System;

namespace Code.NodeBasedSystem.ProgressNodeComponents
{
    [NodeSystem, NodeComponent("Progress. Add Token" ,"#56a6f0")]
    public class AddTokenComponent : INodeEventComponent { public string Value; }
    
    [NodeSystem, NodeComponent("Progress. Remove Token" ,"#4151e0")]
    public class RemoveTokenComponent : INodeEventComponent { public string Value; }
    
    [NodeSystem, NodeComponent("Progress. Add Money", "#4151e0")]
    public class AddMoneyComponent : INodeEventComponent { public int Value; }
    
    [NodeSystem, NodeComponent("Progress. Remove Money", "#8141e0")]
    public class RemoveMoneyComponent : INodeEventComponent { public int Value; }
    
    [NodeSystem, NodeComponent("Progress. Add Energy", "#4151e0")]
    public class AddVolitionComponent : INodeEventComponent { public int Value; }
    
    [NodeSystem, NodeComponent("Progress. Remove Energy", "#8141e0")]
    public class RemoveVolitionComponent : INodeEventComponent { public int Value; }
    
    [NodeSystem, NodeComponent("Progress. Add Rating", "#4151e0")]
    public class AddRatingComponent : INodeEventComponent { public float Value; }
    
    [NodeSystem, NodeComponent("Progress. Remove Rating", "#8141e0")]
    public class RemoveRatingComponent : INodeEventComponent { public float Value; }
    
    [NodeSystem, NodeComponent("Progress. Add Benzine", "#4151e0")]
    public class AddBenzineComponent : INodeEventComponent { public int Value; }
    
    [NodeSystem, NodeComponent("Progress. Remove Benzine", "#8141e0")]
    public class RemoveBenzineComponent : INodeEventComponent { public int Value; }
    
    [NodeSystem, NodeComponent("Progress. Add Item", "#b941e0"), Serializable]
    public class AddItemComponent : INodeEventComponent { public PlayerItemRequest Value = new(); }
    
    [NodeSystem, NodeComponent("Progress. Remove Item", "#b941e0"), Serializable]
    public class RemoveItemComponent : INodeEventComponent { public PlayerItemRequest Value = new(); }
}
