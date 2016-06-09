using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
            var lines = CreateLines();

            var winner = CheckWinner(lines);

            return winner;
        }

        private IEnumerable<string> CreateLines()
        {
            var lines = new List<string>();

            for (var cellIndex = 0; cellIndex < 3; cellIndex++)
            {
                var horizontalLine = CreateHorizontalLine(cellIndex);

                var verticalLine = CreateVerticalLine(cellIndex);

                lines.Add(horizontalLine);
                lines.Add(verticalLine);
            }
            return lines;
        }

        private static string CheckWinner(IEnumerable<string> lines)
        {
            var winnerStatus = string.Empty;

            if (lines.Any(line => line == WINNERX))
            {
                winnerStatus = "THE WINNER IS X";
            }

            return winnerStatus;
        }

        private string CreateDiagonalRightToLeft()
        {
            var diagonal2 = string.Concat(
                _playBoard[0, 2].ToString(),
                _playBoard[1, 1].ToString(),
                _playBoard[2, 0].ToString());
            return diagonal2;
        }

        private string CreateDiagonalLeftToRight()
        {
            var diagonal1 = string.Concat(
                _playBoard[0, 0].ToString(),
                _playBoard[1, 1].ToString(),
                _playBoard[2, 2].ToString());
            return diagonal1;
        }

        private string CreateVerticalLine(int cellIndex)
        {
            var verticalLine = string.Concat(
                _playBoard[0, cellIndex].ToString(),
                _playBoard[1, cellIndex].ToString(),
                _playBoard[2, cellIndex].ToString());
            return verticalLine;
        }

        private string CreateHorizontalLine(int cellIndex)
        {
            var horizontalLine = string.Join(
                _playBoard[cellIndex, 0].ToString(),
                _playBoard[cellIndex, 1].ToString(),
                _playBoard[cellIndex, 2].ToString());
            return horizontalLine;
        }
    }
}