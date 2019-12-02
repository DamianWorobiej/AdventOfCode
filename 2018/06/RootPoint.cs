using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode._2018._06
{
    public class RootPoint : Point
    {
        public int Number { get; set; }
        public List<CheckedPoint> Points { get; set; }
        public bool IsBounded { get; set; }

        public int Area
        {
            get
            {
                return Points.Count;
            }
        }

        protected RootPoint(int x, int y) : base(x, y)
        {
            IsBounded = true;
            Points = new List<CheckedPoint>();
        }

        public static RootPoint FromStringCoordinates(string coordinates)
        {
            var coords = coordinates.Split(',');
            return new RootPoint(Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]));
        }
    }
}
