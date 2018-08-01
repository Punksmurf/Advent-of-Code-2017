using System;
using System.IO;
using System.Linq;

namespace Day16
{
    public class Solution1
    {
        public string Run() {
            var instructions = File.ReadAllText("input.txt").Split(",").Select(Instruction.Factory.CreateFromString);

            //instructions = "s1,x3/4,pe/b".Split(",").Select(Instruction.Factory.CreateFromString);

            var programs = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p' };

            foreach (var instruction in instructions) {
                if (instruction is Spin) {
                    for (var i = 0; i < instruction.A; i++) {
                        var e = programs[programs.Length - 1];
                        for (var j = programs.Length - 1; j >= 1; j--) {
                            programs[j] = programs[j - 1];   
                        }
                        programs[0] = e;
                    }
                }
                else if (instruction is Exchange) 
                {
                    var t = programs[instruction.A];
                    programs[instruction.A] = programs[instruction.B];
                    programs[instruction.B] = t;
                }
                else if (instruction is Partner) {
                    var iA = findProgram(programs, (char)(instruction.A+97));
                    var iB = findProgram(programs, (char)(instruction.B+97));
                    var t = programs[iA];
                    programs[iA] = programs[iB];
                    programs[iB] = t;
                }

                //Console.WriteLine(String.Join(" ", programs));

            }

            return String.Join("", programs);
        }

        int findProgram(char[] programs, char program) {
            for (var i = 0; i < programs.Length; i++) {
                if (programs[i] == program) return i;
            }
            throw new Exception("Cannot find program");
        }
    }

}
