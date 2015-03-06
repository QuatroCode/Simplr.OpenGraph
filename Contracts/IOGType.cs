namespace Simplr.OpenGraph.Contracts
{
    public interface IOGType : IOGType<string>
    {

    }
    public interface IOGType<T>
    {
        T Type { get; }
    }
}
