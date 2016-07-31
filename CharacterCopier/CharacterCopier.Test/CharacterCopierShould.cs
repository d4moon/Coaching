using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

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
    }

    internal class CharacterCopier
    {
        public CharacterCopier(ISource source, IDestination destination)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (destination == null)
            {
                throw new ArgumentNullException();
            }
        }
    }

    internal class SourceMock : ISource
    {
    }

    internal class DestinationMock : IDestination
    {
    }

    internal interface ISource
    {
    }

    internal interface IDestination
    {
    }
}
