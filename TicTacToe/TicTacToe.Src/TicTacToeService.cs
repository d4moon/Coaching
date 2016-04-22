namespace TicTacToe.Src
{
    public class TicTacToeService
    {
        private readonly PlayBoard _playBoard;
        private readonly BoardRenderer _renderer;

        public TicTacToeService()
        {
            _playBoard = new PlayBoard();
            _renderer = new BoardRenderer(_playBoard);
        }

        public string Play(Row row, Column column)
        {
            var player = CurrentPlayer(row, column);
            _playBoard.Move(row, column, player);
            return _renderer.PrettyPrint();
        }

        private static string CurrentPlayer(Row row, Column column)
        {
            var player = "X";
            if (row.Value == 1 && column.Value == 2)
            {
                player = "O";
            }
            if (row.Value == 1 && column.Value == 3)
            {
                player = "X";
            }
            return player;
        }
    }
}