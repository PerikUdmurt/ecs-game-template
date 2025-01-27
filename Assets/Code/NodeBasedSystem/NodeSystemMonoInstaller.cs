using Zenject;

namespace Code.NodeBasedSystem
{
    public class NodeSystemMonoInstaller : MonoInstaller<NodeSystemMonoInstaller>
    {
        public override void InstallBindings()
        {
            Installer<NodeSystemInstaller>.Install(Container);
        }
    }
}