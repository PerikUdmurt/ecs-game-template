using System;
using System.Collections.Generic;
using System.Linq;
using Code.Infrastructures.Factories;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Infrastructures.ObjectPool
{
    public class ObjectPool<T> : IObjectPool<T>, IDisposable
    where T : MonoBehaviour
    {
        private readonly IAsyncMonoFactory _factory;
        private readonly List<T> _objects;

        private readonly string _assetPath;
        private readonly AssetReference _assetReference;

        public ObjectPool(IAsyncMonoFactory factory, string assetPath)
        {
            _objects = new List<T>();
            _factory = factory;
            _assetPath = assetPath;
        }
        
        public ObjectPool(IAsyncMonoFactory factory, AssetReference assetReference)
        {
            _objects = new List<T>();
            _factory = factory;
            _assetReference = assetReference;
        }

        public async UniTask Fill(int prepareObjects)
        {
            for (int i = 0; i < prepareObjects; i++)
            {
                await Create();
            }
        }

        public void CleanUp()
        {
            foreach (var obj in _objects)
            {
                GameObject.Destroy(obj.gameObject);
            }
        }

        public async UniTask<T> Get()
        {
            var obj = _objects.FirstOrDefault(x => x.gameObject.activeSelf == false);

            if (obj == null)
            {
                obj = await Create();
            }

            obj.gameObject.SetActive(true);
            return obj;
        }

        private async UniTask<T> Create()
        {
            T obj = null;
            
            if (string.IsNullOrEmpty(_assetPath)) 
                obj = await _factory.Create<T>(_assetReference);
            else 
                obj = await _factory.Create<T>(_assetPath);
                
            _objects.Add(obj);
            obj.gameObject.SetActive(false);
            return obj;
        }

        public void Release(T obj)
        {
            obj.gameObject.SetActive(false);
        }

        public void Dispose()
        {
            CleanUp();
        }
    }
}