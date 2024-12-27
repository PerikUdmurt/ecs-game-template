using Cysharp.Threading.Tasks;

namespace Code.Infrastructures.View.Factory
{
    public interface IEntityViewFactory
    {
        UniTask<EntityBehaviour> CreateViewForEntity(GameEntity entity);
        EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity);
    }
}