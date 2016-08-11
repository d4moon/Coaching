using System;
using InstrumentProcessor.Interfaces;
using Nerdle.Ensure;

namespace InstrumentProcessor
{
    internal class Instrument : IInstrument
    {
        public void Execute(string task)
        {
            Ensure.Argument(task, nameof(task)).NotNull();
        }

        public event EventHandler Finished;
        public event EventHandler Error;
    }
}