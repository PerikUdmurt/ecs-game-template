using JetBrains.Annotations;
using Zenject;

namespace Code.Infrastructures.View.Factory
{
    [UsedImplicitly]
    public class EntityViewFactoryInstaller : Installer<EntityViewFactoryInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EntityViewFactory>()
                .AsSingle();
        }
    }
}
