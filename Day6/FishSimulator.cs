using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day6
{
    public class FishSimulator
    {
        private List<byte> LastGeneration { get; set; } = new List<byte>();
        private int DaysElapsed { get; set; }
        private int MaxDays { get; set; }
        public int LastDayCount { get { return LastGeneration.Count; } }

        public FishSimulator(List<byte> initialPopulation, int maxDays)
        {
            LastGeneration = new List<byte>(initialPopulation);
            MaxDays = maxDays;
        }

        private void IteratePopulation()
        {
            var newGen = new List<byte>(LastGeneration);
            var oldCount = newGen.Count;
            for (int i = 0; i < oldCount; i++)
            {
                newGen[i] -= 1;
                if (newGen[i] == byte.MaxValue)
                {
                    newGen[i] = 6;
                    newGen.Add(8);
                }
            }
            LastGeneration = newGen;
            GC.Collect();
            DaysElapsed += 1;
        }

        public void IterateDays()
        {
            while (DaysElapsed < MaxDays)
            {
                IteratePopulation();
                System.Console.WriteLine($"{DaysElapsed}\tdays elapsed");
            }
        }
    }
}