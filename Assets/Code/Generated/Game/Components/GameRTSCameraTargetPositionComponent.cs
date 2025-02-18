//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherRTSCameraTargetPosition;

    public static Entitas.IMatcher<GameEntity> RTSCameraTargetPosition {
        get {
            if (_matcherRTSCameraTargetPosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RTSCameraTargetPosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRTSCameraTargetPosition = matcher;
            }

            return _matcherRTSCameraTargetPosition;
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

    public Code.Gameplay.Features.Camera.RTS.RTSCameraTargetPosition rTSCameraTargetPosition { get { return (Code.Gameplay.Features.Camera.RTS.RTSCameraTargetPosition)GetComponent(GameComponentsLookup.RTSCameraTargetPosition); } }
    public UnityEngine.Vector3 RTSCameraTargetPosition { get { return rTSCameraTargetPosition.Value; } }
    public bool hasRTSCameraTargetPosition { get { return HasComponent(GameComponentsLookup.RTSCameraTargetPosition); } }

    public GameEntity AddRTSCameraTargetPosition(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.RTSCameraTargetPosition;
        var component = (Code.Gameplay.Features.Camera.RTS.RTSCameraTargetPosition)CreateComponent(index, typeof(Code.Gameplay.Features.Camera.RTS.RTSCameraTargetPosition));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceRTSCameraTargetPosition(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.RTSCameraTargetPosition;
        var component = (Code.Gameplay.Features.Camera.RTS.RTSCameraTargetPosition)CreateComponent(index, typeof(Code.Gameplay.Features.Camera.RTS.RTSCameraTargetPosition));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveRTSCameraTargetPosition() {
        RemoveComponent(GameComponentsLookup.RTSCameraTargetPosition);
        return this;
    }
}
