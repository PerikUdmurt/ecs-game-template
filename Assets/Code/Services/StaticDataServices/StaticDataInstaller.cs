using Zenject;

namespace Code.Services.StaticDataServices
{
    public class StaticDataInstaller : Installer<StaticDataInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<StaticDataService>()
                .AsSingle()
                .OnInstantiated<StaticDataService>((o, service) => service.LoadStaticDatas())
                .NonLazy();
        }
    }
}