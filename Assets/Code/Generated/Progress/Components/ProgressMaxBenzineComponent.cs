//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class ProgressMatcher {

    static Entitas.IMatcher<ProgressEntity> _matcherMaxBenzine;

    public static Entitas.IMatcher<ProgressEntity> MaxBenzine {
        get {
            if (_matcherMaxBenzine == null) {
                var matcher = (Entitas.Matcher<ProgressEntity>)Entitas.Matcher<ProgressEntity>.AllOf(ProgressComponentsLookup.MaxBenzine);
                matcher.componentNames = ProgressComponentsLookup.componentNames;
                _matcherMaxBenzine = matcher;
            }

            return _matcherMaxBenzine;
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

    public Code.Progress.PlayerStorage.MaxBenzineComponent maxBenzine { get { return (Code.Progress.PlayerStorage.MaxBenzineComponent)GetComponent(ProgressComponentsLookup.MaxBenzine); } }
    public int MaxBenzine { get { return maxBenzine.Value; } }
    public bool hasMaxBenzine { get { return HasComponent(ProgressComponentsLookup.MaxBenzine); } }

    public ProgressEntity AddMaxBenzine(int newValue) {
        var index = ProgressComponentsLookup.MaxBenzine;
        var component = (Code.Progress.PlayerStorage.MaxBenzineComponent)CreateComponent(index, typeof(Code.Progress.PlayerStorage.MaxBenzineComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public ProgressEntity ReplaceMaxBenzine(int newValue) {
        var index = ProgressComponentsLookup.MaxBenzine;
        var component = (Code.Progress.PlayerStorage.MaxBenzineComponent)CreateComponent(index, typeof(Code.Progress.PlayerStorage.MaxBenzineComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public ProgressEntity RemoveMaxBenzine() {
        RemoveComponent(ProgressComponentsLookup.MaxBenzine);
        return this;
    }
}