using Zenject;

namespace Code.Infrastructures.Factories
{
    public class SystemFactoryInstaller : Installer<SystemFactoryInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ISystemFactory>()
                .To<SystemFactory>()
                .AsSingle();
        }
    }
}