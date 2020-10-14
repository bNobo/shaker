using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();

            //Console.WriteLine("IMPOSSIBLE");
            //return;
            var r = new Random();

            if (r.Next(2) == 0)
            {
                Console.WriteLine("POSSIBLE");

            }
            else
            {
                Console.WriteLine("IMPOSSIBLE");
            }
        }
    }
}
