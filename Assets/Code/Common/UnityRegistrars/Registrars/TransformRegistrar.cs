using Code.Infrastructures.View;

namespace Code.Common.Unity.Registrars
{
    public sealed class TransformRegistrar : EntityComponentRegistrar
    {
        public override void RegisterComponent() =>
            Entity.AddTransform(transform);

        public override void UnregisterComponent() =>
            Entity.RemoveTransform();
    }
}