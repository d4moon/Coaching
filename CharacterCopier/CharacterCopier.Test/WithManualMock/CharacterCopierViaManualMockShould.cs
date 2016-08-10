using System;
using System.Linq.Expressions;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace CharacterCopier.Test
{
    [TestFixture]
    class CharacterCopierViaManualMockShould
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
        public void Get_characters_from_source_given_valid_source()
        {
            var source = new SourceMock();
            var sourceMock = new Mock<ISource>();

            var characterCopier = new CharacterCopier(source, new DestinationMock());


            //sourceMock.Verify(s => s.GetChar(), Times.Once());

            //source.CheckThat(s => s.GetChar(), Times.Once());

            source.CheckGetCharWasCalled();
        }

    }

    internal class SourceMock : ISource
    {
        private int _methodCallCounter;

        public SourceMock()
        {
            _methodCallCounter = 0;
        }
        public void GetChars()
        {
            _methodCallCounter++;
        }

        public void CheckThat(Expression<Action<object>> expression, Times times)
        {

        }

        public bool CheckGetCharWasCalled()
        {
            return _methodCallCounter > 0;

        }

        public char GetChar()
        {
            return '\n';
        }
    }
}
