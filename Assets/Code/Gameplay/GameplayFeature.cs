using Code.Common.Destruct;
using Code.Gameplay.DialogueSystem;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Input;
using Code.Infrastructures.Factories;
using Code.Infrastructures.View.Systems;
using Code.NodeBasedSystem;
using Code.NodeBasedSystem.Progress;

namespace Code.Gameplay
{
    public class GameplayFeature : Feature
    {
        public GameplayFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<NodeSystemFeature>());
            Add(systemFactory.Create<BindViewFeature>());
            Add(systemFactory.Create<DialogueSystemFeature>());
            Add(systemFactory.Create<MovementFeature>());
            Add(systemFactory.Create<StorageFeature>());
            Add(systemFactory.Create<InputFeature>());
            Add(systemFactory.Create<ProcessDestuctedFeature>());
        }
    }
}