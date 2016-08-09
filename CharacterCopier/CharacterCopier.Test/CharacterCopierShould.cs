﻿using System;
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
        public void Get_characters_from_source_given_valid_source()
        {
            var sourceMock = new Mock<ISource>();

            var characterCopier = new CharacterCopier(sourceMock.Object, new DestinationMock());

            sourceMock.Verify(s => s.GetChars(), Times.Once());
        }
    }
    
    internal class DestinationMock : IDestination
    {
    }

    internal interface ISource
    {
        void GetChars();
    }

    internal interface IDestination
    {
    }
}
