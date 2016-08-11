using System;
using NUnit.Framework;
using FluentAssertions;
using InstrumentProcessor.Interfaces;
using Moq;

namespace InstrumentProcessorTests
{
    [TestFixture]
    class Constructing_instrument_processor_should
    {
        [Test]
        public void Throw_an_exception_given_no_task_dispatcher()
        {
            var instrument = new Mock<IInstrument>();
            Action action = () => new InstrumentProcessor.InstrumentProcessor(null, instrument.Object);

            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void Throw_an_exception_given_no_instrument()
        {
            var taskDispatcher = new Mock<ITaskDispatcher>();

            Action action = () => new InstrumentProcessor.InstrumentProcessor(taskDispatcher.Object, null);

            action.ShouldThrow<ArgumentNullException>();
        }
    }
}
