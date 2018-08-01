using System;
namespace Day15
{
    public class Generator
    {
        int _lastValue;
        int _multiplier;
        int _pickyAbout;

        public Generator(int seed, int multiplier, int pickyAbout = 1)
        {
            _lastValue = seed;
            _multiplier = multiplier;
            _pickyAbout = pickyAbout;
        }

        public int Current() => _lastValue;

        public int Next() {
            do
            {
                _lastValue = (int)(((long)_lastValue * _multiplier) % 2147483647);
            } while (_lastValue % _pickyAbout != 0);

            return Current();
        }
    }
}
