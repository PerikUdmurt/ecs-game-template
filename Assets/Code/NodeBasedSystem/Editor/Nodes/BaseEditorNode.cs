using System;
using System.Collections.Generic;
using System.Linq;
using NodeBasedSystem.Nodes;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace NodeBasedEditor.Editors.Nodes
{
    public abstract class BaseEditorNode<TPortContent> : BaseNode where TPortContent : VisualElement 
    {
        protected abstract override string nodeName { get; }
        protected VisualElement eventsContainer;
        
        private List<Port> _inputPorts;
        private List<BasePort> _outputPorts;

        public sealed override List<Port> InputPorts { get => _inputPorts; }
        public sealed override List<BasePort> OutputPorts { get => _outputPorts; }
        public List<INodeEventComponent> Events { get; set; }

        public void Initialize(Vector2 position, List<TPortContent> portContents = null, List<INodeEventComponent> events = null, string id = null)
        {
            _inputPorts = new();
            _outputPorts = new();

            if (portContents != null)
                foreach (var portContent in portContents)
                {
                    CreatePort("Output", Direction.Output, Port.Capacity.Single, portContent);
                }

            if (id == null)
                ID = Guid.NewGuid().ToString();
            else ID = id;

            eventsContainer = new VisualElement();

            Events = new();
            if (events != null)
            {
                foreach (INodeEventComponent @event in events)
                {
                    CreateEvent(@event);
                }
            }

            SetPosition(new Rect(position, Vector2.zero));
            SetStyles();
        }
        public override void Draw()
        {
            DrawTitleContainer();
            DrawExtensionContainer();
            RefreshExpandedState();
        }

        private protected CustomPort<TPortContent> CreatePort(string portName, Direction direction, Port.Capacity capacity, TPortContent portContent = null)
        {
            Port port = InstantiatePort(Orientation.Horizontal, direction, capacity, typeof(bool));
            port.portName = portName;
            CustomPort<TPortContent> customPort = new (port, portContent);

            if (direction == Direction.Output)
                AddOutputPort(customPort);

            if (direction == Direction.Input)
            {
                _inputPorts.Add(port);
                inputContainer.Add(port);
            }

            RefreshExpandedState();
            return customPort;
        }

        private protected virtual void AddOutputPort(CustomPort<TPortContent> port)
        {
            _outputPorts.Add(port);
            outputContainer.Add(port);
        }

        private void SetStyles()
        {
            mainContainer.AddToClassList("ds-node__main-container");
            extensionContainer.AddToClassList("ds-node__extension-container");
        }

        private protected virtual void DrawEventContainer(INodeEventComponent @event)
        {
            EventContainer eventContainer = new EventContainer(@event);
            eventsContainer.Add(eventContainer);

            Button removeButton = UIElementUtility.AddButton("Удалить компонент");
            removeButton.clicked += () => RemoveEventContainer(eventContainer);
            eventContainer.Add(removeButton);
            RefreshExpandedState();
        }

        private protected virtual void DrawTitleContainer()
        {
            Label label = new Label(nodeName);
            titleContainer.Insert(0, label);
        }

        private protected virtual void DrawExtensionContainer()
        {
            DropdownField dropdownField = AddEventDropdownField();
            AddCreateEventButton(dropdownField);
            extensionContainer.Add(eventsContainer);
        }

        private void AddCreateEventButton(DropdownField dropdownField)
        {
            Button addbutton = UIElementUtility.AddButton("Добавить компонент");
            addbutton.clicked += () => CreateEventByType(dropdownField.value);

            extensionContainer.Add(addbutton);
        }

        private DropdownField AddEventDropdownField()
        {
            List<string> names = EventFinder.EventNames;

            DropdownField dropdownField = new DropdownField(names, 1);
            extensionContainer.Add(dropdownField);
            return dropdownField;
        }

        private void CreateEventByType(string eventName)
        {
            if (EventFinder.TryGetEventType(eventName, out var type))
            {
                if (Events.FirstOrDefault(item => item.GetType() == type) != null)
                {
                    Debug.LogError($"The node already has an event with type {type.Name}");
                    return;
                }

                INodeEventComponent @event = (INodeEventComponent)Activator.CreateInstance(type);

                CreateEvent(@event);
            }
        }

        private void CreateEvent(INodeEventComponent @event)
        {
            Events.Add(@event);
            DrawEventContainer(@event);
        }

        private void RemoveEventContainer(EventContainer container)
        {
            eventsContainer.Remove(container);
            Events.Remove(container.Event);
        }
    }
    
    
}