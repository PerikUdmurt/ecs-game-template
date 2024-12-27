using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEngine.VFX;

namespace NodeBasedEditor.Editors.Nodes
{
    public class CustomPort<TContent> : BasePort where TContent : VisualElement
    {
        private TContent _content;
        private Port _port;

        public CustomPort(Port port, TContent content)
        {
            this.Add(port);
            this.Add(content);
            
            _port = port;
            _content = content;
        }

        public TContent Content { get => _content; }
        public override Port Port { get => _port; }
    }

    public abstract class BasePort : VisualElement
    {
        public abstract Port Port { get; }
    }
}