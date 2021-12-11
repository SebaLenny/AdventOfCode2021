using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day6
{
    public class FishSimulator
    {
        private List<long> AgePopulation { get; set; } = new List<long> { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int DaysElapsed { get; set; }
        private int MaxDays { get; set; }
        public long LastDayCount { get { return AgePopulation.Sum(); } }

        public FishSimulator(List<byte> initialPopulation, int maxDays)
        {
            foreach (var number in initialPopulation)
            {
                AgePopulation[number] += 1;
            }
            MaxDays = maxDays;
        }

        private void IteratePopulation()
        {
            long zeros = AgePopulation[0];
            for (int i = 0; i < 8; i++)
            {
                AgePopulation[i] = AgePopulation[i + 1];
            }
            AgePopulation[6] += zeros;
            AgePopulation[8] = zeros;
            DaysElapsed += 1;
        }

        public void IterateDays()
        {
            while (DaysElapsed < MaxDays)
            {
                IteratePopulation();
            }
        }
    }
}