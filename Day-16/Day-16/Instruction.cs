using System;
using System.Text.RegularExpressions;

namespace Day16
{
    public abstract class Instruction
    {
        public int A { get; private set; }
        public int B { get; private set; }

        protected Instruction(int a, int b) {
            A = a;
            B = b;
        }

        public static class Factory {

            const string spin = @"(s)(\d+)";
            const string exchange = @"(x)(\d+)\/(\d+)";
            const string partner = @"(p)([a-p])\/([a-p])";
            static string[] patterns = { spin, exchange, partner };

            public static Instruction CreateFromString(string input) {
                foreach (var pattern in patterns) {
                    var matcher = new Regex(pattern);
                    var match = matcher.Match(input);

                    switch (match.Groups[1].Value) {
                        case "s":
                            return new Spin(int.Parse(match.Groups[2].Value));
                        case "x":
                            return new Exchange(int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value));
                        case "p":
                            return new Partner(match.Groups[2].Value[0] - 97, match.Groups[3].Value[0] - 97);
                    }
                }
                throw new Exception("Unknown instruction");
            }
        }
    }

    public class Spin : Instruction {
        public Spin(int a) : base(a, 0) {}
    }

    public class Exchange : Instruction {
        public Exchange(int a, int b) : base (a, b) {}
    }

    public class Partner : Instruction
    {
        public Partner(int a, int b) : base(a, b) { }
    }

}
