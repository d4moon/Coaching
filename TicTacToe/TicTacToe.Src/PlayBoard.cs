namespace TicTacToe.Src
{
    internal class PlayBoard
    {
        private const int ROWS = 3;
        private const int COLUMNS = 3;
        private const string WINNERX = "XXX";
        private const string WINNERO = "OOO";

        private readonly Sign[,] _playBoard = new Sign[ROWS, COLUMNS];
        private Sign _lastPlayer = Sign.X;

        public void Move(Row row, Column column, Sign sign)
        {
            _lastPlayer = sign;
            _playBoard[row.Value - 1, column.Value - 1] = sign;
        }

        public void Accept(BoardRenderer boardRenderer)
        {
            boardRenderer.Set(_playBoard);
        }

        public string CheckStatus()
        {

            string horizontalLine;
            string verticalLine;
            string winner=null;


            for (int cellIndex = 0; cellIndex < 3; cellIndex++)
            {
                horizontalLine =
                    string.Join(
                    _playBoard[cellIndex, 0].ToString() , 
                    _playBoard[cellIndex, 1].ToString(), 
                    _playBoard[cellIndex, 2].ToString());

                verticalLine = string.Concat(
                    _playBoard[0,cellIndex].ToString(), 
                    _playBoard[1,cellIndex].ToString(), 
                    _playBoard[2,cellIndex].ToString());


                if (horizontalLine == WINNERX || verticalLine == WINNERX)
                {
                    winner = "THE WINNER IS X";
                    break;
                }

                if (horizontalLine == WINNERO || verticalLine == WINNERO)
                {
                    winner = "THE WINNER IS O";
                    break;
                }
            }

            var diagonal1 = string.Concat(
                _playBoard[0, 0].ToString(),
                _playBoard[1, 1].ToString(),
                _playBoard[2, 2].ToString());

            if (diagonal1 == WINNERX || diagonal1 == WINNERO)
            {
                winner = "THE WINNER IS " + _lastPlayer.ToString();
            }

            var diagonal2 = string.Concat(
                _playBoard[0, 2].ToString(),
                _playBoard[1, 1].ToString(),
                _playBoard[2, 0].ToString());

            if (diagonal2 == WINNERX || diagonal2 == WINNERO)
            {
                winner = winner = "THE WINNER IS " + _lastPlayer.ToString(); ;
            }

            return winner;
        }
    }
}