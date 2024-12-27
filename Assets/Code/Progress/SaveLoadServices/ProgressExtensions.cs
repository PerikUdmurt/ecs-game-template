using System;
using System.Linq;
using Code.Common.Extensions;
using Code.Progress.Data;
using Entitas;
using Unity.VisualScripting.FullSerializer;

namespace Code.Progress.SaveLoadServices
{
    public static class ProgressExtensions
    {
        public static EntitySnapshot AsSaveEntity(this ProgressEntity progressEntity)
        {
            IComponent[] components = progressEntity.GetComponents();

            return new EntitySnapshot()
            {
                components = components
                    .Where(c => c is IProgressComponent)
                    .Cast<IProgressComponent>()
                    .ToList()
            };
        }

        public static IEntity HydrateWith(this IEntity entity, EntitySnapshot snapshot)
        {
            foreach (var component in snapshot.components)
            {
                int lookupIndex = LookupIndexOf(component, entity);
                entity.With(x => x.ReplaceComponent(lookupIndex, component), when: lookupIndex >= 0);
            }
            
            return entity;
        }
        
        public static int LookupIndexOf(IProgressComponent component, IEntity entity) =>
        Array.IndexOf(ComponentTypes(entity), component.GetType());

        private static Type[] ComponentTypes(IEntity entity)
        {
            return entity switch
            {
                ProgressEntity => ProgressComponentsLookup.componentTypes,
                _ => throw new ArgumentException($"Invalid entity type: {entity.GetType().FullName}")
            };
        }
    }
}