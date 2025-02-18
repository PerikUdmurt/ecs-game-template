using Code.Common.Destruct;
using Code.Gameplay.DialogueSystem.Systems;
using Code.Gameplay.Features.Battle;
using Code.Gameplay.Features.Camera;
using Code.Gameplay.Features.Cards;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Stack;
using Code.Gameplay.Features.Tiles;
using Code.Gameplay.Input;
using Code.Gameplay.Test;
using Code.Infrastructures.Factories;
using Code.Infrastructures.View.Systems;
using Code.NodeBasedSystem;
using Code.NodeBasedSystem.Progress;
using JetBrains.Annotations;

namespace Code.Gameplay
{
    [UsedImplicitly]
    public class GameplayFeature : Feature
    {
        public GameplayFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<BindViewFeature>());
            Add(systemFactory.Create<DialogueSystemFeature>());
            Add(systemFactory.Create<NodeSystemFeature>());
            Add(systemFactory.Create<MovementFeature>());
            Add(systemFactory.Create<StorageFeature>());
            Add(systemFactory.Create<InputFeature>());
            Add(systemFactory.Create<ProcessDestuctedFeature>());
            Add(systemFactory.Create<CardDecksFeature>());
            Add(systemFactory.Create<BattleFeature>());
            Add(systemFactory.Create<CameraFeature>());
            Add(systemFactory.Create<TilesFeature>());
            
            Add(systemFactory.Create<GameplayTestFeature>());
        }
    }
}