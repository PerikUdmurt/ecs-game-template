using Code.NodeBasedSystem.Core.Conditions.ConditionVerifiers;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.NodeBasedSystem.Core.Conditions
{
    [UsedImplicitly]
    public class NodeConditionVerifyService : INodeConditionVerifyService
    {
        private readonly IConditionVerifierFactory _factory;

        public NodeConditionVerifyService(IConditionVerifierFactory factory)
        {
            _factory = factory;
        }

        public bool Check(params BaseConditionData[] conditions)
        {
            bool result = true;
            foreach (var condition in conditions)
            {
                if (!VerifyCondition(condition))
                {
                    result = false;
                }
            }
            return result;
        }

        private bool VerifyCondition<TConditionData>(TConditionData condition)
            where TConditionData : BaseConditionData
        {
            switch (condition)
            {
                case HasToken targetCond:
                    IConditionVerifier<HasToken> verifier1 = 
                        _factory.GetVerifierForConditionData<HasToken>();
                    return verifier1.CheckCondition(targetCond);

                case ResourceCondition targetCond:
                    IConditionVerifier<ResourceCondition> verifier2 =
                        _factory.GetVerifierForConditionData<ResourceCondition>();
                    return verifier2.CheckCondition(targetCond);
                
                case HasLocalToken targetCond:
                    IConditionVerifier<HasLocalToken> verifier3 = 
                        _factory.GetVerifierForConditionData<HasLocalToken>();
                    return verifier3.CheckCondition(targetCond);
            }

            Debug.LogError(
                $"[NodeConditionVerifyService] Not found verifier for condition type {condition.GetType()}. Return true.");
            return true;
        }
    }
}
