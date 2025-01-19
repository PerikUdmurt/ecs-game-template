namespace Code.NodeBasedSystem.Core.Conditions.ConditionVerifiers
{
    public interface IConditionVerifier<in TCondition> where TCondition : BaseConditionData
    {
        bool CheckCondition(TCondition condition);
    }
}