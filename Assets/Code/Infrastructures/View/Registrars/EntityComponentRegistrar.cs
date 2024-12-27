namespace Code.Infrastructures.View
{
    public abstract class EntityComponentRegistrar : EntityDependant, IEntityComponentRegistrar
    {
        public abstract void RegisterComponent();
        public abstract void UnregisterComponent();
    }
}