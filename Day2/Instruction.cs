using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2
{
    public class Instruction
    {
        public Direction Dir { get; set; }
        public int Units { get; set; }

        public Instruction(string instruction)
        {
            var split = instruction.Split(" ");
            // DONT DO THAT AT HOME
            Dir = (Direction)Enum.Parse(typeof(Direction), split[0].ToUpper());
            Units = int.Parse(split[1]);
        }

        public enum Direction
        {
            FORWARD,
            DOWN,
            UP
        }
    }
}