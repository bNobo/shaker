using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_tout_le_monde_entend
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            var line2 = new Line(Console.ReadLine());
            IEnumerable<int> tRi = line2.GetAllWordsAsInt();
            int n = int.Parse(Console.ReadLine());
            IEnumerable<int> tAj = new Line(Console.ReadLine()).GetAllWordsAsInt().OrderBy(_ => _);

            bool isPossible = true;
            int rang = 0;
            var tRiEnum = tRi.GetEnumerator();
            var tAjEnum = tAj.GetEnumerator();

            while (isPossible && tRiEnum.MoveNext())
            {
                rang++;
                int nombrePlaces = tRiEnum.Current;

                while (nombrePlaces > 0 && tAjEnum.MoveNext())
                {
                    int niveauAudition = tAjEnum.Current;

                    if (rang <= niveauAudition)
                    {
                        nombrePlaces--;
                    }
                    else
                    {
                        isPossible = false;
                    }
                }
            }

            if (tAjEnum.MoveNext())
            {
                isPossible = false;
            }

            if (isPossible)
            {
                Console.WriteLine("POSSIBLE");
            }
            else
            {
                Console.WriteLine("IMPOSSIBLE");
            }

            //Console.ReadLine();
        }
    }

    public class Line
    {
        private readonly string line;
        private string[] t;

        public Line(string line)
        {
            this.line = line;
            t = line.Split(' ');
        }

        public string GetWord(int index)
        {
            return t[index];
        }

        public int GetWordAsInt(int index)
        {
            string word = GetWord(index);

            return int.Parse(word);
        }

        public IEnumerable<int> GetAllWordsAsInt()
        {
            return t.Select(_ => int.Parse(_));
        }
    }
}
