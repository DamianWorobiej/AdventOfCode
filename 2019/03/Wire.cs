using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode._2019._03
{
    class Wire
    {
        public List<Point> Points { get; set; }

        private const char Left = 'L';
        private const char Right = 'R';
        private const char Up = 'U';
        private const char Down = 'D';

        public Wire()
        {
            Points = new List<Point>();
        }

        public void FromInput(string input)
        {
            var inputRoutes = input.Split(',');
            Points.Add(new Point() { X = 0, Y = 0 });

            int currentX = 0;
            int currentY = 0;

            foreach (var direction in inputRoutes)
            {
                var dir = direction[0];
                int value = Convert.ToInt32(direction.Substring(1));

                switch (dir)
                {
                    case Left:
                        currentX -= value;
                        FillWire(new Point() { X = currentX, Y = currentY }, -1);
                        break;
                    case Right:
                        currentX += value;
                        FillWire(new Point() { X = currentX, Y = currentY }, 1);
                        break;
                    case Down:
                        currentY -= value;
                        FillWire(new Point() { X = currentX, Y = currentY }, -1);
                        break;
                    case Up:
                        currentY += value;
                        FillWire(new Point() { X = currentX, Y = currentY }, 1);
                        break;
                    default:
                        break;
                }
            }


        }

        private void FillWire(Point endPoint, int modifier)
        {
            Console.WriteLine("New Point: {0}, {1}", endPoint.X, endPoint.Y);
            Point lastPoint = Points.Last();
            bool isXChanged = lastPoint.X != endPoint.X;

            if (isXChanged)
            {
                int i = lastPoint.X + modifier;
                if (modifier > 0)
                {
                    while (i < endPoint.X + modifier)
                    {
                        Points.Add(new Point() { X = i, Y = endPoint.Y });
                        i += modifier;
                    }
                }
                else
                {
                    while (i > endPoint.X + modifier)
                    {
                        Points.Add(new Point() { X = i, Y = endPoint.Y });
                        i += modifier;
                    }
                }
            }
            else
            {
                int i = lastPoint.Y + modifier;
                if (modifier > 0)
                {
                    while (i < endPoint.Y + modifier)
                    {
                        Points.Add(new Point() { X = endPoint.X, Y = i });
                        i += modifier;
                    }
                }
                else
                {
                    while (i > endPoint.Y + modifier)
                    {
                        Points.Add(new Point() { X = endPoint.X, Y = i });
                        i += modifier;
                    }
                }
            }
        }

        public int GetSepsToPoint(Point point)
        {
            Point startPoint = new Point() { X = 0, Y = 0 };
            bool isStartPoint = point.Equals(startPoint);
            bool containsPoint = Points.IndexOf(point) != -1;
            return !isStartPoint && containsPoint ? Points.IndexOf(point) : 999999999;
        }
    }
}
