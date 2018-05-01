using System.Collections.Generic;
using System.Windows;

namespace GeneratePoint.Models
{
    public class Triangle
    {
        public List<Corner> Corners { get; set; }
        public List<Edge> Edges { get; set; }
        public List<Triangle> Neightbours { get; set; }
        public Point Point { get; set; }
        public Center Parent { get; set; }

        public Triangle()
        {
            Corners = new List<Corner>();
            Edges = new List<Edge>();
            Neightbours = new List<Triangle>();

        }
    }
}
