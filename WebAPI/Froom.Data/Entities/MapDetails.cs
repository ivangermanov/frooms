using System.Collections.Generic;

namespace Froom.Data.Entities
{
    public class MapDetails
    {
        public Shape ShapeType { get; set; }

        public List<Point> Points { get; set; }
    }

    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    public enum Shape
    {
        RECTANGLE = 0,
        CIRCLE = 1,
        POLYGON = 2
    }
}
