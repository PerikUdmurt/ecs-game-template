using System;
using Code.Common.Extensions;
using Code.NodeBasedSystem.GraphLoaders;
using Entitas;
using NodeBasedSystem.Nodes;

namespace Code.NodeBasedSystem
{
    public static class NodeSystemExtensions
    {
        public static IEntity HydrateWith(this IEntity entity, NodeEntitySnapshot snapshot)
        {
            foreach (var component in snapshot.components)
            {
                int lookupIndex = LookupIndexOf(component, entity);
                entity.With(x => x.ReplaceComponent(lookupIndex, component), when: lookupIndex >= 0);
            }
            
            return entity;
        }
    
        public static int LookupIndexOf(INodeComponent component, IEntity entity) =>
            Array.IndexOf(ComponentTypes(entity), component.GetType());

        private static Type[] ComponentTypes(IEntity entity)
        {
            return entity switch
            {
                NodeSystemEntity => NodeSystemComponentsLookup.componentTypes,
                _ => throw new ArgumentException($"Invalid entity type: {entity.GetType().FullName}")
            };
        }
    }
}
