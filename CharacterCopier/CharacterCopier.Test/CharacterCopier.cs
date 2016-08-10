using Nerdle.Ensure;

namespace CharacterCopier.Test
{
    internal class CharacterCopier
    {
        private readonly ISource _source;

        public CharacterCopier(ISource source, IDestination destination)
        {
            _source = source;
            Ensure.Argument(source, nameof(source)).NotNull();
            Ensure.Argument(destination, nameof(destination)).NotNull();
        }

        public void Copy()
        {
            var character = _source.GetChar();
            if (character != '\n')
            {
                Copy();
            }
        }
    }
}