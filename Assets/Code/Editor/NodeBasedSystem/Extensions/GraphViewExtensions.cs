using System.Collections.Generic;
using System.Linq;
using NodeBasedEditor.Editors.Nodes;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEngine.VFX;

namespace NodeBasedSystem.Editor.Extensions
{
    public static class GraphViewExtensions
    {
        public static List<TNode> GetNodes<TNode>(this GraphView graphView) where TNode : BaseNode
        {
            return graphView.GetElements<TNode>();
        }

        public static List<TElement> GetElements<TElement>(this GraphView graphView) where TElement : VisualElement
        {
            return graphView.graphElements
                .Where(graphElement => graphElement is TElement)
                .Cast<TElement>()
                .ToList();
        }
    }
}
