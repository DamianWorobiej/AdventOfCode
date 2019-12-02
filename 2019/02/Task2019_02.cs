using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode._2019._02
{
    class Task2019_02 : InputReader
    {
        private int Addition = 1;

        private int Multiplication = 2;

        private int EOP = 99;

        private int PartTwoValue = 19690720;

        private List<int> Intcode = new List<int>();
        private List<int> PartTwo = new List<int>();
        public Task2019_02()
        {
            base.Path = ConcatPaths("2019", "02");
        }

        public override void RunTask()
        {
            var inputString = ReadWholeFile();
            var input = inputString.Split(',');
            foreach (var integer in input)
            {
                Intcode.Add(Convert.ToInt32(integer));
            }
            PrepareToTestOne();

            bool stopExecution = false;
            int i = 0;

            while (!stopExecution)
            {
                if (Intcode[i] == Addition)
                {
                    i = PerformAddition(i);
                    continue;
                }
                if (Intcode[i] == Multiplication)
                {
                    i = PerformMultiplication(i);
                    continue;
                }
                if (Intcode[i] == EOP)
                {
                    stopExecution = true;
                }
            }

            foreach (var integer in input)
            {
                PartTwo.Add(Convert.ToInt32(integer));
            }

            int noun = 0;
            int verb = 0;

            int j = 0;
            int k = 0;
            bool resultFound = false;

            while (!resultFound && j < 100)
            {
                k = 0;
                while (!resultFound && k < 100)
                {
                    Console.WriteLine("Checking {0}, {1}", j, k);
                    List<int> partTwoClone = new List<int>(PartTwo);
                    if (PartTwoValue == GetPartTwoSolution(j, k, partTwoClone))
                    {
                        noun = j;
                        verb = k;
                        resultFound = true;
                    }
                    k++;
                }
                j++;
            }

            Console.WriteLine("Part one: {0}", Intcode[0]);
            Console.WriteLine("Part two: {0} ({1}, {2})", 100 * noun + verb, noun, verb);
        }

        private void PrepareToTestOne()
        {
            Intcode[1] = 12;
            Intcode[2] = 2;
        }

        private int PerformAddition(int i)
        {
            int intOneIndex = Intcode[i + 1];
            int intTwoIndex = Intcode[i + 2];
            int overrideIndex = Intcode[i + 3];

            int valueOne = Intcode[intOneIndex];
            int valueTwo = Intcode[intTwoIndex];
            int insertedValue = valueOne + valueTwo;
            int oldValue = Intcode[overrideIndex];

            Intcode[overrideIndex] = insertedValue;

            return i + 4;
        }

        private int PerformAddition(int i, List<int> list)
        {
            int intOneIndex = list[i + 1];
            int intTwoIndex = list[i + 2];
            int overrideIndex = list[i + 3];

            int valueOne = list[intOneIndex];
            int valueTwo = list[intTwoIndex];
            int insertedValue = valueOne + valueTwo;
            int oldValue = list[overrideIndex];

            list[overrideIndex] = insertedValue;

            return i + 4;
        }


        private int PerformMultiplication(int i)
        {
            int intOneIndex = Intcode[i + 1];
            int intTwoIndex = Intcode[i + 2];
            int overrideIndex = Intcode[i + 3];

            int valueOne = Intcode[intOneIndex];
            int valueTwo = Intcode[intTwoIndex];
            int insertedValue = valueOne * valueTwo;
            int oldValue = Intcode[overrideIndex];

            Intcode[overrideIndex] = insertedValue;

            return i + 4;
        }

        private int PerformMultiplication(int i, List<int> list)
        {
            int intOneIndex = list[i + 1];
            int intTwoIndex = list[i + 2];
            int overrideIndex = list[i + 3];

            int valueOne = list[intOneIndex];
            int valueTwo = list[intTwoIndex];
            int insertedValue = valueOne * valueTwo;
            int oldValue = list[overrideIndex];

            list[overrideIndex] = insertedValue;

            return i + 4;
        }

        private int GetPartTwoSolution(int one, int two, List<int> list)
        {
            list[1] = one;
            list[2] = two;
            bool stopExecution = false;
            int i = 0;

            while (!stopExecution)
            {
                if (list[i] == Addition)
                {
                    i = PerformAddition(i, list);
                    continue;
                }
                if (list[i] == Multiplication)
                {
                    i = PerformMultiplication(i, list);
                    continue;
                }
                if (list[i] == EOP)
                {
                    stopExecution = true;
                }
            }

            return list[0];
        }
    }
}
