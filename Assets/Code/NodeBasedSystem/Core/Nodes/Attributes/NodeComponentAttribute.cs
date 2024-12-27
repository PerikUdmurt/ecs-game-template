using System;

namespace NodeBasedSystem.Nodes.Attributes
{
    public class NodeComponentAttribute : Attribute
    {
        public string Name;
        public string Hex;

        public NodeComponentAttribute(string name, string hex)
        {
            Name = name;
            Hex = hex;
        }
    }
}