using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace InstrumentProcessorKata.Test
{
    [TestFixture]
    public class InstrumentProcessorShould
    {
        private Mock<ITaskDispatcher> _taskDispatcher;
        private Mock<IInstrument> _instrument;
        private InstrumentProcessor _instrumentProcessor;
        private const string A_TASK = "A Task";

        [SetUp]
        public void Setup()
        {
            _taskDispatcher = new Mock<ITaskDispatcher>();
            _instrument = new Mock<IInstrument>();
            _instrumentProcessor = new InstrumentProcessor(_taskDispatcher.Object, _instrument.Object);
        }

        [Test]
        public void request_a_task_from_despatcher_when_processing()
        {
            _instrumentProcessor.Process();

            _taskDispatcher.Verify(t => t.GetTask());
        }

        [Test]
        public void execute_the_retrieved_task_when_processing()
        {
            _taskDispatcher.Setup(t => t.GetTask()).Returns(A_TASK);
            
            _instrumentProcessor.Process();

            _instrument.Verify(i => i.Execute(A_TASK));
        }

        [Test]
        public void throw_an_exception_when_processing_given_instrument_execute_throws_exception()
        {
            _instrument.Setup(i => i.Execute(It.IsAny<string>())).Throws<Exception>();
            
            Action processing = () => _instrumentProcessor.Process();

            processing.ShouldThrow<Exception>();
        }

        [Test]
        public void finish_task_when_processing_given_instrument_raised_is_finished()
        {
            _taskDispatcher.Setup(t => t.GetTask()).Returns(A_TASK);
            _instrument
                .Setup(i => i.Execute(A_TASK))
                .Raises(i => i.Finished += null, 
                        new TaskEventArgs(A_TASK));

            _instrumentProcessor.Process();

            _taskDispatcher.Verify(t => t.FinishedTask(A_TASK));
        }
    }
}