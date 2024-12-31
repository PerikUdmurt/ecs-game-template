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
                .Bind<IPlayerSettingService>()
                .To<PlayerSettingsService>()
                .AsSingle();
            
            Container
                .Bind<IPlayerSettingProvider>()
                .To<PlayerSettingsProvider>()
                .AsSingle();
        }
    }
}