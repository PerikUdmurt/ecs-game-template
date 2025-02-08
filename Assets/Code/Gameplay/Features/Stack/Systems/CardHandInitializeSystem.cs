using Code.Common.Entity;
using Code.Common.Extensions;
using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Features.Stack.Systems
{
    [UsedImplicitly]
    public class CardHandInitializeSystem : IInitializeSystem
    {
        public void Initialize()
        {
            CreateEntity.Empty()
                .AddCardStack(EStackType.Hand)
                .AddStackMaxCount(5) //ToDo: Set from config
                .AddHorizontalLayout(new Vector3(1.7f, 0f, 0f))
                .AddWorldPosition(new Vector3(-3.5f, -2f, 0f));
        }
    }
}
