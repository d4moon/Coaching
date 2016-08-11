using InstrumentProcessor.Interfaces;
using Moq;
using NUnit.Framework;

namespace InstrumentProcessorTests
{
    [TestFixture]
    class Instrument_processor_should
    {
        [Test]
        public void Get_a_task_when_processing()
        {
            var taskDispatcher = new Mock<ITaskDispatcher>();
            var instrument = new Mock<IInstrument>();

            new InstrumentProcessor.InstrumentProcessor(taskDispatcher.Object, instrument.Object); 

            taskDispatcher.Verify(t => t.GetTask(), Times.Once());
        }

        [Test]
        [Ignore("TODO")]
        public void Finish_a_task_when_processing_completed()
        {
        }
    }
}