using Zenject;

namespace Code.Services.LocalizationServices
{
    public class LocalizationInstaller : Installer<LocalizationInstaller>
    {
        public override void InstallBindings()
        {   
            Container
                .Bind<ILocalizationService>()
                .To<LocalizationService>()
                .AsSingle();
        }
    }
}