using System;
namespace Day25
{
    public struct Action
    {
        public bool WriteValue { get; }
        public Direction Direction { get; }
        public char NextState { get; }

        public Action(bool writeValue, Direction direction, char nextState) {
            WriteValue = writeValue;
            Direction = direction;
            NextState = nextState;
        }

        public override string ToString()
        {
            return string.Format("[Action: WriteValue={0}, Direction={1}, NextState={2}]", WriteValue, Direction, NextState);
        }
    }
}
