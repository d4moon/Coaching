using System;
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

    [TestFixture]
    class Instrument_processor_should
    {
        [Test]
        public void Get_a_task_when_processing()
        {
            var taskDispatcher = new Mock<ITaskDispatcher>();
            var instrument = new Mock<IInstrument>();

            new InstrumentProcessor(taskDispatcher.Object, instrument.Object); 

            taskDispatcher.Verify(t => t.GetTask(), Times.Once());
        }
    }

    public class InstrumentProcessor: IInstrumentProcessor
    {
        private readonly ITaskDispatcher _taskDispatcher;

        public InstrumentProcessor(ITaskDispatcher taskDispatcher, IInstrument instrument)
        {
            _taskDispatcher = taskDispatcher;
            Ensure.Argument(taskDispatcher, nameof(taskDispatcher)).NotNull();
            Ensure.Argument(instrument, nameof(instrument)).NotNull();

            Process();
        }

        public void Process()
        {
            _taskDispatcher.GetTask();
        }
    }

    public interface IInstrument
    {
        void Execute(string task);

        event EventHandler Finished;
        event EventHandler Error;

    }

    public interface ITaskDispatcher
    {
        string GetTask();
        void FinishedTask(string task);

    }

    public interface IInstrumentProcessor
    {
        void Process();
    }

}
