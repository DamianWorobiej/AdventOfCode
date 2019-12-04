using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode._2019._03
{
    class Map
    {
        public Wire WireOne { get; set; }

        public Wire WireTwo { get; set; }

        public int GetClosestIntersectionDistance()
        {
            var matchingPoints = WireTwo.Points.Intersect(WireOne.Points);

            var output = matchingPoints.Min(x => x.GetDistanceToZero());

            return output;
        }

        public int GetFewestCombinedSteps()
        {
            var matchingPoints = WireTwo.Points.Intersect(WireOne.Points);

            int min = int.MaxValue;
            foreach (var point in matchingPoints)
            {
                int wireOneSteps = WireOne.GetSepsToPoint(point);
                int wireTwoSteps = WireTwo.GetSepsToPoint(point);
                int steps = wireOneSteps + wireTwoSteps;
                min = steps < min ? steps : min;
            }
            return min;
        }
    }
}
