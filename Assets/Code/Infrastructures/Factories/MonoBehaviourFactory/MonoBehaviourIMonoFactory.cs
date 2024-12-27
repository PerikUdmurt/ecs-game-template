using UnityEngine;
using Zenject;

namespace Code.Infrastructures.Factories
{
    public class MonoBehaviourFactory : IMonoFactory
    {
        private readonly DiContainer _container;
        
        public MonoBehaviourFactory(DiContainer container)
        {
            _container = container;
        }

        public T Create<T>(GameObject obj) where T : MonoBehaviour
        {
            return _container.InstantiatePrefabForComponent<T>(obj);
        }
        
        public T Create<T>(string resourcePath) where T : MonoBehaviour
        {
            return _container.InstantiatePrefabResourceForComponent<T>(resourcePath);
        }
    }
}
