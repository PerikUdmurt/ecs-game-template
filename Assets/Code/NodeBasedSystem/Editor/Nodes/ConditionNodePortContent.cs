using System;
using System.Collections.Generic;
using Code.NodeBasedSystem.Core.Conditions;
using UnityEngine;
using UnityEngine.UIElements;

namespace NodeBasedEditor.Editors.Nodes
{
    public class ConditionNodePortContent : VisualElement
    {
        private List<BaseConditionData> _conditions;
        public ConditionNodePortContent(params BaseConditionData[] conditions)
        {
            Draw();
            
            _conditions = new List<BaseConditionData>(conditions);
            
            foreach (BaseConditionData cond in _conditions)
            {
                DrawCondition(cond);
            }
        }
        
        public List<BaseConditionData> Conditions { get => _conditions; }

        private void Draw()
        {
            DropdownField dropdownField = AddConditionDropdownField();
            Button addbutton = UIElementUtility.AddButton("Добавить условие");
            Add(addbutton);
            addbutton.clicked += () => CreateConditionByType(dropdownField.value);
        }

        public void AddCondition(BaseConditionData condition)
        {
            _conditions.Add(condition);
            DrawCondition(condition);
        }

        private void DrawCondition(BaseConditionData condition)
        {
            ConditionContainer container = new ConditionContainer(condition);
            Add(container);
            Button deleteButton = UIElementUtility.AddButton("Удалить условие");
            deleteButton.clicked += () => RemoveCondition(container);
            container.Add(deleteButton);
        }

        public void RemoveCondition(ConditionContainer conditionContainer)
        {   
            _conditions.Remove(conditionContainer.Condition);
            Remove(conditionContainer);
        }
        
        private DropdownField AddConditionDropdownField()
        {
            List<string> names = ConditionFinder.Names;

            DropdownField dropdownField = new DropdownField(names, 1);
            Add(dropdownField);
            return dropdownField;
        }
        
        private void CreateConditionByType(string conditionName)
        {
            if (ConditionFinder.TryGetConditionType(conditionName, out var type))
            {
                Debug.Log(type.FullName);
                BaseConditionData condition = (BaseConditionData)Activator.CreateInstance(type);

                AddCondition(condition);
            }
        }
    }
}