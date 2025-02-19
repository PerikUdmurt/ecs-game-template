using Code.Infrastructures.View;
using Cysharp.Threading.Tasks;

namespace Code.Gameplay.Features.Tiles.Systems
{
    public interface IEmptyTileViewFactory
    {
        UniTask<EntityBehaviour> CreateViewForEntity(GameEntity entity);
    }
}