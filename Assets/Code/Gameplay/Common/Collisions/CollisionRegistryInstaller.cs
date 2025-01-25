using JetBrains.Annotations;
using Zenject;

namespace Code.Gameplay.Common.Collisions
{
    [UsedImplicitly]
    public class CollisionRegistryInstaller : Installer<CollisionRegistryInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CollisionRegistry>().AsSingle();
        }
    }
}
