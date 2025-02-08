using Code.Common.Entity;
using Code.Common.Extensions;
using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Features.Stack.Systems
{
    [UsedImplicitly]
    public class ItemDeckInitializeSystem : IInitializeSystem
    {
        public void Initialize()
        {
            CreateEntity.Empty()
                .AddCardStack(EStackType.ItemDeck)
                .AddStackMaxCount(3)
                .AddViewPath("ItemDeck")
                .AddWorldPosition(new Vector3(-7.5f, 0.5f, 0f)); //ToDo: fill from config
        }
    }
}