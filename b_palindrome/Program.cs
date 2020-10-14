using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int total = 0;
            string nom = Console.ReadLine();
            char[] voyelles = new [] { 'a', 'e', 'i', 'o', 'u', 'y' };

            var nv = nom.Count(c => voyelles.Any(v => v == c));
            var nc = nom.Length - nv;

            total = nv * 2 - nc;

            var hasKer = nom.Contains("ker");

            if (hasKer)
            {
                total += 5;
            }

            if (total > 0)
            {
                if (IsPalindrome(nom))
                {
                    total *= 2;
                }
            }

            Console.WriteLine(total);
            Console.ReadLine();
        }

        private static bool IsPalindrome(string nom)
        {
            int i = 0;
            int j = nom.Length - 1;
            bool isPalindrome = true;

            while (i < nom.Length / 2 && isPalindrome)
            {
                if (nom[i] != nom[j])
                {
                    isPalindrome = false;
                }
                i++;
                j--;
            }

            return isPalindrome;
        }
    }
}
