using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Nerdle.Ensure;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace CharacterCopier.Test
{
    [TestFixture]
    class CharacterCopierShould
    {
        [Test]
        public void Throw_an_exception_given_source_is_null()
        {
            Action action = () => new CharacterCopier(null, new DestinationMock());
            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Test]
        public void Throw_an_exception_given_destination_is_null()
        {
            Action action = () => new CharacterCopier(new SourceMock(), null);
            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void Get_char_from_source_given_valid_source()
        {
            var source = new Mock<ISource>();

            var characterCopier = new CharacterCopier(source.Object, new DestinationMock());

            source.Verify(s => s.GetChar(), Times.Once());
        }
    }

    internal class CharacterCopier
    {
        public CharacterCopier(ISource source, IDestination destination)
        {
            Ensure.Argument(source, nameof(source)).NotNull();
            Ensure.Argument(destination, nameof(destination)).NotNull();

            source.GetChar();
        }
    }

    internal class SourceMock : ISource
    {
        public void GetChar()
        {
            throw new NotImplementedException();
        }
    }

    internal class DestinationMock : IDestination
    {
    }

    internal interface ISource
    {
        void GetChar();
    }

    internal interface IDestination
    {
    }
}
