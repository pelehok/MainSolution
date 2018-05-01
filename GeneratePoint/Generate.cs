using GeneratePoint.Models;
using GeneratePoint.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GeneratePoint
{
    class Generate
    {
        private int MapSize = 400;
        private int MapX = 400;
        private int MapY = 400;
        private ObservableCollection<IMapItem> AllOfThem = new ObservableCollection<IMapItem>();
        private readonly IMapService MapHandler = new MapService();

        public void LoadMap(int DotCount)
        {
            var rnd = new Random();

            var points = new HashSet<BenTools.Mathematics.Vector>();
            points.Clear();
            for (int i = 0; i < DotCount; i++)
            {
                var x = rnd.NextDouble() * (MapX);
                var y = rnd.NextDouble() * (MapY);

                points.Add(new BenTools.Mathematics.Vector(x, y));
            }

            AllOfThem.Clear();


            MapHandler.LoadMap(new LoadMapParams(points, true, MapX, MapY));

            AddThemAll();
        }

        private void AddThemAll()
        {
            foreach (Center o in App.AppMap.Centers.Values)
            {
                AllOfThem.Add(o);
            }

            foreach (Corner c in App.AppMap.Corners.Values)
            {
                AllOfThem.Add(c);
            }

            foreach (Edge ed in App.AppMap.Edges.Values)
            {
                AllOfThem.Add(ed);
            }
        }

        public Map LoadMapStuff(int count_point)
        {
            App.Startup();
            LoadMap(count_point);
            string s = "";
            s += (MapSize + " " + MapSize + "  |  " + 0) + "\r\n";
            s += (0 + " " + 0 + "  |  " + 0) + "\r\n";
            s += (0 + " " + MapSize + "  |  " + 0) + "\r\n";
            s += (MapSize + " " + 0 + "  |  " + 0) + "\r\n";
            foreach (KeyValuePair<int, Center> keyValue in App.AppMap.Centers)
            {
                Point point = keyValue.Value.Point;
                double el = keyValue.Value.Elevation;
                s += (point.X + " " + point.Y + "  |  " + el) + "\r\n";
            }
            System.IO.File.WriteAllText(@"../../../WriteText.txt", s);
            Console.WriteLine(s);
            return App.AppMap;
        }
    }
}
