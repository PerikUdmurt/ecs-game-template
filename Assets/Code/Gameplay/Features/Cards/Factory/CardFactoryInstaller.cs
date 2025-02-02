using JetBrains.Annotations;
using Zenject;

namespace Code.Gameplay.Features.Cards.Factory
{
    [UsedImplicitly]
    public class CardsInstaller : Installer<CardsInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ICardFactory>()
                .To<CardFactory>()
                .AsSingle();
        }
    }
}