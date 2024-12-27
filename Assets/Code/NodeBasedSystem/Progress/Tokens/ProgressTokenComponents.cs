using Code.NodeBasedSystem.Progress.Datas;
using Newtonsoft.Json;
using NodeBasedSystem.Nodes;
using NodeBasedSystem.Nodes.Attributes;
using System;

namespace Code.NodeBasedSystem.ProgressNodeComponents
{
    [NodeSystem, NodeComponent("Добавить токен" ,"#56a6f0")]
    public class AddTokenComponent : INodeEventComponent { public string Value; }
    
    [NodeSystem, NodeComponent("Удалить токен" ,"#4151e0")]
    public class RemoveTokenComponent : INodeEventComponent { public string Value; }
    
    [NodeSystem, NodeComponent("Ресурсы. Добавить деньги", "#4151e0")]
    public class AddMoneyComponent : INodeEventComponent { public int Value; }
    
    [NodeSystem, NodeComponent("Ресурсы. Вычесть деньги", "#8141e0")]
    public class RemoveMoneyComponent : INodeEventComponent { public int Value; }
    
    [NodeSystem, NodeComponent("Ресурсы. Добавить энергию", "#4151e0")]
    public class AddVolitionComponent : INodeEventComponent { public int Value; }
    
    [NodeSystem, NodeComponent("Ресурсы. Вычесть энергию", "#8141e0")]
    public class RemoveVolitionComponent : INodeEventComponent { public int Value; }
    
    [NodeSystem, NodeComponent("Ресурсы. Добавить рейтинг", "#4151e0")]
    public class AddRatingComponent : INodeEventComponent { public float Value; }
    
    [NodeSystem, NodeComponent("Ресурсы. Вычесть рейтинг", "#8141e0")]
    public class RemoveRatingComponent : INodeEventComponent { public float Value; }
    
    [NodeSystem, NodeComponent("Ресурсы. Добавить бензин", "#4151e0")]
    public class AddBenzineComponent : INodeEventComponent { public int Value; }
    
    [NodeSystem, NodeComponent("Ресурсы. Вычесть бензин", "#8141e0")]
    public class RemoveBenzineComponent : INodeEventComponent { public int Value; }
    
    [NodeSystem, NodeComponent("Добавить предмет", "#b941e0"), Serializable]
    public class AddItemComponent : INodeEventComponent { public PlayerItemRequest Value = new(); }
    
    [NodeSystem, NodeComponent("Удалить предмет", "#b941e0"), Serializable]
    public class RemoveItemComponent : INodeEventComponent { public PlayerItemRequest Value = new(); }
}
