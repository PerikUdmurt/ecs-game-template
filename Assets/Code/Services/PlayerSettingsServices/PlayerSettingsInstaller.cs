using JetBrains.Annotations;
using Zenject;

namespace Code.Services.PlayerSettingsServices
{
    [UsedImplicitly]
    public class PlayerSettingsInstaller : Installer<PlayerSettingsInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerSettingsService>()
                .AsSingle();
            
            Container
                .Bind<IPlayerSettingProvider>()
                .To<PlayerSettingsProvider>()
                .AsSingle();
            
            Container
                .Bind<IInitialPlayerSettingProvider>()
                .To<InitialPlayerSettingsDataProvider>()
                .AsSingle();
        }
    }
}