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
        public IBoatStrategy BoatStrategy { get; set; }

        public void ResetPosition()
        {
            HorizontalPosition = 0;
            VerticalPosition = 0;
            Aim = 0;
        }

        public void ApplyInstruction(Instruction instruction)
        {
            BoatStrategy.ApplyInstruction(instruction, this);
        }

        public void ApplyInstructions(List<Instruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                ApplyInstruction(instruction);
            }
        }
    }
}