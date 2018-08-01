using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day25
{
    public class TuringMachine
    {
        ITuringMachineConfiguration _configuration;
        LinkedList<bool> _tape = new LinkedList<bool>();

        State _currentState;
        LinkedListNode<bool> _cursor;

        public TuringMachine(ITuringMachineConfiguration configuration) {
            _configuration = configuration;
            _currentState = GetState(_configuration.InitialState);
            _cursor = _tape.AddLast(false);
        }

        public void Step() {

            //Console.WriteLine($"Running state {_currentState.Id}");

            var action = _currentState.NextAction(_cursor.Value);

            //Console.WriteLine($"Cursor: {_cursor.Value} results in Action: {action}");

            _cursor.Value = action.WriteValue;
            Move(action.Direction);
            _currentState = GetState(action.NextState);

            //Console.WriteLine(this);
        }

        void Move(Direction direction) {
            switch(direction) {
                case Direction.LEFT:
                    _cursor = _cursor.Previous ?? _tape.AddFirst(false);
                    break;
                case Direction.RIGHT:
                    _cursor = _cursor.Next ?? _tape.AddLast(false);
                    break;
            }
        }

        public int CalculateChecksum() {
            return _tape.Where(b => b).Count();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            var n = _tape.First;
            while (n != null) {
                sb.Append(n == _cursor ? '[' : ' ');
                sb.Append(n.Value ? '1' : '0');
                sb.Append(n == _cursor ? ']' : ' ');

                n = n.Next;
            }

            return sb.ToString();
        }

        State GetState(char id) {
            return _configuration.States[id];
        }
    }
}
