using Zenject;

namespace Code.Gameplay.Features.Cards.Factory
{
    public class CardFactoryInstaller : Installer<CardFactoryInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CardFactory>()
                .AsSingle();
        }
    }
}