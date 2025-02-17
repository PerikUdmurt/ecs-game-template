using System.Collections.Generic;
using Code.Gameplay.Features.Tiles.Animations.Configs;
using DG.Tweening;
using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Features.Tiles.Animations.Systems
{
    [UsedImplicitly]
    public class TileRotateAnimationSystem : ReactiveSystem<GameEntity>
    {
        private readonly CommonTileAnimationsConfig _config;

        public TileRotateAnimationSystem(GameContext context, CommonTileAnimationsConfig config)  
            : base(context)
        {
            _config = config;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.TileRotationType);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasTileRotationType
                   && entity.hasRotation;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                Vector3 rotation = entity.rotation.Value.eulerAngles;

                float targetAngle = entity.TileRotationType.ToRotationValue();
                if (entity.TileRotationType.ToRotationValue() - rotation.y > 180)
                {
                     targetAngle -= 360;
                }

                if (rotation.y - entity.TileRotationType.ToRotationValue() > 180)
                {
                    targetAngle += 360;
                }
                    
                Sequence sequence = DOTween.Sequence();
                sequence.Append(DOTween.To(
                        () => rotation.y,
                        newValue => entity.ReplaceRotation(Quaternion.Euler(rotation.x, newValue, rotation.z)),
                        targetAngle,
                        _config.rotationDuration))
                    .SetEase(_config.rotationEase)
                    .AppendCallback(() => entity.ReplaceRotation(Quaternion.Euler(rotation.x, entity.TileRotationType.ToRotationValue(), rotation.z)))
                    .Play();
            }
        }
    }
}
