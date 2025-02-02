using JetBrains.Annotations;
using Zenject;

namespace Code.Services.LocalizationServices
{
    [UsedImplicitly]
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