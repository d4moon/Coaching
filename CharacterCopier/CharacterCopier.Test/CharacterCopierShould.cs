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

        [Test]
        public void Not_copy_characters_to_destination_given_character_is_new_line()
        {
            var A_NEW_LINE_CHAR = '\n';
            var destinationMock = new Mock<IDestination>();
            var sourceMock = new Mock<ISource>();
            sourceMock.Setup(s => s.GetChar()).Returns(A_NEW_LINE_CHAR);
            var characterCopier = new CharacterCopier(sourceMock.Object, destinationMock.Object);

            characterCopier.Copy();

            destinationMock.Verify(s => s.SetChar(A_NEW_LINE_CHAR), Times.Never());
        }

        [Test]
        public void Copy_received_characters_to_destination_given_valid_destination()
        {
            
        }
    }
    
    internal class DestinationMock : IDestination
    {
        public void SetChar(char character)
        {
            
        }
    }

    internal interface ISource
    {
        char GetChar();
    }

    internal interface IDestination
    {
        void SetChar(char character);
    }
}
