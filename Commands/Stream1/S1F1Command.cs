namespace SML_Generator
{
    public class S1F1Command : ISecsCommand
    {
        public string Name => "S1F1";
        public string Description =>
            "Are You There Request - Checks whether the equipment is communicating.";
        public S1F1Command()
        {

        }
        public virtual string Generate()
        {
            return "S1F1 W";
        }
    }
}
