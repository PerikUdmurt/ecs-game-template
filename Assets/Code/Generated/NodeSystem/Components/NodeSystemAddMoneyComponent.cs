//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class NodeSystemMatcher {

    static Entitas.IMatcher<NodeSystemEntity> _matcherAddMoney;

    public static Entitas.IMatcher<NodeSystemEntity> AddMoney {
        get {
            if (_matcherAddMoney == null) {
                var matcher = (Entitas.Matcher<NodeSystemEntity>)Entitas.Matcher<NodeSystemEntity>.AllOf(NodeSystemComponentsLookup.AddMoney);
                matcher.componentNames = NodeSystemComponentsLookup.componentNames;
                _matcherAddMoney = matcher;
            }

            return _matcherAddMoney;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class NodeSystemEntity {

    public Code.NodeBasedSystem.ProgressNodeComponents.AddMoneyComponent addMoney { get { return (Code.NodeBasedSystem.ProgressNodeComponents.AddMoneyComponent)GetComponent(NodeSystemComponentsLookup.AddMoney); } }
    public int AddMoney { get { return addMoney.Value; } }
    public bool hasAddMoney { get { return HasComponent(NodeSystemComponentsLookup.AddMoney); } }

    public NodeSystemEntity AddAddMoney(int newValue) {
        var index = NodeSystemComponentsLookup.AddMoney;
        var component = (Code.NodeBasedSystem.ProgressNodeComponents.AddMoneyComponent)CreateComponent(index, typeof(Code.NodeBasedSystem.ProgressNodeComponents.AddMoneyComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public NodeSystemEntity ReplaceAddMoney(int newValue) {
        var index = NodeSystemComponentsLookup.AddMoney;
        var component = (Code.NodeBasedSystem.ProgressNodeComponents.AddMoneyComponent)CreateComponent(index, typeof(Code.NodeBasedSystem.ProgressNodeComponents.AddMoneyComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public NodeSystemEntity RemoveAddMoney() {
        RemoveComponent(NodeSystemComponentsLookup.AddMoney);
        return this;
    }
}