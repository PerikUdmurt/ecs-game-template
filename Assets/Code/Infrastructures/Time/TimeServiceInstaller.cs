using Zenject;

namespace Code.Infrastructures.Time
{
    public class TimeServiceInstaller : Installer<TimeServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TimeService>()
                .AsTransient();
        }
    }
}