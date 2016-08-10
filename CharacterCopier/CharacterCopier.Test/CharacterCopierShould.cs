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
        private const char A_NEW_LINE_CHAR = '\n';
        private const char A_CHARACTER = 'A';
        private Mock<IDestination> _destinationMock;
        private Mock<ISource> _sourceMock;

        [SetUp]
        public void SetUp()
        {
            _destinationMock = new Mock<IDestination>();
            _sourceMock = new Mock<ISource>();
        }

        [Test]
        public void Throw_an_exception_given_source_is_null()
        {
            Action action = () => new CharacterCopier(null, _destinationMock.Object);
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
            _sourceMock.Setup(s => s.GetChar()).Returns(A_NEW_LINE_CHAR);
            var characterCopier = new CharacterCopier(_sourceMock.Object, _destinationMock.Object);

            characterCopier.Copy();

            _sourceMock.Verify(s => s.GetChar(), Times.Once());
        }

        [Test]
        public void Get_all_characters_from_source_given_source_returnes_characters()
        {
            _sourceMock.SetupSequence(s => s.GetChar()).Returns(A_CHARACTER).Returns(A_CHARACTER).Returns(A_NEW_LINE_CHAR);
            var characterCopier = new CharacterCopier(_sourceMock.Object, _destinationMock.Object);

            characterCopier.Copy();

            _sourceMock.Verify(s => s.GetChar(), Times.Exactly(3));
        }

        [Test]
        public void Not_copy_characters_to_destination_given_character_is_new_line()
        {
            _sourceMock.Setup(s => s.GetChar()).Returns(A_NEW_LINE_CHAR);
            var characterCopier = new CharacterCopier(_sourceMock.Object, _destinationMock.Object);

            characterCopier.Copy();

            _destinationMock.Verify(s => s.SetChar(A_NEW_LINE_CHAR), Times.Never());
        }
    }
}
