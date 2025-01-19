namespace Code.NodeBasedSystem.Core.Conditions
{
    public interface INodeConditionVerifyService
    {
        bool Check(params BaseConditionData[] conditions);
    }
}