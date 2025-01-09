using System.Collections.Generic;
using Code.NodeBasedSystem.Core.Datas;
using UnityEngine;

namespace Code.NodeBasedSystem.Core.Conditions
{
    public class ChoiceNodeLink : ConditionNodeLink
    {
        private readonly LocalizedStringData _choiceLsData;

        public ChoiceNodeLink(string nodeId, LocalizedStringData choiceLocalizedStringDataData, params BaseConditionData[] conditions) 
            : base(nodeId, conditions)
        {
            Debug.Log("ChoiceNodeLink constructed");
            _choiceLsData = choiceLocalizedStringDataData;
        }
    
        public LocalizedStringData ChoiceLocalizedStringDataData { get => _choiceLsData; }
    }
}