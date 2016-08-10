using System;
using System.Linq.Expressions;
using FluentAssertions;
using Moq;
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

        [Test]
        public void Get_character_from_source_once_given_source_returned_newline()
        {
            var sourceMock = new Mock<ISource>();
            sourceMock.Setup(s => s.GetChar()).Returns('\n');
            var characterCopier = new CharacterCopier(sourceMock.Object, new DestinationMock());

            characterCopier.Copy();

            sourceMock.Verify(s => s.GetChar(), Times.Once());
        }

        [Test]
        public void Get_all_characters_from_source_given_source_returnes_characters()
        {
            var sourceMock = new Mock<ISource>();
            sourceMock.SetupSequence(s => s.GetChar()).Returns('A').Returns('B').Returns('\n');
            var characterCopier = new CharacterCopier(sourceMock.Object, new DestinationMock());

            characterCopier.Copy();

            sourceMock.Verify(s => s.GetChar(), Times.Exactly(3));
        }
    }
    
    internal class DestinationMock : IDestination
    {
    }

    internal interface ISource
    {
        char GetChar();
    }

    internal interface IDestination
    {
    }
}
