//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAssetIsLoading;

    public static Entitas.IMatcher<GameEntity> AssetIsLoading {
        get {
            if (_matcherAssetIsLoading == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AssetIsLoading);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAssetIsLoading = matcher;
            }

            return _matcherAssetIsLoading;
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

    static readonly Code.Infrastructures.View.AssetIsLoading assetIsLoadingComponent = new Code.Infrastructures.View.AssetIsLoading();

    public bool isAssetIsLoading {
        get { return HasComponent(GameComponentsLookup.AssetIsLoading); }
        set {
            if (value != isAssetIsLoading) {
                var index = GameComponentsLookup.AssetIsLoading;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : assetIsLoadingComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}