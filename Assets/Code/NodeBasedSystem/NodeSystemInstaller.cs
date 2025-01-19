using Code.NodeBasedSystem.Core.Conditions;
using Code.NodeBasedSystem.GraphLoaders;
using JetBrains.Annotations;
using Zenject;

namespace Code.NodeBasedSystem
{
    [UsedImplicitly]
    public class NodeSystemInstaller : Installer<NodeSystemInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<GraphLoader>()
                .AsSingle();

            Installer<ConditionVerifyInstaller>.Install(Container);
        }
    }
}
