using System;
using ModestTree;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Code.Infrastructures.ObjectPool.DiBinding
{
    public class ObjectPoolBinderGeneric<TPooledObject> where TPooledObject : MonoBehaviour
    {
        private ObjectPoolBindInfo _info;
        
        public ObjectPoolBinderGeneric(BindStatement bindStatement)
        {
            _info = new ObjectPoolBindInfo();
            _info.objectPoolType = typeof(ObjectPool<TPooledObject>);
            bindStatement.SetFinalizer(new ObjectPoolBindingFinalizer(_info));
        }

        public ObjectPoolBinderGeneric<TPooledObject> WithPrefabFromAssetPath(string assetPath)
        {
            _info.assetPath = assetPath;
            return this;
        }
        
        public ObjectPoolBinderGeneric<TPooledObject> WithPrefabFromAssetReference(AssetReference assetReference)
        {
            _info.assetReference = assetReference;
            return this;
        }

        public ObjectPoolBinderGeneric<TPooledObject> PrepareObjects(int preparedCount)
        {
            _info.preparedCount = preparedCount;
            return this;
        }
    }
}