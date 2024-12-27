using Code.Infrastructure.AssetManagement;
using Zenject;

namespace Code.Infrastructures.AssetManagement
{
    public class AssetManagementInstaller : Installer<AssetManagementInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AssetProvider>()
                .AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<AssetDownloadService>()
                .AsSingle();
        }
    }
}
