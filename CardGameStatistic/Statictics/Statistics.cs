using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameStatistic.Statictics
{
    public static class Statistics
    {
        public static void Stats()
        {
            string text = "Вот дом, Который построил Джек. А это пшеница, Которая в темном чулане хранится В доме, Который построил Джек. А это веселая птица-синица, Которая часто ворует пшеницу, Которая в темном чулане хранится В доме, Который построил Джек.";

            string[] words = text.ToLower().Split(new[] { ' ', '.', ',', '-', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordStatistics = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (wordStatistics.ContainsKey(word))
                {
                    wordStatistics[word]++;
                }
                else
                {
                    wordStatistics[word] = 1;
                }
            }


            Console.WriteLine("Слово\t\tКоличество");
            Console.WriteLine("-------------------------");
            foreach (var entry in wordStatistics)
            {
                Console.WriteLine($"{entry.Key}\t\t{entry.Value}");
            }

        }
    }
}
