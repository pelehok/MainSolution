using System.Collections.Generic;
using System.Windows.Documents;

namespace ShowMap
{
    public struct Rect
    {
        public int X1, Y1, X2, Y2;
    }
    public class Map
    {
        private static Map Instance;
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public double[,] Heights { get; set; }
        public List<Rect> Rectangles = new List<Rect>();

        private Map(int sizeX, int sizeY){
            SizeX = sizeX;
            SizeY = sizeY;
            Heights = new double[sizeX, sizeY];
        }

        public static Map GetInstance(int sizeX, int sixeY){
            return Instance ?? (Instance = new Map(sizeX, sixeY));
        }
    }
}