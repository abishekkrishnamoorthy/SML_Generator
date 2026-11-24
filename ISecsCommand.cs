namespace SML_Generator
{
    public interface ISecsCommand
    {
        string Name { get; }
        string Description { get; }
        string Generate();
    }
}
