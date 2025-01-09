using System.Collections.Generic;
using Code.NodeBasedSystem.Core.Conditions;
using Code.NodeBasedSystem.Core.Datas;
using Code.NodeBasedSystem.Editor;
using UnityEngine.UIElements;

namespace NodeBasedEditor.Editors.Nodes
{
    public class ChoiceNodePortContent : VisualElement
    {
        private readonly ConditionNodePortContent _conditionNodePortContent;
        private readonly LocalizedStringData _stringData;
        
        public ChoiceNodePortContent(LocalizedStringData data, params BaseConditionData[] conditions)
        {
            _stringData = data;
            LocalizedStringEditorContainer container = new(data);
            this.Add(container);
            
            Foldout foldout = new Foldout()
            {
                text = "Условия",
            };
            this.Add(foldout);
            
            _conditionNodePortContent = new ConditionNodePortContent(conditions);
            foldout.Add(_conditionNodePortContent);
        }
        
        public List<BaseConditionData> Conditions => _conditionNodePortContent.Conditions;
        public LocalizedStringData ChoiceLocalizedString => _stringData;
    }
}