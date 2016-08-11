using InstrumentProcessor.Interfaces;
using Nerdle.Ensure;

namespace InstrumentProcessor
{
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
}