namespace TicTacToe.Src
{
    internal class PlayBoard
    {
        private const int ROWS = 3;
        private const int COLUMNS = 3;

        private readonly Sign[,] _playBoard = new Sign[ROWS, COLUMNS];

        public void Move(Row row, Column column, Sign sign)
        {
            _playBoard[row.Value - 1, column.Value - 1] = sign;
        }

        public void Accept(BoardRenderer boardRenderer)
        {
            boardRenderer.Set(_playBoard);
        }
    }
}