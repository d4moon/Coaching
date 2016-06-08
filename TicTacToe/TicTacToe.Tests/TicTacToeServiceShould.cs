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

        [TestCase("XOX      ", new[] { 1, 1, 1, 2, 1, 3 })]
        [TestCase("X        ", new[] { 1, 1 })]
        [TestCase("XO       ", new[] { 1, 1, 1, 2 })]
        public void allocate_correct_moves_for_given_input(string expectedBoard, int[] moves)
        {
            var renderedBoard = PlayMoves(moves);

            renderedBoard.Should().Be(expectedBoard);
        }

        private string PlayMoves(int[] moves)
        {
            string renderedBoard = null;
            for (int i = 0; i < moves.Length; i = i + 2)
            {
                renderedBoard = _ticTacToe.Play(new Row(moves[i]), new Column(moves[i + 1]));
            }
            return renderedBoard;
        }
    }


}
