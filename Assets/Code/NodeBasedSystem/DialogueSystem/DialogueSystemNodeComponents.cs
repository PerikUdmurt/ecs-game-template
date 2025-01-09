using Code.NodeBasedSystem.Core.Datas;
using NodeBasedSystem.Nodes;
using NodeBasedSystem.Nodes.Attributes;

namespace Code.NodeBasedSystem.DialogueSystem
{
    [NodeSystem, NodeComponent("Диалоговая система. Показать","#c1c814")] 
    public class DialoguePhraseComponent : INodeEventComponent { public LocalizedStringData Value = new(); }
}
