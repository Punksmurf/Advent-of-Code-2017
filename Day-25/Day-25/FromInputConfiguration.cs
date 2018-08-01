using System;
using System.Collections.Generic;

namespace Day25
{
    public class FromInputConfiguration : ITuringMachineConfiguration
    {
        //Ain't nobody got time for that
        public FromInputConfiguration(string input) => throw new NotImplementedException();

        public int NumberOfRuns => throw new NotImplementedException();

        public char InitialState => throw new NotImplementedException();

        public Dictionary<char, State> States => throw new NotImplementedException();
    }
}
