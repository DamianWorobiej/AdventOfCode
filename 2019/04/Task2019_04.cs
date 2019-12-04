using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode._2019._04
{
    class Task2019_04 : InputReader
    {
        public Task2019_04()
        {
            base.Path = ConcatPaths("2019", "04");
        }

        public override void RunTask()
        {
            // https://github.com/viceroypenguin/adventofcode/blob/master/2019/day04.original.cs
            // /\ this guy is my champ

            var input = ReadWholeFile();
            var range = input.Split('-');
            int start = Convert.ToInt32(range[0]);
            int end = Convert.ToInt32(range[1]);

            var firstTask = GetAmountOfDifferentPossiblePasswords(start, end);
            var secondTask = GetMoreStrictAmountOfDifferentPossiblePasswords(start, end);

            Console.WriteLine("First: {0}", firstTask);
            Console.WriteLine("Second: {0}", secondTask);
        }

        private int GetAmountOfDifferentPossiblePasswords(int start, int end)
        {
            int possiblePasswordsCount = 0;

            for (int i = start; i < end + 1; i++)
            {
                if (IsNumberNotDecreasing(i) && DoesNumberHaveMultiples(i))
                {
                    possiblePasswordsCount++;
                }
            }

            return possiblePasswordsCount;
        }

        private int GetMoreStrictAmountOfDifferentPossiblePasswords(int start, int end)
        {
            int possiblePasswordsCount = 0;

            for (int i = start; i < end + 1; i++)
            {
                if (IsNumberNotDecreasing(i) && DoesNumberHaveDoubles(i))
                {
                    possiblePasswordsCount++;
                }
            }

            return possiblePasswordsCount;
        }

        private bool IsNumberNotDecreasing(int number)
        {
            string numberString = number.ToString();

            for (int i = 0; i < numberString.Length - 1; i++)
            {
                if (Convert.ToInt32(numberString[i]) > Convert.ToInt32(numberString[i + 1]))
                {
                    return false;
                }
            }

            return true;
        }

        private bool DoesNumberHaveMultiples(int number)
        {
            return number.ToString().GroupBy(x => x).Any(c => c.Count() > 1);
        }

        private bool DoesNumberHaveDoubles(int number)
        {
            return number.ToString().GroupBy(x => x).Any(c => c.Count() == 2);
        }
    }
}
