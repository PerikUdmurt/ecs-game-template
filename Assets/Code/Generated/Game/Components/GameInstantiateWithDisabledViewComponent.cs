//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherInstantiateWithDisabledView;

    public static Entitas.IMatcher<GameEntity> InstantiateWithDisabledView {
        get {
            if (_matcherInstantiateWithDisabledView == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.InstantiateWithDisabledView);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInstantiateWithDisabledView = matcher;
            }

            return _matcherInstantiateWithDisabledView;
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
public partial class GameEntity {

    static readonly Code.Common.InstantiateWithDisabledView instantiateWithDisabledViewComponent = new Code.Common.InstantiateWithDisabledView();

    public bool isInstantiateWithDisabledView {
        get { return HasComponent(GameComponentsLookup.InstantiateWithDisabledView); }
        set {
            if (value != isInstantiateWithDisabledView) {
                var index = GameComponentsLookup.InstantiateWithDisabledView;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : instantiateWithDisabledViewComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
