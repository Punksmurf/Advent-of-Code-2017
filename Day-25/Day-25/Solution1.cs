using System;
namespace Day25
{
    public class Solution1
    {
        public string Run() {
            var config = new FixedConfiguration();
            var machine = new TuringMachine(config);

            Console.WriteLine(machine);

            for (var i = 0; i < config.NumberOfRuns; i++) {
                machine.Step();
            }

            return machine.CalculateChecksum().ToString();
        }
    }
}
