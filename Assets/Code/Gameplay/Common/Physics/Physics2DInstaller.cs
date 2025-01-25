using JetBrains.Annotations;
using Zenject;

namespace Code.Gameplay.Common.Physics
{
  [UsedImplicitly]
  public class PhysicsInstaller : Installer<PhysicsInstaller>
  {
    public override void InstallBindings()
    {
      Container
        .Bind<IPhysics2DService>()
        .To<Physics2DService>()
        .AsSingle();
      
      Container
        .Bind<IPhysics3DService>()
        .To<Physics3DService>()
        .AsSingle();
    }
  }
}