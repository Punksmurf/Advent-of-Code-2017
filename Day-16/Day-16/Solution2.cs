using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day16
{
    public class Solution2
    {
        public string Run() {
            var instructions = File.ReadAllText("input.txt").Split(",").Select(Instruction.Factory.CreateFromString);

            var programs = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p' };

            //find in how many runs we're back to abcdef..
            var result = new char[programs.Length];
            programs.CopyTo(result, 0);

            var cycles = 0;
            while(true) {
                cycles++;
                result = RunOriginal(result, instructions);
                //Console.WriteLine($"Cycle {cycles}: " + String.Join(" ", result));
                if (ProgramsEqual(result, programs)) {
                    Console.WriteLine($"Back to abcdefghijklmnop in {cycles} cycles");
                    break;
                }
            }

            var requiredRuns = 1e9 % cycles;
            Console.WriteLine($"Doing {requiredRuns} runs should be the same as 1 billion..");

            //We should always already have been past this one, shouldn't we? Because we're already back at abc
            //So to improve speed store the iterations we've made and look up the result value. Or whatever, wait a second.
            programs.CopyTo(result, 0); //it should be at abcd, but I don't want to risk it ;)
            for (var i = 0; i < requiredRuns; i++) {
                result = RunOriginal(result, instructions);
            }

            return String.Join("", result);
        }

        char[] RunOriginal(IEnumerable<Instruction> instructions)
        {
            var programs = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p' };
            return RunOriginal(programs, instructions);
        }

        char[] RunOriginal(char[] programs, IEnumerable<Instruction> instructions) {
            foreach (var instruction in instructions)
            {
                if (instruction is Spin)
                {
                    for (var i = 0; i < instruction.A; i++)
                    {
                        var e = programs[programs.Length - 1];
                        for (var j = programs.Length - 1; j >= 1; j--)
                        {
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
                else if (instruction is Partner)
                {
                    var iA = findProgram(programs, (char)(instruction.A + 97));
                    var iB = findProgram(programs, (char)(instruction.B + 97));
                    var t = programs[iA];
                    programs[iA] = programs[iB];
                    programs[iB] = t;
                }
            }
            return programs;
        }

        bool ProgramsEqual(char[] a, char[] b) {
            if (a.Length != b.Length) throw new Exception();
            for (var i = 0; i < a.Length; i++) {
                if (a[i] != b[i]) return false;
            }
            return true;
        }

        int findProgram(char[] programs, char program) {
            for (var i = 0; i < programs.Length; i++) {
                if (programs[i] == program) return i;
            }
            throw new Exception("Cannot find program");
        }
    }

}
