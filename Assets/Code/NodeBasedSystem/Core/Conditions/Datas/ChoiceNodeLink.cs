using System.Collections.Generic;
using Code.NodeBasedSystem.Core.Datas;
using UnityEngine;

namespace Code.NodeBasedSystem.Core.Conditions
{
    public class ChoiceNodeLink : ConditionNodeLink
    {
        private readonly LocalizedStringData _choiceLsData;

        public ChoiceNodeLink(string nodeId, LocalizedStringData choiceLocalizedStringData, params BaseConditionData[] conditions) 
            : base(nodeId, conditions)
        {
            _choiceLsData = choiceLocalizedStringData;
        }
    
        public LocalizedStringData ChoiceLocalizedStringData { get => _choiceLsData; }
    }
}