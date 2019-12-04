using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode._2019._03
{
    class Point
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int GetDistanceToZero()
        {
            return X != 0 || Y != 0 ? Math.Abs(X) + Math.Abs(Y) : int.MaxValue;
        }

        public override bool Equals(object obj)
        {
            Point secondPoint = (Point)obj;
            return X == secondPoint.X && Y == secondPoint.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
