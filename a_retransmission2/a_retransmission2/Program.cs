using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a_retransmission2
{
    class Program
    {
        static void Main(string[] args)
        {
            string ligne1 = Console.ReadLine();
            string ligne2 = Console.ReadLine();
            string ligne3 = Console.ReadLine();

            string[] t = ligne1.Split(' ');

            int a = int.Parse(t[0]);
            int b = int.Parse(t[1]);
            int c = int.Parse(ligne2);
            int d = int.Parse(ligne3);

            Console.WriteLine(a * b + c + d);
        }
    }
}
