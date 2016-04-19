using FluentAssertions;
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
    }
}
