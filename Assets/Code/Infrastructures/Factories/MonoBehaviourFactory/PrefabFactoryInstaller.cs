using JetBrains.Annotations;
using Zenject;

namespace Code.Infrastructures.Factories
{
    [UsedImplicitly]
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
