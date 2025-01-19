using Entitas;
using JetBrains.Annotations;

namespace Code.NodeBasedSystem.Core.Conditions.ConditionVerifiers
{
    [UsedImplicitly]
    public class HasTokenConditionVerifier : IConditionVerifier<HasToken>
    {
        private readonly ProgressContext _progressContext;

        public HasTokenConditionVerifier(ProgressContext progressContext)
        {
            _progressContext = progressContext;
        }
        
        public bool CheckCondition(HasToken condition)
        {
            IGroup<ProgressEntity> tokenStorages= _progressContext.GetGroup(
                ProgressMatcher.AllOf(
                    ProgressMatcher.ProgressTokenStorage));
            
            bool result = false;
            foreach (ProgressEntity tokenStorageEntity in tokenStorages)
            {
                if (tokenStorageEntity.ProgressTokenStorage.Contains(condition.Token))
                {
                    result = true;
                }
            }
            return result;
        }
    }
}