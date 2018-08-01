using System;
using System.Collections.Generic;

namespace Day25
{
    public class TestConfiguration : ITuringMachineConfiguration
    {
        public int NumberOfRuns => 6;

        public char InitialState => 'A';

        public Dictionary<char, State> States => new Dictionary<char, State> {
            // Based on my input

            //In state A:
            //  If the current value is 0:
            //    - Write the value 1.
            //    - Move one slot to the right.
            //    - Continue with state B.
            //  If the current value is 1:
            //    - Write the value 0.
            //    - Move one slot to the left.
            //    - Continue with state B.
            {'A', new State('A',
                            new Action(true, Direction.RIGHT, 'B'),
                            new Action(false, Direction.LEFT, 'B')) },


            //In state B:
            //  If the current value is 0:
            //    - Write the value 1.
            //    - Move one slot to the left.
            //    - Continue with state A.
            //  If the current value is 1:
            //    - Write the value 1.
            //    - Move one slot to the right.
            //    - Continue with state A.
            {'B', new State('B',
                            new Action(true, Direction.LEFT, 'A'),
                            new Action(true, Direction.RIGHT, 'A')) },

        };
    }
}
