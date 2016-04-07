using FluentAssertions;
using NUnit.Framework;

namespace RomanNumbers.Tests
{
    [TestFixture]
    public class RomanNumbersShould
    {
        
        [TestCase(1,"I")]
        [TestCase(2,"II")]
        [TestCase(3,"III")]
        [TestCase(4,"IV")]
        public void return_roman_number_given_arabic_number(int arabicNumber, string expectedRomanNumber)
        {
            var romanNumbers = new Src.RomanNumbers();

            var romanNumber = romanNumbers.GetRomanNumber(arabicNumber);
            
            romanNumber.Should().Be(expectedRomanNumber);
        }

    }
}
