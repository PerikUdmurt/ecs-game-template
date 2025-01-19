using Code.NodeBasedSystem.Core.Datas;
using NodeBasedSystem.Nodes;
using NodeBasedSystem.Nodes.Attributes;

namespace Code.NodeBasedSystem.DialogueSystem
{
    [NodeSystem, NodeComponent("DialogueSystem. Show Phrase","#c1c814")]
    public class DialoguePhraseComponent : INodeEventComponent { public LocalizedStringData Value = new(); }
    
    [NodeSystem, NodeComponent("DialogueSystem. Bind Window", "#ff9d00")]
    public class BindDialogueWindowComponent : INodeEventComponent { public EDialogueWindowType Value;}

    public enum EDialogueWindowType
    {
        None = 0,
        DefaultDialogueWindow = 1,
    }
}
