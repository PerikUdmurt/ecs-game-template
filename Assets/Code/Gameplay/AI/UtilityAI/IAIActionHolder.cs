using System.Collections.Generic;

namespace UtilityAi
{
    public interface IAIActionHolder
    {
        public IEnumerable<ScoredAIAction> GetAvailableActions();
    }
}