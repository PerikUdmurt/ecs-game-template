using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Code.NodeBasedSystem.Core.Conditions.ConditionVerifiers
{
    [UsedImplicitly]
    public class ConditionVerifierFactory : IConditionVerifierFactory
    {
        private readonly DiContainer _container;

        public ConditionVerifierFactory(DiContainer container)
        {
            _container = container;
        }
    
        public IConditionVerifier<TConditionData> GetVerifierForConditionData<TConditionData>() 
            where TConditionData : BaseConditionData
        {
            var verifier = _container.TryResolve<IConditionVerifier<TConditionData>>();
            if (verifier == null)
            {
                Debug.LogError($"[CONDITION_VERIFIER_FACTORY] Could not resolve verifier with type {typeof(IConditionVerifier<TConditionData>)}");
            }
            return verifier;
        }
    }
}