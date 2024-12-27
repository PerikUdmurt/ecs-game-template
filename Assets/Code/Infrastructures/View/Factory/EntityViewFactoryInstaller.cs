using Zenject;

namespace Code.Infrastructures.View.Factory
{
    public class EntityViewFactoryInstaller : Installer<EntityViewFactoryInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EntityViewFactory>()
                .AsSingle();
        }
    }
}
