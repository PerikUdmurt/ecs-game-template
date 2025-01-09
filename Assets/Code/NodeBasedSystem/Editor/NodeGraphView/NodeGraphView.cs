using System.Collections.Generic;
using NodeBasedEditor.Editors.Nodes;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace NodeBasedEditor.Editors
{
    public class NodeGraphView : GraphView
    {
        private EditorNodeFactory _factory;
        public NodeGraphView()
        {
            _factory = new EditorNodeFactory();
            AddManipulators();
            AddGridBackground();
            AddStyles();
        }

        public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
        {
            List<Port> compatablePorts = new();

            ports.ForEach(port =>
            {
                if (startPort == port)
                    return;

                if (startPort.node == port.node)
                    return;

                if (startPort.direction == port.direction)
                    return;

                compatablePorts.Add(port);
            });

            return compatablePorts;
        }

        private void AddManipulators()
        {
            SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new SelectionDragger());   
            this.AddManipulator(new RectangleSelector());  
            
            this.CreateContextualMenu(
                menuItemName: "Add Simple Node",
                actionEvent =>
                {
                    SimpleNode node = _factory.CreateSimpleNode(actionEvent.eventInfo.localMousePosition);
                    AddElement(node);
                });
            
            this.CreateContextualMenu(
                menuItemName: "Add Choice Node",
                actionEvent =>
                {
                    ChoiceNode node = _factory.CreateNode<ChoiceNode, ChoiceNodePortContent>(
                        actionEvent.eventInfo.localMousePosition,
                        new());
                    AddElement(node);
                });
            
            this.CreateContextualMenu(
                menuItemName: "Add Condition Node",
                actionEvent =>
                {
                    ConditionNode node = _factory.CreateNode<ConditionNode, ConditionNodePortContent>(
                        actionEvent.eventInfo.localMousePosition,
                        new());
                    AddElement(node);
                });
        }

        private void AddStyles()
        {
            this.AddStylesByPath("GraphViewStyles.uss");
        }

        private void AddGridBackground()
        {
            GridBackground gridBackground = new GridBackground();

            gridBackground.StretchToParentSize();

            Insert(0, gridBackground);
        }
    }
}