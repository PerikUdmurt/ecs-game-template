using Code.Infrastructures.AssetManagement;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Code.Infrastructures.Factories
{
    [UsedImplicitly]
    public class CustomAsyncFactory : IAsyncMonoFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly DiContainer _container;

        public CustomAsyncFactory(DiContainer container)
        {
            _container = container;
            _assetProvider = container.Resolve<IAssetProvider>();
        }
        
        public async UniTask<T> Create<T>(AssetReference assetReference) where T : MonoBehaviour
        {
            GameObject gameObject = await _assetProvider.Load<GameObject>(assetReference);
            return InstantiatePrefab<T>(gameObject);
        }

        private T InstantiatePrefab<T>(GameObject gameObject) where T : MonoBehaviour
        {
            if (!gameObject.TryGetComponent<T>(out T component))
            {
                Debug.LogError($"Can't find component of type {typeof(T)} while instantiate prefab {gameObject.name}");
            }

            return _container.InstantiatePrefabForComponent<T>(component);
        }

        public async UniTask<T> Create<T>(string assetPath) where T : MonoBehaviour
        {
            GameObject resource = await _assetProvider.Load<GameObject>(assetPath);
            return InstantiatePrefab<T>(resource);
        }
    }
}