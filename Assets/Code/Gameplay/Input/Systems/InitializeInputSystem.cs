using Code.Common.Entity;
using Entitas;
using JetBrains.Annotations;

namespace Code.Gameplay.Input.Systems
{
    [UsedImplicitly]
    public class InitializeInputSystem : IInitializeSystem
    {
        public void Initialize()
        {
            CreateEntity.Empty().isInput = true;
        }
    }
}