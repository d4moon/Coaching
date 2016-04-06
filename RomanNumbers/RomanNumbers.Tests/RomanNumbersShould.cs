using FluentAssertions;
using NUnit.Framework;

namespace RomanNumbers.Tests
{
    [TestFixture]
    public class RomanNumbersShould
    {
        [Test]
        public void return_roman_I_given_arabic_1()
        {
            var romanNumbers = new Src.RomanNumbers();

            var romanNumber = romanNumbers.GetRomanNumber(1);
            
            romanNumber.Should().Be("I");
        }
    }
}
