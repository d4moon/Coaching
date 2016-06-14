using System.Text;

namespace TicTacToe.Src
{
    internal class BoardRenderer
    {
        public BoardRenderer(PlayBoard board)
        {
            _board = board;
        }

        public string PrettyPrint()
        {
            _board.Accept(this);
            var renderedBoard = new StringBuilder();
            AppendSignsTo(renderedBoard);
            
            return renderedBoard.ToString();
        }

       

        public void Set(Sign[,] playBoard)
        {
            _playBoard = playBoard;
        }

        private readonly PlayBoard _board;
        private Sign[,] _playBoard;

        private void AppendSignsTo(StringBuilder result)
        {
            foreach (var move in _playBoard)
            {
                AppendSign(move, result);
            }
        }

        private static void AppendSign(Sign move, StringBuilder result)
        {
            var sign = GetSign(move);
            result.Append(sign);
        }

        private static string GetSign(Sign move)
        {
            var sign = " ";
            if (move != Sign.Empty)
            {
                sign = move.ToString();
            }
            return sign;
        }
    }
}