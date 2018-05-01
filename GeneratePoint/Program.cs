using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratePoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Generate().LoadMapStuff(100);
            Console.WriteLine("All is good");
            Console.ReadKey();
        }
    }
}
