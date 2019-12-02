using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode._2018._06
{
    class Area
    {
        public int MinX { get; set; }
        public int MaxX { get; set; }

        public int MinY { get; set; }
        public int MaxY { get; set; }

        public List<RootPoint> RootPoints { get; set; }

        public Area(List<RootPoint> rootPoints)
        {
            RootPoints = rootPoints;
            WriteNumbersToRootPoints();
            SetBoundries();
        }

        private void WriteNumbersToRootPoints()
        {
            int i = 0;
            foreach (var point in RootPoints)
            {
                point.Number = i;
                i++;
            }
        }

        private void SetBoundries()
        {
            MinX = MinY = int.MaxValue;
            MaxX = MaxY = int.MinValue;
            foreach (var point in RootPoints)
            {
                MinX = point.X < MinX ? point.X : MinX;
                MaxX = point.X > MaxX ? point.X : MaxX;
                MinY = point.Y < MinY ? point.Y : MinY;
                MaxY = point.Y > MaxY ? point.Y : MaxY;
            }
        }

        public RootPoint GetClosesRootPoint(CheckedPoint point)
        {
            int minDistance = int.MaxValue;
            RootPoint closestPoint = null;
            foreach (var rootPoint in RootPoints)
            {
                int distance = rootPoint.CalculateDistance(point);
                if (distance == minDistance)
                {
                    return null;
                }
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestPoint = rootPoint;
                }

            }
            return closestPoint;
        }

        public void SetBoundriesFlags()
        {
            Point min = new Point(MinX, MinY);
            Point max = new Point(MaxX, MaxY);
            foreach (var rootPoint in RootPoints)
            {
                foreach (var point in rootPoint.Points)
                {
                    if (point.IsOnBoundry(min, max))
                    {
                        rootPoint.IsBounded = false;
                        break;
                    }
                }
            }
        }

        public List<RootPoint> GetBoundedPoints()
        {
            List<RootPoint> output = new List<RootPoint>();
            foreach (var point in RootPoints)
            {
                if (point.IsBounded)
                {
                    output.Add(point);
                }
            }
            return output;
        }
    }
}
