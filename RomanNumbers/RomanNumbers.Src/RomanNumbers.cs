namespace RomanNumbers.Src
{
    public class RomanNumbers
    {
        public string GetRomanNumber(int arabicNumber)
        {
            var romanNumbersArray = new[] { "I", "II", "III", "IV" };
            return romanNumbersArray[arabicNumber - 1];
        }
    }
}