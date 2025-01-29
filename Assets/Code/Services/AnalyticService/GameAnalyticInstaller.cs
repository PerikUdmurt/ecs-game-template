using JetBrains.Annotations;
using Zenject;

namespace Code.Services.AnalyticService
{
    [UsedImplicitly]
    public class GameAnalyticInstaller : Installer<GameAnalyticInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IAnalyticService>()
                .To<GameAnalyticService>()
                .AsSingle();
        }
    }
}