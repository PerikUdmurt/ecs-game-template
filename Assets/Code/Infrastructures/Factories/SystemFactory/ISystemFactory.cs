using Entitas;

namespace Code.Infrastructures.Factories
{
    public interface ISystemFactory
    {
        T Create<T>(params object[] args) where T : ISystem;
        T Create<T>() where T : ISystem;
    }
}