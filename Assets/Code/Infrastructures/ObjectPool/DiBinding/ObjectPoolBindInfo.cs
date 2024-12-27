using System;
using UnityEngine.AddressableAssets;
using UnityEngine.UIElements;
using Zenject;

namespace Code.Infrastructures.ObjectPool.DiBinding
{
    public class ObjectPoolBindInfo
    {
        public string assetPath;
        public AssetReference assetReference;
        public Type objectPoolType;
        public int preparedCount;
        public Action<InjectContext, object> instantiatedCallback;
    }
}
