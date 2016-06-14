using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Src;

namespace TickTackToeApplication
{
    class Program
    {
        private static TicTacToeService _tickTackToe;

        static void Main(string[] args)
        {
            _tickTackToe = new TicTacToeService();
            Console.WriteLine("Welcome");

            PlayTurn();

        }

        private static void PlayTurn()
        {
            
            Console.Write("Player input (with ,): ");
            var input = Console.ReadLine();
            var row = new Row(int.Parse(input.Split(',')[0]));
            var col = new Column(int.Parse(input.Split(',')[1]));
            var board = _tickTackToe.Play(row, col);
            Console.Clear();
            if (!board.Contains("WINNER"))
            {
                for (int i = 0; i < board.Length; i++)
                {
                    
                    if ((i+1) % 3 == 0)
                    {
                        Console.WriteLine(board[i]);
                    }
                    else
                    {
                        Console.Write(board[i]);
                    }
                }

                PlayTurn();
            }
            Console.WriteLine(board);
            Console.WriteLine("Bye");
            Console.Read();
        }
    }
}
