using FluentAssertions;
using NUnit.Framework;
using TicTacToe.Src;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class TicTacToeServiceShould
    {
        private TicTacToeService _ticTacToe;

        [SetUp]
        public void Setup()
        {
            _ticTacToe = new TicTacToeService();
        }

        [Test]
        public void AllocateInputToX_GivenFirstInput()
        {
            const string expectedXPosition = "X  " +
                                             "   " +
                                             "   ";
            
            var gameResult = _ticTacToe.Play(new Row(1), new Column(1));

            gameResult.Should().Be(expectedXPosition);
        }

        [Test]
        public void AllocateInputToO_GivenSecondInput()
        {
            const string expectedXPosition = "XO " +
                                            "   " +
                                            "   ";
            _ticTacToe.Play(new Row(1), new Column(1));

            var gameResult = _ticTacToe.Play(new Row(1), new Column(2));

            gameResult.Should().Be(expectedXPosition);
        }

        [TestCase("XOX      ", new[] { 1, 1, 1, 2 })]
        public void mf(string expStuff, int[] moves)
        {
            for (int i = 0; i < moves.Length; i = i + 2)
            {
                _ticTacToe.Play(new Row(moves[i]), new Column(moves[i+1]));
            }
            var gameResult = _ticTacToe.Play(new Row(1), new Column(3));

            gameResult.Should().Be(expStuff);
        }

    }


}
