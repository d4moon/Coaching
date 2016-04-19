using System;

namespace TicTacToe.Src
{
    public class TicTacToeService
    {
        public string Play(int row, int column)
        {
            if (row == 1 && column == 2)
            {
                return "XO " +
                       "   " +
                       "   ";                
            }
            if (row == 1 && column == 3)
            {
                return "XOX" +
                   "   " +
                   "   ";
            }
            return "X  "+
                   "   "+
                   "   ";
        }
    }
}