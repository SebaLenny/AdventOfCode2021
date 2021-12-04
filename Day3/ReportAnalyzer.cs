using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day3
{
    public static class ReportAnalyzer
    {
        public static Report Analyze(List<string> diagnosticReport)
        {
            var ret = new Report();
            var popularity = CalculateBitPopularity(diagnosticReport);
            var gammaList = CalculateGammaList(popularity, diagnosticReport.Count);
            var epsilonList = CalculateEpsilonList(gammaList);
            ret.GammaRate = BitListToInt(gammaList);
            ret.EpsilonRate = BitListToInt(epsilonList);
            ret.OxygenGeneratorRating = CalculateOxygenGeneratorRating(diagnosticReport);
            ret.CO2ScrubberRating = CalculateCO2ScrubberRating(diagnosticReport);
            return ret;
        }

        private static int CalculateOxygenGeneratorRating(List<string> stringBitsList)
        {
            var stringList = stringBitsList.ConvertAll(b => b); // Trick to get shallow copy
            for (int i = 0; i < stringBitsList[0].Length && stringList.Count > 1; i++)
            {
                var ithBitSum = stringList.Sum(s => s[i] - '0');
                var ithBitPopularity = ithBitSum * 2 >= stringList.Count ? 1 : 0;
                stringList = stringList.Where(s => s[i] - '0' == ithBitPopularity).ToList();
            }
            return Convert.ToInt32(stringList.First(), 2);
        }

        private static int CalculateCO2ScrubberRating(List<string> stringBitsList)
        {
            var stringList = stringBitsList.ConvertAll(b => b); // Trick to get shallow copy
            for (int i = 0; i < stringBitsList[0].Length && stringList.Count > 1; i++)
            {
                var ithBitSum = stringList.Sum(s => s[i] - '0');
                var ithBitUnpopularity = ithBitSum * 2 >= stringList.Count ? 0 : 1;
                stringList = stringList.Where(s => s[i] - '0' == ithBitUnpopularity).ToList();
            }
            return Convert.ToInt32(stringList.First(), 2);
        }

        private static List<int> CalculateBitPopularity(List<string> diagnosticReport)
        {
            var ret = new List<int>();
            var charLines = diagnosticReport.Select(l => l.ToCharArray()).ToList();
            for (int i = 0; i < charLines[0].Count(); i++)
            {
                ret.Add(charLines.Sum(l => l[i] - '0'));
            }
            return ret;
        }

        private static List<int> CalculateGammaList(List<int> bitPopularity, int popualtionSize)
        {
            return bitPopularity.Select(pl => pl >= popualtionSize / 2 ? 1 : 0).ToList();
        }

        private static List<int> CalculateEpsilonList(List<int> gammaList)
        {
            return gammaList.Select(pl => pl == 0 ? 1 : 0).ToList();
        }

        private static int BitListToInt(List<int> gammaList)
        {
            return Convert.ToInt32(string.Join("", gammaList), 2);
        }
    }

    public class Report
    {
        public int GammaRate { get; set; }
        public int EpsilonRate { get; set; }
        public int OxygenGeneratorRating { get; set; }
        public int CO2ScrubberRating { get; set; }
    }
}