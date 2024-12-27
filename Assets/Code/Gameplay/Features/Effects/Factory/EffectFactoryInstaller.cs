using Zenject;

namespace Code.Gameplay.Features.Effects.Factory
{
    public class EffectFactoryInstaller : Installer<EffectFactoryInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EffectFactory>()
                .AsSingle();
        }
    }
}