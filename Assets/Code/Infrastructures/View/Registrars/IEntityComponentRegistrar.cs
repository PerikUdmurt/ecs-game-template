namespace Code.Infrastructures.View
{
    public interface IEntityComponentRegistrar
    {
        void RegisterComponent();
        void UnregisterComponent();
    }
}