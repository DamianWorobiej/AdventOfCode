using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode._2019._03
{
    class Task2019_03 : InputReader
    {
        public Task2019_03()
        {
            base.Path = ConcatPaths("2019", "03");
        }
        public override void RunTask()
        {
            var input = ReadLines();
            Wire wireOne = new Wire();
            Wire wireTwo = new Wire();
            Console.WriteLine("Parsing Wire one");
            wireOne.FromInput(input[0]);
            Console.WriteLine("Parsing Wire Two");
            wireTwo.FromInput(input[1]);

            Map map = new Map()
            {
                WireOne = wireOne,
                WireTwo = wireTwo
            };

            Console.WriteLine("Calculating intersections");
            var closestIntersectionDistance = map.GetClosestIntersectionDistance();

            Console.WriteLine("Calculating fewest steps");
            var fewestStep = map.GetFewestCombinedSteps();

            Console.WriteLine("First: {0}", closestIntersectionDistance);
            Console.WriteLine("Second: {0}", fewestStep);
        }
    }
}
