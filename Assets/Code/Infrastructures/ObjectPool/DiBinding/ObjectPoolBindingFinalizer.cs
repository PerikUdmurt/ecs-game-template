using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Code.Infrastructures.ObjectPool.DiBinding
{
    public class ObjectPoolBindingFinalizer : IBindingFinalizer
    {
        private readonly ObjectPoolBindInfo _info;
        
        public ObjectPoolBindingFinalizer(ObjectPoolBindInfo info)
        {
            _info = info;
        }

        public BindingInheritanceMethods BindingInheritanceMethod { get => BindingInheritanceMethods.None; }

        public void FinalizeBinding(DiContainer container)
        {
            if (_info.preparedCount > 0)
                _info.instantiatedCallback += (context, objectPool) => 
                    ((IFillableObjectPool)objectPool).Fill(_info.preparedCount);
                        

            RegisterObjectPool(container);
        }

        private void RegisterObjectPool(DiContainer container)
        {
            TypeValuePair argument = default;

            if (string.IsNullOrEmpty(_info.assetPath))
                argument = new TypeValuePair((typeof(AssetReference)), _info.assetReference);
            else
                argument = new TypeValuePair(typeof(string), _info.assetPath);
                
            var cached = new CachedProvider(new TransientProvider(_info.objectPoolType, container,
                new [] { argument },
                $"Bind ObjectPool {_info.objectPoolType}",
                null,
                _info.instantiatedCallback));
            
            container.RegisterProvider(new BindingId(_info.objectPoolType, null),
                null, cached, false);
            
            container.RegisterProvider(new BindingId(typeof(IDisposable), null),
                null, cached, false);
        }
    }
}