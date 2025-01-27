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
                .Bind<INodeSystem>()
                .To<NodeSystem>()
                .AsCached();
            
            Container
                .BindInterfacesAndSelfTo<GraphLoader>()
                .AsSingle();

            Installer<ConditionVerifyInstaller>.Install(Container);
        }
    }
}
