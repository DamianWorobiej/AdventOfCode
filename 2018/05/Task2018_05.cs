using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode._2018._05
{
    class Task2018_05 : InputReader
    {
        public Task2018_05()
        {
            base.Path = ConcatPaths("2018", "05");
        }
        public override void RunTask()
        {
            string polymerLine = ReadWholeFile();
            List<char> polymer = GetPolymerFromChaos(polymerLine);

            List<char> decomposedPolymer = DecomposePolymer(polymer, 1);
            //List<char> cleanedDecomposedPolymer = CleaneDecomposedPolymer(decomposedPolymer);
            Console.WriteLine("Polymer has {0} units", decomposedPolymer.Count);
        }


        private List<char> GetPolymerFromChaos(string polymerLine)
        {
            List<char> output = new List<char>();
            for (int i = 0; i < polymerLine.Length; i++)
            {
                output.Add(polymerLine[i]);
            }
            return output;
        }

        private List<char> DecomposePolymer(List<char> polymer, int startingIndex)
        {
            for (int i = startingIndex; i < polymer.Count; i++)
            {
                if (i <= 0)
                {
                    continue;
                }
                Console.WriteLine("Checking {0} and {1}", polymer[i - 1], polymer[i]);
                if (AreOpposite(polymer[i - 1], polymer[i]))
                {
                    polymer.RemoveAt(i);
                    polymer.RemoveAt(i - 1);
                    i -= 2;
                    //return DecomposePolymer(polymer, i - 2);
                }
            }

            return polymer;
        }

        private List<char> CleaneDecomposedPolymer(List<char> decomposedPolymer)
        {
            for (int i = decomposedPolymer.Count - 1; i >= 0; i--)
            {
                if (decomposedPolymer[i] == null)
                {
                    decomposedPolymer.RemoveAt(i);
                }
            }
            return decomposedPolymer;
        }
        private bool AreOpposite(char unit1, char unit2)
        {
            return char.ToLower(unit1) == char.ToLower(unit2) && char.IsUpper(unit1) != char.IsUpper(unit2);
        }
    }
}
