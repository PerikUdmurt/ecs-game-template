using Entitas;
using JetBrains.Annotations;

namespace Code.NodeBasedSystem.Core.Conditions.ConditionVerifiers
{
    [UsedImplicitly]
    public class HasLocalTokenConditionVerifier : IConditionVerifier<HasLocalToken>
    {
        private readonly IGroup<NodeSystemEntity> _localTokenStorages;

        public HasLocalTokenConditionVerifier(NodeSystemContext nodeSystemContext)
        {
            _localTokenStorages = nodeSystemContext.GetGroup(NodeSystemMatcher
                .AllOf(NodeSystemMatcher.LocalProgressTokenStorage));
        }
        
        public bool CheckCondition(HasLocalToken condition)
        {
            bool result = false;
            foreach (NodeSystemEntity tokenStorageEntity in _localTokenStorages)
            {
                if (tokenStorageEntity.GraphID == condition.GraphPlayerID 
                    && tokenStorageEntity.LocalProgressTokenStorage.Contains(condition.LocalToken))
                {
                    result = true;
                }
            }
            return result;
        }
    }
}