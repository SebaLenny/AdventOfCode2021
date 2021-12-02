using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2
{
    public interface IBoatStrategy
    {
        void ApplyInstruction(Instruction instruction, Boat boat);
    }
}