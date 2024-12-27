using System.Collections.Generic;

namespace Code.NodeBasedSystem.Core.Conditions
{
    public abstract class BaseConditionData { }

    [NodeCondition("Есть токены")]
    public class HasToken : BaseConditionData
    {
        public List<object> Tokens;
    }
}
