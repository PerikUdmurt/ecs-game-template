using Entitas;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Common.Systems
{
    [UsedImplicitly]
    public class CleanupGameDestructedSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(64);

        public CleanupGameDestructedSystem(GameContext gameContext)
        {
            _entities = gameContext.GetGroup(GameMatcher.Destructed);
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
                entity.Destroy();
        }
    }

    [UsedImplicitly]
    public class CleanupGameDestructedViewsSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public CleanupGameDestructedViewsSystem(GameContext gameContext)
        {
            _entities = gameContext.GetGroup(
                GameMatcher.AllOf(
                GameMatcher.Destructed,
                GameMatcher.View));
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.View.ReleaseEntity();
                Object.Destroy(entity.View.gameObject);
            }
        }
    }
}