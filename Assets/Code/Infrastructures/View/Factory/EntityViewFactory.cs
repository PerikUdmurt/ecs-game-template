using Code.Infrastructures.AssetManagement;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Code.Infrastructures.View.Factory
{
  public class EntityViewFactory : IEntityViewFactory
  {
    private readonly IAssetProvider _assetProvider;
    private readonly IInstantiator _instantiator;
    private readonly Vector3 _farAway = new(-999, 999, 0);
   
    public EntityViewFactory(IAssetProvider assetProvider, IInstantiator instantiator)
    {
      _assetProvider = assetProvider;
      _instantiator = instantiator;
    }

    public async UniTask<EntityBehaviour> CreateViewForEntity(GameEntity entity)
    {
      entity.isAssetIsLoading = true;
      
      GameObject obj = await _assetProvider.Load<GameObject>(entity.ViewPath);
      EntityBehaviour viewPrefab = obj.GetComponent<EntityBehaviour>();
      EntityBehaviour view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
        viewPrefab,
        position: _farAway,
        Quaternion.identity,
        parentTransform: null);

      view.SetEntity(entity);
      entity.isAssetIsLoading = false;

      return view;
    }

    public EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity)
    {
      EntityBehaviour view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
        entity.ViewPrefab,
        position: _farAway,
        Quaternion.identity,
        parentTransform: null);
        
      view.SetEntity(entity);
   
      return view;
    }
  }
}