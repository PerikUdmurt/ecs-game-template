using Zenject;

namespace Code.Gameplay.Common.Collisions
{
    public class CollisionRegistryInstaller : Installer<CollisionRegistryInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CollisionRegistry>().AsSingle();
        }
    }
}
