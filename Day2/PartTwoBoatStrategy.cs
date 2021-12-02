using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2
{
    public class PartTwoBoatStrategy : IBoatStrategy
    {
        public void ApplyInstruction(Instruction instruction, Boat boat)
        {
            if (instruction.Dir == Instruction.Direction.UP)
            {
                boat.Aim -= instruction.Units;
            }
            else if (instruction.Dir == Instruction.Direction.DOWN)
            {
                boat.Aim += instruction.Units;
            }
            else if (instruction.Dir == Instruction.Direction.FORWARD)
            {
                boat.HorizontalPosition += instruction.Units;
                boat.VerticalPosition += boat.Aim * instruction.Units;
            }
        }
    }
}