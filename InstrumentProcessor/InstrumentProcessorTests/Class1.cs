using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using Moq;
using Nerdle.Ensure;

namespace InstrumentProcessorTests
{
    [TestFixture]
    public class Constructing_instrument_processor_should
    {
        [Test]
        public void Throw_an_exception_given_no_task_dispatcher()
        {
            var instrument = new Mock<IInstrument>();
            Action action = () => new InstrumentProcessor(null, instrument.Object);

            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void Throw_an_exception_given_no_instrument()
        {
            var taskDispatcher = new Mock<ITaskDispatcher>();

            Action action = () => new InstrumentProcessor(taskDispatcher.Object, null);

            action.ShouldThrow<ArgumentNullException>();
        }

    }

    public interface IInstrument
    {
    }

    public class InstrumentProcessor
    {
        public InstrumentProcessor(ITaskDispatcher taskDispatcher, IInstrument instrument)
        {
            Ensure.Argument(taskDispatcher, nameof(taskDispatcher)).NotNull();
            Ensure.Argument(instrument, nameof(instrument)).NotNull();
        }
    }

    public interface ITaskDispatcher
    {

    }
}
