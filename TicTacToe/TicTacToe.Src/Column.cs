namespace TicTacToe.Src
{
    public class Column
    {
        public int Value { get; private set; }

        public Column(int column)
        {
            Value = column;
        }
    }
}