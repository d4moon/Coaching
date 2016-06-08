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

        //[TestCase("XOX      ", new[] { 1, 1, 1, 2, 1, 3 })]
        [TestCase("X        ", new[] { 1, 1 })]
        [TestCase("XO       ", new[] { 1, 1, 1, 2 })]
        [TestCase("XOOXXO   ", new[] { 1, 1, 1, 2, 2, 1, 1, 3, 2, 2, 2, 3 })]
        [TestCase("THE WINNER IS X", new[] { 1, 1, 1, 2, 2, 1, 1, 3, 2, 2, 2, 3, 3, 1 })]
        public void render_game_status_for_given_input(string expectedGameStatus, int[] moves)
        {
            var gameStatus = PlayMoves(moves);

            gameStatus.Should().Be(expectedGameStatus);
        }

        private string PlayMoves(int[] moves)
        {
            string gameStatus = null;
            for (int i = 0; i < moves.Length; i = i + 2)
            {
                gameStatus = _ticTacToe.Play(new Row(moves[i]), new Column(moves[i + 1]));
            }
            return gameStatus;
        }
    }


}
