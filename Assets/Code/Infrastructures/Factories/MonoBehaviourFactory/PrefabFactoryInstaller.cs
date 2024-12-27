using UnityEngine;
using Zenject;

namespace Code.Infrastructures.Factories
{
    public class PrefabFactoryInstaller : Installer<PrefabFactoryInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind(typeof(IMonoFactory))
                .To(typeof(MonoBehaviourFactory))
                .AsCached();
            
            Container
                .Bind<IAsyncMonoFactory>()
                .To<CustomAsyncFactory>()
                .AsCached();
        }
    }
}
