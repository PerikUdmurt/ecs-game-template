using System.Collections.Generic;

namespace Code.NodeBasedSystem.Core.Conditions
{
    public class ConditionNodeLink
    {
        private readonly List<BaseConditionData> _conditions;
        private readonly string _nodeId;

        public ConditionNodeLink(string nodeId, params BaseConditionData[] conditions)
        {
            _nodeId = nodeId;
            _conditions = new List<BaseConditionData>(conditions);
        }
    
        public string NodeId { get=> _nodeId; }
        public List<BaseConditionData> Conditions { get=> _conditions; }
    }
}
