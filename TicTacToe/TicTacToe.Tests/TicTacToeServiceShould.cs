﻿using FluentAssertions;
using NUnit.Framework;
using TicTacToe.Src;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class TicTacToeServiceShould
    {
        [Test]
        public void AllocateInputToX_GivenFirstInput()
        {
            const string expectedXPosition = "X  " +
                                             "   " +
                                             "   ";
            var ticTacToe = new TicTacToeService();
            
            var gameResult = ticTacToe.Play(1, 1);

            gameResult.Should().Be(expectedXPosition);
        }

        [Test]
        public void AllocateInputToO_GivenSecondInput()
        {
            const string expectedXPosition = "XO " +
                                            "   " +
                                            "   ";
            var ticTacToe = new TicTacToeService();

            var gameResult = ticTacToe.Play(1, 2);

            gameResult.Should().Be(expectedXPosition);
        }

    }
}
