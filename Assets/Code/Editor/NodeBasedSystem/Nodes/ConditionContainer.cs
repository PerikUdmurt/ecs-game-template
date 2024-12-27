using System;
using System.Reflection;
using Code.Editor;
using Code.NodeBasedSystem.Core.Conditions;
using UnityEngine.UIElements;

namespace NodeBasedEditor.Editors.Nodes
{
    public class ConditionContainer : VisualElement
    {
        private BaseConditionData _condition;

        public ConditionContainer(BaseConditionData condition)
        {
            _condition = condition;
            GetEventType(condition, out Type eventType, out string conditionName);
            DrawContainer(conditionName, condition);
        }
        
        public BaseConditionData Condition { get => _condition; }
        
        private void DrawContainer(string name, BaseConditionData condition)
        {
            Foldout foldout = new Foldout()
            {
                text = name
            };

            object obj = condition;
            foldout.DrawProperties(obj);

            this.Add(foldout);
        }
        
        private void GetEventType(BaseConditionData @event, out Type eventType, out string conditionName)
        {
            eventType = @event.GetType();
            NodeConditionAttribute attribute = (NodeConditionAttribute)eventType.GetCustomAttribute(typeof(NodeConditionAttribute));
            conditionName = attribute.Name;
        }
    }
}