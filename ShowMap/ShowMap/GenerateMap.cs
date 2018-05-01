using System;
using System.Collections.Generic;

namespace ShowMap
{
    public class GenerateMap
    {
        public Map Generate(Map map,int rectSize,int genCount,int zscale)
        {
            List<Rect> rects = new List<Rect>();
            Random rand = new Random();
            //for (int i = 0; i < map.SizeX; i++)
            {
                //for (int j = 0; j < map.SizeY; j++)
                {
                    for (int i = 0; i < genCount; i++)
                    {
                        Rect genRect = new Rect();

                        genRect.X1 = rand.Next(0, map.SizeX);
                        genRect.Y1 = rand.Next(0, map.SizeY);
                        genRect.X2 = genRect.X1 + rectSize / 4 + rand.Next(0, map.SizeX);
                        genRect.Y2 = genRect.Y1 + rectSize / 4 + rand.Next(0, map.SizeY);
                        if (genRect.Y2 > map.SizeY) genRect.Y2 = map.SizeY;
                        if (genRect.X2 > map.SizeX) genRect.X2 = map.SizeX;
                        for (int i2 = genRect.X1; i2 < genRect.X2; i2++)
                            for (int j2 = genRect.Y1; j2 < genRect.Y2; j2++)
                                map.Heights[i2, j2] += (float) (zscale) / (float) (genCount) + rand.Next(0, 50) / 50.0;
                        rects.Add(genRect);
                    }
                }
            }

            map.Rectangles = rects;
            return map;
        }
    }
}