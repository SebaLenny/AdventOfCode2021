using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2
{
    public class Boat
    {
        public int HorizontalPosition { get; set; }
        public int VerticalPosition { get; set; }
        public int Aim { get; set; }

        public void ApplyInstructionPartOne(Instruction instruction)
        {
            if (instruction.Dir == Instruction.Direction.UP) VerticalPosition -= instruction.Units;
            else if (instruction.Dir == Instruction.Direction.DOWN) VerticalPosition += instruction.Units;
            else if (instruction.Dir == Instruction.Direction.FORWARD) HorizontalPosition += instruction.Units;
        }

        public void ApplyInstructionPartTwo(Instruction instruction)
        {
            if (instruction.Dir == Instruction.Direction.UP)
            {
                // VerticalPosition -= instruction.Units;
                Aim -= instruction.Units;
            }
            else if (instruction.Dir == Instruction.Direction.DOWN)
            {
                // VerticalPosition += instruction.Units;
                Aim += instruction.Units;
            }
            else if (instruction.Dir == Instruction.Direction.FORWARD)
            {
                HorizontalPosition += instruction.Units;
                VerticalPosition += Aim * instruction.Units;
            }
        }

        public void ApplyInstructionsPartOne(List<Instruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                ApplyInstructionPartOne(instruction);
            }
        }

        public void ApplyInstructionsPartTwo(List<Instruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                ApplyInstructionPartTwo(instruction);
            }
        }
    }
}