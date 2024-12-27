using System.Collections.Generic;

namespace Code.NodeBasedSystem.Core.Conditions
{
    public class ConditionedNode
    {
        private List<BaseConditionData> _conditions;
        private string _nodeId;

        public ConditionedNode(string nodeId, params BaseConditionData[] conditions)
        {
            _nodeId = nodeId;
            _conditions = new List<BaseConditionData>(conditions);
        }
    
        public string NodeId { get=> _nodeId; }
        public List<BaseConditionData> Conditions { get=> _conditions; }
    }
}
