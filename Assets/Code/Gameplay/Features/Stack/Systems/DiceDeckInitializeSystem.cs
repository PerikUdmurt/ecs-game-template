using Code.Common.Entity;
using Code.Common.Extensions;
using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Features.Stack.Systems
{
    [UsedImplicitly]
    public class DiceDeckInitializeSystem : IInitializeSystem
    {
        public void Initialize()
        {
            CreateEntity.Empty()
                .AddCardStack(EStackType.DiceDeck)
                .AddViewPath("DiceDeck")
                .AddWorldPosition(new Vector3(-7.5f, -2.0f, 0f)); //ToDo: fill from config
        }
    }
}