using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode._2018._06
{
    class Task2018_06 : InputReader
    {
        private Area area;
        public Task2018_06()
        {
            base.Path = ConcatPaths("2018", "06");
        }

        public override void RunTask()
        {
            InitializeArea();
            for (int x = area.MinX; x < area.MaxX; x++)
            {
                for (int y = area.MinY; y < area.MaxY; y++)
                {
                    CheckedPoint point = new CheckedPoint(x, y);
                    RootPoint closestRootPoint = area.GetClosesRootPoint(point);
                    if (closestRootPoint == null)
                    {
                        continue;
                    }
                    area.RootPoints.FirstOrDefault(pt => pt.Number == closestRootPoint.Number).Points.Add(point);
                    //point.RootPoint = sourceRootPoint;
                    //sourceRootPoint.Points.Add(point);
                }
            }
            area.SetBoundriesFlags();
            List<RootPoint> boundedPoints = area.GetBoundedPoints();

            RootPoint maxAreaPoint = boundedPoints.OrderByDescending(x => x.Area).First();
            Console.WriteLine("Point {0} has max area of {1}", maxAreaPoint.Number, maxAreaPoint.Area);
        }

        private void InitializeArea()
        {
            List<string> rootNodes = ReadLines();
            List<RootPoint> points = new List<RootPoint>();
            foreach (var point in rootNodes)
            {
                points.Add(RootPoint.FromStringCoordinates(point));
            }
            area = new Area(points);
        }
    }
}
