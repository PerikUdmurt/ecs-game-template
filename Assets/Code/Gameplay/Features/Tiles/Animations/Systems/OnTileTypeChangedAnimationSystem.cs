using System.Collections.Generic;
using Code.Gameplay.Features.Tiles.Animations.Configs;
using Code.Gameplay.Features.Tiles.Configs;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Features.Tiles.Animations.Systems
{
    [UsedImplicitly]
    public class OnTileTypeChangedAnimationSystem : ReactiveSystem<GameEntity>
    {
        private readonly CommonTileAnimationsConfig _config;

        public OnTileTypeChangedAnimationSystem(GameContext context, CommonTileAnimationsConfig config)
            : base(context)
        {
            _config = config;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(
                GameMatcher.TileType.AddedOrRemoved());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasTileType
                && entity.hasScale;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                switch (entity.tileType.Value)
                {
                    case ETileType.Built:
                        OnBuiltTileType(entity);
                        break;
                    case ETileType.Prepare:
                        OnPrepareTileType(entity);
                        break;
                    case ETileType.Available:
                        OnAvailableTileType(entity);
                        break;
                    case ETileType.Empty:
                        OnEmptyTileType(entity);
                        break;
                    default:
                        break;
                }
            }
        }

        //ToDo: Same code. Refactor this.
        private void OnBuiltTileType(GameEntity entity)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(ScaleObject(entity, Vector3.zero))
                .SetEase(_config.onEmptyTileEase)
                .AppendCallback(() =>
                {
                    SetViewActive(entity, true);
                    SetAvailableTileViewActive(entity,false);
                })
                .Append(ScaleObject(entity, Vector3.one))
                .SetEase(_config.onEmptyTileEase)
                .Play();
        }

        private void OnPrepareTileType(GameEntity entity)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(ScaleObject(entity, Vector3.zero))
                .SetEase(_config.onEmptyTileEase)
                .AppendCallback(() =>
                {
                    SetViewActive(entity, true);
                    SetAvailableTileViewActive(entity,false);
                })
                .Append(ScaleObject(entity, Vector3.one))
                .SetEase(_config.onEmptyTileEase)
                .Play();
        }

        private void OnAvailableTileType(GameEntity entity)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(ScaleObject(entity, Vector3.zero))
                .SetEase(_config.onEmptyTileEase)
                .AppendCallback(() =>
                {
                    SetViewActive(entity, false);
                    SetAvailableTileViewActive(entity,true);
                })
                .Append(ScaleObject(entity, Vector3.one))
                .SetEase(_config.onEmptyTileEase)
                .Play();
        }

        private void OnEmptyTileType(GameEntity entity)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(ScaleObject(entity, Vector3.zero))
                .SetEase(_config.onEmptyTileEase)
                .AppendCallback(() =>
                {
                    SetViewActive(entity, false);
                    SetAvailableTileViewActive(entity,false);
                })
                .Append(ScaleObject(entity, Vector3.one))
                .SetEase(_config.onEmptyTileEase)
                .Play();
        }

        private TweenerCore<Vector3, Vector3, VectorOptions> ScaleObject(GameEntity entity, Vector3 value)
        {
            return DOTween.To(
                () => entity.scale.Value, 
                newValue =>
                {
                    entity.ReplaceScale(newValue);
                    entity.EmptyTileView.gameObject.transform.localScale = newValue;
                }, 
                value, 
                _config.ScaleTileDuration);
        }

        private void SetAvailableTileViewActive(GameEntity entity, bool active)
        {
            if (entity.hasEmptyTileView)
            {
                entity.EmptyTileView.gameObject.SetActive(active);
            }
        }

        private void SetViewActive(GameEntity entity, bool active)
        {
            if (entity.hasView)
            {
                entity.View.gameObject.SetActive(active);
            }
        }
    }
}