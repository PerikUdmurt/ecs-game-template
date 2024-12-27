using UnityEngine;
using Zenject;

namespace Code.Infrastructures.ObjectPool.DiBinding
{
    public static class ObjectPoolBindingExtensions
    {
        public static ObjectPoolBinderGeneric<TPooledObject> BindObjectPool<TPooledObject>(this DiContainer container)
            where TPooledObject : MonoBehaviour
        {
            return new ObjectPoolBinderGeneric<TPooledObject>(container.StartBinding());
        }
    }
}