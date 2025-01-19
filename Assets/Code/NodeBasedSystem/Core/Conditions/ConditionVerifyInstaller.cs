using Code.NodeBasedSystem.Core.Conditions.ConditionVerifiers;
using JetBrains.Annotations;
using Zenject;

namespace Code.NodeBasedSystem.Core.Conditions
{
    [UsedImplicitly]
    public class ConditionVerifyInstaller : Installer<ConditionVerifyInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<INodeConditionVerifyService>()
                .To<NodeConditionVerifyService>()
                .AsSingle();

            Container
                .Bind<IConditionVerifierFactory>()
                .To<ConditionVerifierFactory>()
                .AsSingle();
            
            InstallConditionVerifiers();
        }

        private void InstallConditionVerifiers()
        {
            Container
                .Bind<IConditionVerifier<HasToken>>()
                .To<HasTokenConditionVerifier>()
                .AsTransient();

            Container
                .Bind<IConditionVerifier<ResourceCondition>>()
                .To<ResourceConditionVerifier>()
                .AsTransient();
        }
    }
}