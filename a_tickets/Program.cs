using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a_tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var p1 = int.Parse(Console.ReadLine());
            var p2 = int.Parse(Console.ReadLine());
            var p3 = int.Parse(Console.ReadLine());

            var total = 0;

            if (n <= 100)
            {
                total = n * p1;
            }
            else
            {
                total = 100 * p1;

                if (n <= 200)
                {
                    total += (n - 100) * p2;
                }
                else
                {
                    total += 100 * p2;
                    total += (n - 200) * p3;
                }
            }

            Console.WriteLine(total);
            //Console.ReadLine();
        }
    }
}
