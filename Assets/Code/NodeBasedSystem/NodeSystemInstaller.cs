using Code.NodeBasedSystem.GraphLoaders;
using Zenject;

namespace Code.NodeBasedSystem
{
    public class NodeSystemInstaller : Installer<NodeSystemInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<GraphLoader>()
                .AsSingle();
        }
    }
}
