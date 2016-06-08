using System;
using Moq;
using NUnit.Framework;

namespace CharacterCopier.Test
{
    [TestFixture]
    public class CopierShould
    {
        private Mock<ISource> _source;
        private Mock<IDestination> _destination;
        private Copier _copier;

        [SetUp]
        public void Setup()
        {
            _source = new Mock<ISource>();
            _destination = new Mock<IDestination>();
            _copier = new Copier(_source.Object, _destination.Object);            
        }


        [Test]
        public void retreive_one_character_from_source()
        {
            _copier.Copy();

            _source.Verify(s => s.GetChar(),Times.Once);
        }

        [TestCase('A')]
        [TestCase('B')]
        public void write_to_destination_given_one_character_from_source(char sourceCharacter)
        {
            _source.Setup(s => s.GetChar()).Returns(sourceCharacter);
            
            _copier.Copy();

            _destination.Verify(d => d.SetChar(sourceCharacter), Times.Once);
        }

        [Test]
        public void not_copy_when_given_a_new_line()
        {
            _source.Setup(s => s.GetChar()).Returns('\n');

            _copier.Copy();

            _destination.Verify(d=>d.SetChar(It.IsAny<char>()),Times.Never);
        }
        
    }
}