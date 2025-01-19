namespace Code.NodeBasedSystem.Core.Conditions.ConditionVerifiers
{
    public interface IConditionVerifierFactory
    {
        IConditionVerifier<TConditionData> GetVerifierForConditionData<TConditionData>() 
            where TConditionData : BaseConditionData;
    }
}