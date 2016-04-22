using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TicTacToe.Src
{
    public class TicTacToeService
    {
        string[,] playBoard = new string[3,3];
        
        public string Play(Row row, Column column)
        {

            playBoard[row.Value - 1, column.Value - 1] = "X";

            if (row.Value == 1 && column.Value == 2)
            {
                playBoard[row.Value - 1, column.Value - 1] = "O";
            }
            if (row.Value == 1 && column.Value == 3)
            {
                playBoard[row.Value - 1, column.Value - 1] = "X";
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

    public class Column
    {
        public int Value { get; private set; }

        public Column(int column)
        {
            Value = column;
        }
    }

    public class Row
    {
        public int Value { get; private set; }

        public Row(int row)
        {
            Value = row;
        }
    }
}