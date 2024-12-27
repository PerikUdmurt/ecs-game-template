using System.Collections.Generic;
using Code.NodeBasedSystem.Core.Conditions;
using UnityEngine.UIElements;

namespace NodeBasedEditor.Editors.Nodes
{
    public class ChoiceNodePortContent : VisualElement
    {
        private readonly ConditionNodePortContent _conditionNodePortContent;
        private readonly TextField _textField;
        
        public ChoiceNodePortContent(string text, params BaseConditionData[] conditions)
        {
            _textField = new TextField()
            {
                value = text,
            };
            this.Add(_textField);
            
            Foldout foldout = new Foldout()
            {
                text = "Условия",
            };
            this.Add(foldout);
            
            _conditionNodePortContent = new ConditionNodePortContent(conditions);
            foldout.Add(_conditionNodePortContent);
        }
        
        public List<BaseConditionData> Conditions => _conditionNodePortContent.Conditions;
        public string ChoiceText => _textField.value;
    }
}