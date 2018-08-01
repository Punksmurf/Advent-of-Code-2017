using System;
using System.Collections.Generic;

namespace Day25
{
    public class FixedConfiguration : ITuringMachineConfiguration
    {
        public int NumberOfRuns => 12481997;

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
            //    - Continue with state C.
            {'A', new State('A',
                            new Action(true, Direction.RIGHT, 'B'),
                            new Action(false, Direction.LEFT, 'C')) },


            //In state B:
            //  If the current value is 0:
            //    - Write the value 1.
            //    - Move one slot to the left.
            //    - Continue with state A.
            //  If the current value is 1:
            //    - Write the value 1.
            //    - Move one slot to the right.
            //    - Continue with state D.
            {'B', new State('B',
                            new Action(true, Direction.LEFT, 'A'),
                            new Action(true, Direction.RIGHT, 'D')) },

            //In state C:
            //  If the current value is 0:
            //    - Write the value 0.
            //    - Move one slot to the left.
            //    - Continue with state B.
            //  If the current value is 1:
            //    - Write the value 0.
            //    - Move one slot to the left.
            //    - Continue with state E.
            {'C', new State('C',
                            new Action(false, Direction.LEFT, 'B'),
                            new Action(false, Direction.LEFT, 'E')) },

            //In state D:
            //  If the current value is 0:
            //    - Write the value 1.
            //    - Move one slot to the right.
            //    - Continue with state A.
            //  If the current value is 1:
            //    - Write the value 0.
            //    - Move one slot to the right.
            //    - Continue with state B.
            {'D', new State('D',
                            new Action(true, Direction.RIGHT, 'A'),
                            new Action(false, Direction.RIGHT, 'B')) },

            //In state E:
            //  If the current value is 0:
            //    - Write the value 1.
            //    - Move one slot to the left.
            //    - Continue with state F.
            //  If the current value is 1:
            //    - Write the value 1.
            //    - Move one slot to the left.
            //    - Continue with state C.
            {'E', new State('E',
                            new Action(true, Direction.LEFT, 'F'),
                            new Action(true, Direction.LEFT, 'C')) },

            //In state F:
            //  If the current value is 0:
            //    - Write the value 1.
            //    - Move one slot to the right.
            //    - Continue with state D.
            //  If the current value is 1:
            //    - Write the value 1.
            //    - Move one slot to the right.
            //    - Continue with state A.
            {'F', new State('F',
                            new Action(true, Direction.RIGHT, 'D'),
                            new Action(true, Direction.RIGHT, 'A')) },
        };
    }
}
