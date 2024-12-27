using NodeBasedSystem.Nodes;
using NodeBasedSystem.Nodes.Attributes;

[NodeSystem, NodeComponent("Диалоговая система. Показать","#c1c814")] 
public class DialoguePhraseComponent : INodeEventComponent { public string Value; }
