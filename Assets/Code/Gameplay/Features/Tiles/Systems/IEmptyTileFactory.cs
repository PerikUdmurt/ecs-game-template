using Code.Infrastructures.AssetManagement;
using Code.Infrastructures.View;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Tiles.Systems
{
    [UsedImplicitly]
    public class IEmptyTileFactory : IEmptyTileViewFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;
   
        public IEmptyTileFactory(IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }
        
        public async UniTask<EntityBehaviour> CreateViewForEntity(GameEntity entity)
        {
            entity.isEmptyTileIsLoading = true;

            if (entity.hasEmptyTileView)
            {
                Object.Destroy(entity.EmptyTileView.gameObject);
            }
      
            GameObject obj = await _assetProvider.Load<GameObject>(entity.EmptyTileViewPath);
            EntityBehaviour viewPrefab = obj.GetComponent<EntityBehaviour>();
            EntityBehaviour view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
                viewPrefab,
                position: entity.WorldPosition,
                Quaternion.identity,
                parentTransform: null);
            
            entity.RemoveEmptyTileViewPath();
            entity.isEmptyTileIsLoading = false;
            entity.ReplaceEmptyTileView(view);
            
            return view;
        }
    }
    
    
}