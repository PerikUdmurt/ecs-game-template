using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace NodeBasedEditor.Editors.Nodes
{
    public abstract class BaseNode: Node
    {
        
        
        protected virtual string nodeName { get => "Node"; }
        public string ID { get; set; }
        public abstract List<Port> InputPorts { get; }
        public abstract List<BasePort> OutputPorts { get; }
        public abstract void Draw();
    }
}