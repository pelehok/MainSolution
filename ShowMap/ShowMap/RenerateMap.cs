using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace ShowMap
{
    struct tRect
    {
        public int x1, y1, x2, y2;
    }
    public class RenerateMap
    {
        private int mapsizex { get; set; } = 128;
        private int mapsizey { get; set; } = 128;
        double[,] HM = new double[128, 128];
        private int zscale = 512;
        private int recSizex = 2;
        private int recSizey = 2;
        private int genStep = 4096;

        public void Calc(){
            List<tRect> rects = new List<tRect>();


            Random rand = new Random();
            for (int i = 0; i < genStep; i++)
            {
                tRect genRect = new tRect();

                genRect.x1 = rand.Next(0, mapsizex);
                genRect.y1 = rand.Next(0, mapsizey);
                genRect.x2 = genRect.x1 + recSizex / 4 + rand.Next(0,recSizex);
                genRect.y2 = genRect.y1 + recSizey / 4 + rand.Next(0, recSizey);
                if (genRect.y2 > mapsizey) genRect.y2 = mapsizey;
                if (genRect.x2 > mapsizex) genRect.x2 = mapsizex;
                for (int i2 = genRect.x1; i2 < genRect.x2; i2++)
                for (int j2 = genRect.y1; j2 < genRect.y2; j2++)
                    HM[i2,j2] += (float)(zscale) / (float)(genStep) + rand.Next(0,50) / 50.0;
                rects.Add(genRect);
            }
        }
    }
}