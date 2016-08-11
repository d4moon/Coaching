using System;
using FluentAssertions;
using InstrumentProcessor;
using NUnit.Framework;

namespace InstrumentProcessorTests
{
    [TestFixture]
    class Executing_instrument_should
    {
        [Test]
        public void Throw_an_exception_given_no_task()
        {
            var instrument = new Instrument();

            Action action = () => instrument.Execute(null);

            action.ShouldThrow<ArgumentNullException>();
        }
    }
}