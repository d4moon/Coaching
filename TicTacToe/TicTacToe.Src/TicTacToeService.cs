using System;
using System.Text;

namespace TicTacToe.Src
{
    public class TicTacToeService
    {
        string[,] playBoard = new string[3,3];
        
        public string Play(int row, int column)
        {

            playBoard[row - 1, column - 1] = "X";
   
            if (row == 1 && column == 2)
            {
                playBoard[row - 1, column - 1] = "O";
            }
            if (row == 1 && column == 3)
            {
                playBoard[row - 1, column - 1] = "X";
            }
            var result = new StringBuilder();
            foreach (var character in playBoard)
            {
                if (string.IsNullOrEmpty(character))
                {
                    result.Append(" ");
                }
                else
                {
                    result.Append(character);    
                }
                
            }
            return result.ToString();
        }


    }
}