namespace TicTacToe.Src
{
    public class TicTacToeService
    {
        private readonly PlayBoard _playBoard;
        private readonly BoardRenderer _renderer;
        private Sign _currentSign;

        public TicTacToeService()
        {
            _playBoard = new PlayBoard();
            _renderer = new BoardRenderer(_playBoard);
            _currentSign = Sign.O;
        }

        public string Play(Row row, Column column)
        {
            var currentSign = CurrentSign();
            _playBoard.Move(row, column, currentSign);
            return _renderer.PrettyPrint();
        }

        private Sign CurrentSign()
        {
            if (_currentSign == Sign.O)
            {
                _currentSign = Sign.X;
                return _currentSign;
            }

            _currentSign = Sign.O;
            return _currentSign;

        }
    }

    public enum Sign 
    {
        Empty,
        O,
        X

    }
}