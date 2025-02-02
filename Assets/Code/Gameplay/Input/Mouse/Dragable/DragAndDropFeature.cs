using Code.Gameplay.Input.Mouse.Dragable.Systems;
using Code.Infrastructures.Factories;
using JetBrains.Annotations;

namespace Code.Gameplay.Input.Mouse.Dragable
{
    [UsedImplicitly]
    public class DragAndDropFeature : Feature
    {
        public DragAndDropFeature(ISystemFactory factory)
        {
            Add(factory.Create<MouseDragAndDropSystem>());
            Add(factory.Create<DroppedCleanUpSystem>());
            Add(factory.Create<StartDragCleanUpSystem>());
        }
    }
}
