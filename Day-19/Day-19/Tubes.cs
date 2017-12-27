using System;
using System.Collections.Generic;
using System.Linq;

namespace Day19
{
    public enum Direction {
        NORTH, SOUTH, WEST, EAST, STOP
    }

    public struct Tube {
        public int Length { get; private set; }
        public char[] Letters { get; private set; }
        public Tube(int length, char[] letters) {
            Length = length;
            Letters = letters;
        }
    }

    public class Tubes
    {
        char[][] _buffer;

        public Tubes(string input)
        {
            _buffer = input.Split('\n').Select(line => line.ToCharArray()).ToArray();
        }

        public int Width => _buffer[0].Count();
        public int Height => _buffer.Count();

        public char[][] GetWindow(int line, int col, int width, int height) {
            return _buffer.Skip(line).Take(height).Select(l => l.Skip(col).Take(width).ToArray()).ToArray();
        }

        public int FindStartX() {
            return Array.IndexOf(_buffer[0], '|');
        }

        public IEnumerable<Tube> GetTubes() {
            int x = FindStartX();
            int y = 0;
            Direction d = Direction.SOUTH;

            List<char> characters = new List<char>();
            int length = 0;

            while (true) {
                length++;

                switch (d) {
                    case Direction.NORTH: y--; break;
                    case Direction.SOUTH: y++; break;
                    case Direction.WEST: x--; break;
                    case Direction.EAST: x++; break;
                }

                var c = _buffer[y][x];
                if (c >= 'A' && c <= 'Z') characters.Add(c);
                if (c == '+' || c == ' ') {
                    var t = new Tube(length, characters.ToArray());
                    length = 0;
                    characters.Clear();
                    switch (d)
                    {
                        case Direction.NORTH:
                        case Direction.SOUTH:
                            if (_buffer[y][x - 1] != ' ') d = Direction.WEST;
                            else d = Direction.EAST;
                            break;
                        case Direction.WEST:
                        case Direction.EAST:
                            if (_buffer[y - 1][x] != ' ') d = Direction.NORTH;
                            else d = Direction.SOUTH;
                            break;
                    }
                    yield return t;
                    if (c == ' ') break;
                }
            }
        }

        public Direction NextMove(int x, int y, Direction from) {
            if (_buffer[y][x] == ' ') {
                return Direction.STOP;
            }

            if (_buffer[y][x] == '+') {
                // not really robust but good enough
                switch(from) {
                    case Direction.NORTH:
                    case Direction.SOUTH:
                        if (_buffer[y][x - 1] != ' ') return Direction.WEST;
                        return Direction.EAST;
                    case Direction.WEST:
                    case Direction.EAST:
                        if (_buffer[y - 1][x] != ' ') return Direction.NORTH;
                        return Direction.SOUTH;
                }
            } else {
                switch(from) {
                    case Direction.NORTH: return Direction.SOUTH;
                    case Direction.SOUTH: return Direction.NORTH;
                    case Direction.WEST: return Direction.EAST;
                    case Direction.EAST: return Direction.WEST;
                }
            }

            return Direction.STOP;
        }

        public char? GetLetter(int x, int y) {
            var c = _buffer[y][x];
            if (c >= 'A' && c <= 'Z') return c;
            return null;
        }
    }
}
