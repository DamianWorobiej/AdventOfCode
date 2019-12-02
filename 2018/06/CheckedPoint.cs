using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode._2018._06
{
    public class CheckedPoint : Point
    {
        public RootPoint RootPoint { get; set; }
        public CheckedPoint(int x, int y) : base(x, y)
        {
        }
    }
}
