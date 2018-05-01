using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratePoint.Models
{
    public partial class App
    {
        public static Map AppMap { get; set; }
        public static readonly int MapSize = 400;
        public static Random Random = new Random();

        public static void ResetMap()
        {
            App.AppMap.Centers.Clear();
            App.AppMap.Edges.Clear();
            App.AppMap.Corners.Clear();
        }

        public static void Startup()
        {
            AppMap = new Map();
        }
    }
}
