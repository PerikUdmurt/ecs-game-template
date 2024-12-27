using Code.Infrastructure.Identifiers;
using Zenject;

namespace Code.Identifiers
{
    public class IdentifierServiceInstaller : Installer<IdentifierServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<IdentifierService>()
                .AsSingle();
        }
    }
}
