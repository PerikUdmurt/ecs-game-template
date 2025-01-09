using System.Collections.Generic;
using Code.NodeBasedSystem.Progress.Datas;
using Code.Progress.PlayerStorage;

namespace Code.NodeBasedSystem.Core.Conditions
{
    public abstract class BaseConditionData { }

    [NodeCondition("Есть токен")]
    public class HasToken : BaseConditionData
    {
        public string Token;
    }
    
    [NodeCondition("Ресурсы")]
    public class ResourceCondition : BaseConditionData
    {
        public EResource Resource;
        public EEquation Equation;
        public int Amount;
    }
    
    [NodeCondition("Предметы")]
    public class ItemCondition : BaseConditionData
    {
        public EPlayerItem Item;
        public EEquation Equation;
        public int Amount;
    }

    public enum EEquation
    {
        Equal,
        Below,
        More
    }
}
