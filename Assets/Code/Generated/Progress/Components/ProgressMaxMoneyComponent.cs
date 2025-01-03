//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class ProgressMatcher {

    static Entitas.IMatcher<ProgressEntity> _matcherMaxMoney;

    public static Entitas.IMatcher<ProgressEntity> MaxMoney {
        get {
            if (_matcherMaxMoney == null) {
                var matcher = (Entitas.Matcher<ProgressEntity>)Entitas.Matcher<ProgressEntity>.AllOf(ProgressComponentsLookup.MaxMoney);
                matcher.componentNames = ProgressComponentsLookup.componentNames;
                _matcherMaxMoney = matcher;
            }

            return _matcherMaxMoney;
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
public partial class ProgressEntity {

    public Code.Progress.PlayerStorage.MaxMoneyComponent maxMoney { get { return (Code.Progress.PlayerStorage.MaxMoneyComponent)GetComponent(ProgressComponentsLookup.MaxMoney); } }
    public int MaxMoney { get { return maxMoney.Value; } }
    public bool hasMaxMoney { get { return HasComponent(ProgressComponentsLookup.MaxMoney); } }

    public ProgressEntity AddMaxMoney(int newValue) {
        var index = ProgressComponentsLookup.MaxMoney;
        var component = (Code.Progress.PlayerStorage.MaxMoneyComponent)CreateComponent(index, typeof(Code.Progress.PlayerStorage.MaxMoneyComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public ProgressEntity ReplaceMaxMoney(int newValue) {
        var index = ProgressComponentsLookup.MaxMoney;
        var component = (Code.Progress.PlayerStorage.MaxMoneyComponent)CreateComponent(index, typeof(Code.Progress.PlayerStorage.MaxMoneyComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public ProgressEntity RemoveMaxMoney() {
        RemoveComponent(ProgressComponentsLookup.MaxMoney);
        return this;
    }
}
