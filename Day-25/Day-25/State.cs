using System;
namespace Day25
{
    public struct State
    {
        public char Id { get; }
        public Action IfFalse { get; }
        public Action IfTrue { get; }

        public State(char id, Action ifFalse, Action ifTrue) {
            Id = id;
            IfFalse = ifFalse;
            IfTrue = ifTrue;
        }

        public Action NextAction(bool input) {
            if (input) return IfTrue;
            return IfFalse;
        }

        public override string ToString()
        {
            return string.Format("[State: Id={0}, IfFalse={1}, IfTrue={2}]", Id, IfFalse, IfTrue);
        }
    }
}
