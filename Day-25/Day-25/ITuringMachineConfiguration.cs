using System;
using System.Collections.Generic;

namespace Day25
{
    public interface ITuringMachineConfiguration
    {
        int NumberOfRuns { get; }
        char InitialState { get; }
        Dictionary<char, State> States { get; }
    }
}
