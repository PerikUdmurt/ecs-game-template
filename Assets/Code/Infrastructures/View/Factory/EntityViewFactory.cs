using Code.Infrastructures.AssetManagement;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Code.Infrastructures.View.Factory
{
  [UsedImplicitly]
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

      if (entity.hasView)
      {
        entity.View.ReleaseEntity();
        Object.Destroy(entity.View.gameObject);
      }
      
      GameObject obj = await _assetProvider.Load<GameObject>(entity.ViewPath);
      EntityBehaviour viewPrefab = obj.GetComponent<EntityBehaviour>();
      EntityBehaviour view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
        viewPrefab,
        position: _farAway,
        Quaternion.identity,
        parentTransform: null);

      view.SetEntity(entity);
      entity.RemoveViewPath();
      entity.isAssetIsLoading = false;

      if (entity.isInstantiateWithDisabledView)
      {
        entity.View.gameObject.SetActive(false);
      }

      return view;
    }

    public EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity)
    {
      if (entity.hasView)
      {
        Object.Destroy(entity.View.gameObject);
      }
      
      EntityBehaviour view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
        entity.ViewPrefab,
        position: _farAway,
        Quaternion.identity,
        parentTransform: null);
      
      view.SetEntity(entity);
      entity.RemoveViewPrefab();
      
      if (entity.isInstantiateWithDisabledView)
      {
        entity.View.gameObject.SetActive(false);
      }
      
      return view;
    }
  }
}
