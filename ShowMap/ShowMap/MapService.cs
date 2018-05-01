using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Media3D;

namespace ShowMap
{
    public class MapSevice
    {
        public static List<Rect> ToRectangle(Map map){
            List<Rect> rects = new List<Rect>();
            for (int i = 0; i < map.SizeX-1; i++)
            {
                int indexX1 = i;
                int indexX2 = i + 1;
                for (int j = 0; j < map.SizeX-1; j++)
                {
                    rects.Add(new Rect() {X1 = indexX1, X2 = indexX2, Y2 = j, Y1 = j + 1});
                }
            }

            return rects;
        }

        public static List<Point> ToTrianglePointVertices(Rect rectangle){
            List<Point> points = new List<Point>();
            points.Add(new Point(rectangle.X1, rectangle.Y2));
            points.Add(new Point(rectangle.X2, rectangle.Y2));
            points.Add(new Point(rectangle.X2, rectangle.Y1));
            points.Add(new Point(rectangle.X1, rectangle.Y1));
            return points;
        }

        public static List<int> ToTriangleIndices(int index){
            List<int> points = new List<int>();
            points.Add(index + 0);
            points.Add(index + 2);
            points.Add(index + 1);

            points.Add(index + 0);
            points.Add(index + 3);
            points.Add(index + 2);
            return points;
        }
    }
}