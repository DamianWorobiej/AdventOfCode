using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode._2018._06
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int CalculateDistance(Point point)
        {
            var xDist = Math.Abs(X - point.X);
            var yDist = Math.Abs(Y - point.Y);
            return xDist + yDist;
        }

        public bool IsOnBoundry(Point mins, Point maxs)
        {
            int minx = mins.X;
            int maxx = maxs.X;

            int miny = mins.Y;
            int maxy = maxs.Y;

            if (X == minx || X == maxx || Y == miny || Y == maxy)
            {
                return true;
            }
            return false;
        }
    }
}
