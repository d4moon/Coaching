using Nerdle.Ensure;

namespace CharacterCopier.Test
{
    internal class CharacterCopier
    {
        public CharacterCopier(ISource source, IDestination destination)
        {
            Ensure.Argument(source, nameof(source)).NotNull();
            Ensure.Argument(destination, nameof(destination)).NotNull();

            source.GetChars();
        }
    }
}