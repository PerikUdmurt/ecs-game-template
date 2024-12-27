using System;
using System.Reflection;
using Code.Editor;
using NodeBasedSystem.Nodes;
using NodeBasedSystem.Nodes.Attributes;
using UnityEngine;
using UnityEngine.UIElements;

namespace NodeBasedEditor.Editors
{
    public class EventContainer : VisualElement
    {
        public INodeEventComponent Event { get; private set; }

        public EventContainer(INodeEventComponent @event) : base()
        {
            Event = @event;
            GetEventType(@event, out Type eventType, out string eventName, out string hex);
            DrawContainer(eventName, @event);
            SetStyles(hex);
        }

        private void DrawContainer(string name, INodeEventComponent @event)
        {
            Foldout foldout = new Foldout()
            {
                text = name
            };

            object obj = @event;
            foldout.DrawProperties(obj);

            this.Add(foldout);
        }

        private void SetStyles(string hexcode)
        {
            AddToClassList("ds-node__custom-data-container");
            style.borderLeftWidth = 5;
            style.borderLeftColor = SetSideColor(hexcode);
        }

        private static Color SetSideColor(string hexcode)
        {
            ColorUtility.TryParseHtmlString(hexcode, out Color color);
            return color;
        }

        private void GetEventType(INodeComponent @event, out Type eventType, out string eventName, out string hex)
        {
            eventType = @event.GetType();
            NodeComponentAttribute attribute = (NodeComponentAttribute)eventType.GetCustomAttribute(typeof(NodeComponentAttribute));
            eventName = attribute.Name;
            hex = attribute.Hex;
        }
    }
}