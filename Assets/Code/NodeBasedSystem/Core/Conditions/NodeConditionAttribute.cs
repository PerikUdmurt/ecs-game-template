using System;

namespace Code.NodeBasedSystem.Core.Conditions
{
    public class NodeConditionAttribute : Attribute
    {
        public string Name { get; }
        
        public NodeConditionAttribute(string name)
        {
            Name = name;
        }
    }
}